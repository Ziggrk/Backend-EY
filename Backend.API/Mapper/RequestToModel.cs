using Backend.API.Request;
using Backend.Infrastructure.Models;

namespace Backend.API.Mapper
{
    public class RequestToModel : AutoMapper.Profile
    {
        public RequestToModel()
        {
            CreateMap<UserRequest, User>()
                    .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username))
                    .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));
            CreateMap<SupplierRequest, Supplier>()
                .ForMember(dest => dest.razonSocial, opt => opt.MapFrom(src => src.razonSocial))
                .ForMember(dest => dest.nombreComercial, opt => opt.MapFrom(src => src.nombreComercial))
                .ForMember(dest => dest.identificacionTributaria, opt => opt.MapFrom(src => src.identificacionTributaria))
                .ForMember(dest => dest.numeroTelefonico, opt => opt.MapFrom(src => src.numeroTelefonico))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.sitioWeb, opt => opt.MapFrom(src => src.sitioWeb))
                .ForMember(dest => dest.direccionFisica, opt => opt.MapFrom(src => src.direccionFisica))
                .ForMember(dest => dest.pais, opt => opt.MapFrom(src => src.pais))
                .ForMember(dest => dest.facturacionAnual, opt => opt.MapFrom(src => src.facturacionAnual));
        }
    }
}
