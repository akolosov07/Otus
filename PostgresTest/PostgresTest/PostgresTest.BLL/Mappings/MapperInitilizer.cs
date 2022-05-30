using AutoMapper;
using PostgresTest.BLL.Dtos;
using PostgresTest.DAL.Entities;

namespace PostgresTest.BLL.Mappings
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<Purchase, CreatePurchaseDto>().ReverseMap();
        }
    }
}
