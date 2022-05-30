using PostgresTest.DAL.Context;
using PostgresTest.DAL.Entities;

namespace PostgresTest.DAL.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
