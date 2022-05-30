using AutoMapper;
using PostgresTest.BLL.Dtos;
using PostgresTest.DAL.Repositories;

namespace PostgresTest.BLL.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
    }

    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var productList = await _unitOfWork.ProductRepository.GetList();
            var productListDto = _mapper.Map<List<ProductDto>>(productList);
            return productListDto;
        }
    }
}
