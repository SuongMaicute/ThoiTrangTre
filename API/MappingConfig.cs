using API.Models;
using API.Services;
using API.ViewModels;
using AutoMapper;

namespace API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
               config.CreateMap<DiscountCode, DiscountCodeDTO>().ReverseMap();

                config.CreateMap<Notice, NoticeDTO>().ReverseMap();
                config.CreateMap<Notice, NoticeCreatedModel>().ReverseMap();

                config.CreateMap<Order, OrderDTO>().ReverseMap();
                config.CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

                config.CreateMap<User, RegisterDTO>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
