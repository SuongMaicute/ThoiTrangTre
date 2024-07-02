using API.Models;
using API.Models.DTO;
using API.Repositoty.IRepositoty;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MPVI_Warehouse.Util;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        protected ResponseDTO _response;
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unit, IMapper map)
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
                Order? data = _repo.OrderRepository.Get
                    (u => u.OrderId == id && u.OrderStatus != SD.OrderStatus.Deleted.ToString());
                if (data == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Not found !!! ";
                    return _response;
                }
                IEnumerable<OrderItem> items = _repo.OrderItemRepository
                    .GetAll(u => u.OrderId == id);

                _response.Result = new OrderViewDetail
                {
                    Head = _mapper.Map<OrderDTO>(data),
                    Items = _mapper.Map<List<OrderItemDTO>>(items)
                };
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
                _response.Result = _mapper.Map<IEnumerable<OrderDTO>>
                    (_repo.OrderRepository.GetAll(u => u.OrderStatus != SD.OrderStatus.Deleted.ToString()));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDTO> CreateNew(CreateOrderViewModel dto)
        {
            try
            {
                if (dto.Items.Count < 1)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Empty items !!! ";
                    return _response;
                }

                IEnumerable<Product> products = _repo.ProductRepository.GetAll();

                IEnumerable<decimal> joinedData = from orderItem in dto.Items
                                                  join category in products
                                                  on orderItem.ProductId equals category.ProductId
                                                  select orderItem.Price;

                Order data = new Order()
                {
                    OrderDate = DateTime.Now,
                    UserId = dto.UserId,
                    OrderTotalAmount = decimal.Parse(dto.Total.ToString()),
                    OrderStatus = SD.OrderStatus.PaySucess.ToString()
                };

                _repo.OrderRepository.Add(data);
                _repo.Save();

                foreach (var item in dto.Items)
                {
                    OrderItem itemData = new OrderItem()
                    {
                        OrderId = data.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    _repo.OrderItemRepository.Add(itemData);
                }
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
        public async Task<ResponseDTO> UpdateStatus(int id, string status)
        {
            try
            {
                Order? data = _repo.OrderRepository.Get(u => u.OrderId == id && u.OrderStatus != SD.OrderStatus.Deleted.ToString());
                if (data != null && status != null)
                {
                    data.OrderStatus = status;
                    _repo.OrderRepository.Update(data);
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
                Order? data = _repo.OrderRepository.Get(u => u.OrderId == id && u.OrderStatus != SD.OrderStatus.Deleted.ToString());
                if (data != null)
                {
                    data.OrderStatus = SD.OrderStatus.Deleted.ToString();
                    _repo.OrderRepository.Update(data);
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


        [HttpPut("ChangeStatus")]
        public async Task<ResponseDTO> ChangeStatus(int orderid, string newstatus)
        {
            try
            {
                Order? data = _repo.OrderRepository.Get(u => u.OrderId == orderid && u.OrderStatus != SD.OrderStatus.Deleted.ToString());
                if (data != null)
                {
                    data.OrderStatus = newstatus;
                    _repo.OrderRepository.Update(data);
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
