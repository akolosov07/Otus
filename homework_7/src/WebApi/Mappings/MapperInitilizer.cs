using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Mappings
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        }
    }
}
