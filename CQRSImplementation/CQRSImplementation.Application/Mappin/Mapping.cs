using AutoMapper;
using CQRSImplementation.Application.Features.Command;
using CQRSImplementation.Domain.Model;

namespace CQRSImplementation.Application.Mappin
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
        }
    }
}
