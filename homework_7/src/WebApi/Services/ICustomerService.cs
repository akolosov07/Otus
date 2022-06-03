using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> InsertAsync(CreateCustomerDto newCustomer);
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto> UpdateAsync(CustomerDto customer);
        Task<CustomerDto> DeleteAsync(long id);
        Task<CustomerDto> GetById(long id);
        Task<CustomerDto> CheckOnFields(CreateCustomerDto newCustomer);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDto> CheckOnFields(CreateCustomerDto newCustomer)
        {
            var customer = await _unitOfWork.CustomerRepository.FindSingleAsync(c => 
            c.Firstname.ToLower() == newCustomer.Firstname.ToLower()
            && c.Lastname.ToLower() == newCustomer.Lastname.ToLower());
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerDto> GetById(long id)
        {
            var customer = await _unitOfWork.CustomerRepository.FindSingleAsync(c => c.Id == id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> InsertAsync(CreateCustomerDto newCustomer)
        {
            var customer = _mapper.Map<Customer>(newCustomer);
            await _unitOfWork.CustomerRepository.CreateAsync(customer);
            await _unitOfWork.SaveCompletedAsync();
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
