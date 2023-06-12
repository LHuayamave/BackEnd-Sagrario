using AutoMapper;
using FacturasAPI.DTOs;
using FacturasAPI.Entidad;

namespace FacturasAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, ProductoCreacionDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();

            CreateMap<FacturaCabecera, FacturaCabeceraDTO>()
                .ForMember(dest => dest.FacturaDetalle, opt => opt.MapFrom(src => src.FacturaDetalle));
            
            CreateMap<FacturaCabeceraCreacionDTO, FacturaCabecera>();

            CreateMap<FacturaDetalle, FacturaDetalleDTO>()
                .ForMember(dest => dest.ProductoDTO, opt => opt.MapFrom(src => src.FacturaDetalleProductos));
            
            CreateMap<FacturaDetalleCreacionDTO, FacturaDetalle>();
        }

    }
}
