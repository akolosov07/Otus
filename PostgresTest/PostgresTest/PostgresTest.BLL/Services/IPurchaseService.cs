using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostgresTest.BLL.Dtos;
using PostgresTest.DAL.Repositories;

namespace PostgresTest.BLL.Services
{
    public interface IPurchaseService
    {
        Task<List<PurchaseDto>> GetAllAsync();
    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PurchaseDto>> GetAllAsync()
        {
            var purchaseList = await _unitOfWork.PurchaseRepository
                .GetList(
                orderBy: p => p.OrderBy(x => x.Customer.Name),
                include: p => p.Include(x => x.Customer).Include(x => x.Product));
            var purchaseListDto = _mapper.Map<List<PurchaseDto>>(purchaseList);
            return purchaseListDto;
        }
    }
}
