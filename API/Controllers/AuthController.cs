using API.Models;
using API.Models.DTO;
using API.Repositoty.IRepositoty;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MPVI_Warehouse.Util;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected ResponseDTO _response;
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public AuthController(IUnitOfWork unit, IMapper map)
        {
            _repo = unit;
            this._response = new ResponseDTO();
            _mapper = map;
        }

        [HttpPost]
        public async Task<ResponseDTO> Login(string email, string pass)
        {
            try
            {
                email = email.ToLower();
                User? current = _repo.UserRepository.Get( u => u.UsersEmail == email);
                if (current == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "You must to register first!!!";
                    return _response;
                }

                if (current.Passwords == SD.ComputeSha256Hash(pass))
                {
                    _response.Result = current;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Wrong username or password!!!";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        [HttpPut]
        public async Task<ResponseDTO> Register(RegisterDTO dto)
        {
            try
            {
                dto.UsersEmail = dto.UsersEmail.ToLower();
                dto.Passwords = SD.ComputeSha256Hash(dto.Passwords);
                User? register = _mapper.Map<User>(dto);
                register.RoleId = 3;
                if (register != null)
                {
                    _repo.UserRepository.Add(register);
                    _repo.Save();
                    _response.Message = "Register successfully!!!";

                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPost("ChangePass")]
        public async Task<ResponseDTO> ChangePass(ChangePassDTO dto)
        {
            try
            {
                // test
                User? user = _repo.UserRepository.Get( u => u.UsersEmail == dto.email);
                if (user != null && user.Passwords == SD.ComputeSha256Hash(dto.OldPass))
                {
                    _repo.UserRepository.Update(user);
                    _repo.Save();
                    _response.Message = "Change pass successfully!!!";
                }
                else
                {
                    _response.Message = "Username and password is not correct!!!";
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
