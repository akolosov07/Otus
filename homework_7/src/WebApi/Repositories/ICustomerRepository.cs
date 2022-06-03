using WebApi.Context;
using WebApi.Models;

namespace WebApi.Repositories
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
