using API.Models;
using API.Models.DTO;
using API.Repositoty.IRepositoty;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using MPVI_Warehouse.Util;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeControler : ControllerBase
    {
        protected ResponseDTO _response;
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public DiscountCodeControler(IUnitOfWork unit, IMapper map)
        {
            _repo = unit;
            this._response = new ResponseDTO();
            _mapper = map;
        }


        [HttpGet("{code}")]
        public async Task<ResponseDTO> GetbyCode(string code)
        {
            try
            {
                _response.Result = _repo.DiscountCodeRepository.Get(u => u.DiscountCode1 == code &&
                u.DiscountStatus == SD.DiscountCodeStatus.Avai.ToString());

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        public async Task<ResponseDTO> GetAll()
        {
            try
            {
                _response.Result = _mapper.Map<IEnumerable<DiscountCodeDTO>>(_repo.DiscountCodeRepository
                            .GetAll(u => u.DiscountStatus == SD.DiscountCodeStatus.Avai.ToString()));

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDTO> CreateNew( DiscountCodeDTO dto)
        {
            try
            {
                DiscountCode data = _mapper.Map<DiscountCode>(dto);
                data.DiscountStatus = SD.DiscountCodeStatus.Avai.ToString();
                _repo.DiscountCodeRepository.Add(data);
                _repo.Save();
                _response.Message = "Add succesfully !!! ";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        [HttpPut]
        public async Task<ResponseDTO> Update(DiscountCodeDTO dto)
        {
            try
            {
                DiscountCode? data = _repo.DiscountCodeRepository.Get(u => u.DiscountCode1 == dto.DiscountCode1);
                if (data != null)
                {
                    data = _mapper.Map<DiscountCode>(dto) ;
                    _repo.DiscountCodeRepository.Update(data);
                    _repo.Save();
                    _response.Message = "Update succesfully !!! ";
                }
                else
                {
                    _response.Message = " Not found  !!! ";
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

        [HttpDelete]
        public async Task<ResponseDTO> Delete(string code)
        {
            try
            {
                DiscountCode? data = _repo.DiscountCodeRepository.Get( u => u.DiscountCode1 == code);
                if (data != null)
                {
                    data.DiscountStatus = SD.DiscountCodeStatus.Deleted.ToString();
                    _repo.DiscountCodeRepository.Update (data);
                    _repo.Save();
                    _response.Message = "Delete succesfully !!! ";
                }
                else
                {
                    _response.Message = " Not found  !!! ";
                    _response.IsSuccess =false;
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
