using AutoMapper;
namespace API.Util
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
               
                //// WhDReceiptLog
                //config.CreateMap<WhFPosition, Position_DTO>().ReverseMap();


            });
            return mappingConfig;
        }
    }
}
