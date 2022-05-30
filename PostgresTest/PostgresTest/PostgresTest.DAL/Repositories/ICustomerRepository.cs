using PostgresTest.DAL.Context;
using PostgresTest.DAL.Entities;

namespace PostgresTest.DAL.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
    }

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
