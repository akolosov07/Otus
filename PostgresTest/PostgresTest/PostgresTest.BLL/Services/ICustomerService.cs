using AutoMapper;
using PostgresTest.BLL.Dtos;
using PostgresTest.DAL.Entities;
using PostgresTest.DAL.Repositories;

namespace PostgresTest.BLL.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> InsertAsync(CreateCustomerDto newCustomer);
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto> UpdateAsync(CustomerDto customer);
        Task<CustomerDto> DeleteAsync(int id);
        Task<CustomerDto> GetByName(string name);
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

        public async Task<CustomerDto> DeleteAsync(int id)
        {
            var customer = await _unitOfWork.CustomerRepository.FindSingleAsync(c => c.CustomerID == id);
            if (customer == null) throw new Exception();
            var customerDto = _mapper.Map<CustomerDto>(customer);
            _unitOfWork.CustomerRepository.Delete(customer);
            await _unitOfWork.SaveCompletedAsync();
            return customerDto;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customserList = await _unitOfWork.CustomerRepository.GetList(orderBy: p => p.OrderBy(x => x.Name));
            var customerListDto = _mapper.Map<List<CustomerDto>>(customserList);
            return customerListDto;
        }

        public async Task<CustomerDto> GetByName(string name)
        {
            var customer = await _unitOfWork.CustomerRepository.FindSingleAsync(c => c.Name == name);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> InsertAsync(CreateCustomerDto newCustomer)
        {
            var customer =_mapper.Map<Customer>(newCustomer);
            await _unitOfWork.CustomerRepository.CreateAsync(customer);
            await _unitOfWork.SaveCompletedAsync();
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto customerDto)
        {
            var customer = await _unitOfWork.CustomerRepository.FindSingleAsync(c => 
            c.CustomerID == customerDto.CustomerID);
            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.SaveCompletedAsync();
            return customerDto;
        }
    }
}
