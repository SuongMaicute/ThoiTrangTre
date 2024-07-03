using API.Models;
using API.Models.DTO;
using API.Repositoty.IRepositoty;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPVI_Warehouse.Util;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected ResponseDTO _response;
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unit, IMapper map)
        {
            _repo = unit;
            this._response = new ResponseDTO();
            _mapper = map;
        }

        [HttpGet()]
        public async Task<ResponseDTO> GetAll()
        {
            try
            {
                IEnumerable < Product > result = _mapper.Map<IEnumerable<Product>>(_repo.ProductRepository
                            .GetAll(u => u.ProductStatus != SD.ProductStatus.Deleted.ToString()));
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO> GetbyId(int id)
        {
            try
            {
                _response.Result = _repo.ProductRepository.Get(u => u.ProductId == id &&
                            u.ProductStatus != SD.ProductStatus.Deleted.ToString());
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPost]
        public async Task<ResponseDTO> CreateNew(ProductDTO dto)
        {
            try
            {
                Product data = _mapper.Map<Product>(dto);
                data.ProductStatus = SD.ProductStatus.Available.ToString();
                _repo.ProductRepository.Add(data);
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
        public async Task<ResponseDTO> Update(ProductDTO dto)
        {
            try
            {
                Product? data = _repo.ProductRepository.GetNotracking(u => u.ProductId == dto.ProductId).;
                if (data != null)
                {
                   data = _mapper.Map<Product>(dto);
                    _repo.ProductRepository.Update(data);
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
                Product? data = _repo.ProductRepository.Get(u => u.ProductId == id);
                if (data != null)
                {
                    data.ProductStatus = SD.ProductStatus.Deleted.ToString();
                    _repo.ProductRepository.Update(data);
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
