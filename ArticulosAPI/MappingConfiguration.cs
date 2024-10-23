using ArticulosAPI.Dto;
using ArticulosAPI.Modelos;
using AutoMapper;

namespace ArticulosAPI
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ArticuloDto, Articulo>();
                config.CreateMap<Articulo, ArticuloDto>();
            });
            return mappingConfig;
        }
    }
}