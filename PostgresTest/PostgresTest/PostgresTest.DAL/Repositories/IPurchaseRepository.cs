using PostgresTest.DAL.Context;
using PostgresTest.DAL.Entities;

namespace PostgresTest.DAL.Repositories
{
    public interface IPurchaseRepository : IRepositoryBase<Purchase>
    {
    }

    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
