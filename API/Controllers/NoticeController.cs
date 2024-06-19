using API.Models;
using API.Models.DTO;
using API.Repositoty.IRepositoty;
using API.Services;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPVI_Warehouse.Util;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        protected ResponseDTO _response;
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public NoticeController(IUnitOfWork unit, IMapper map)
        {
            _repo = unit;
            this._response = new ResponseDTO();
            _mapper = map;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO> GetbyId(int id)
        {
            try
            {
                _response.Result = _repo.NoticeRepository.Get(u => u.NoticeId == id &&
                            u.NoticeStatus != SD.NoticeStatus.Deleted.ToString());
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
                _response.Result = _mapper.Map<IEnumerable<Notice>>(_repo.NoticeRepository
                            .GetAll(u => u.NoticeStatus != SD.NoticeStatus.Deleted.ToString()));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDTO> CreateNew(NoticeCreatedModel dto)
        {
            try
            {
                Notice data = _mapper.Map<Notice>(dto);
                data.NoticeStatus = SD.NoticeStatus.New.ToString();
                _repo.NoticeRepository.Add(data);
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
        public async Task<ResponseDTO> Update(NoticeCreatedModel dto, int noticeID)
        {
            try
            {
                Notice? data = _repo.NoticeRepository.Get(u => u.NoticeId == noticeID);
                if (data != null)
                {
                    data.NoticeTitle = dto.NoticeTitle;
                    data.NoticeContent = dto.NoticeContent;
                    data.UserId = dto.UserId;
                    _repo.NoticeRepository.Update(data);
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
        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                Notice? data = _repo.NoticeRepository.Get(u => u.NoticeId == id);
                if (data != null)
                {
                    data.NoticeStatus = SD.NoticeStatus.Deleted.ToString();
                    _repo.NoticeRepository.Update(data);
                    _repo.Save();
                    _response.Message = "Delete succesfully !!! ";
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

    }
}
