using PostgresTest.DAL.Context;

namespace PostgresTest.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        Task<bool> SaveCompletedAsync();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;
        private IPurchaseRepository _purchaseRepository;

        public IProductRepository ProductRepository => 
            _productRepository ?? new ProductRepository(_context);
        public ICustomerRepository CustomerRepository =>
            _customerRepository ?? new CustomerRepository(_context);
        public IPurchaseRepository PurchaseRepository =>
            _purchaseRepository ?? new PurchaseRepository(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public async Task<bool> SaveCompletedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
