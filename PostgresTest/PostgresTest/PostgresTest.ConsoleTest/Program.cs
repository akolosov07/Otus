using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostgresTest.BLL.Dtos;
using PostgresTest.BLL.Mappings;
using PostgresTest.BLL.Services;
using PostgresTest.DAL.Context;
using PostgresTest.DAL.Repositories;

//DI
var collection = new ServiceCollection();
collection.AddScoped<ICustomerService, CustomerService>();
collection.AddScoped<ICustomerRepository, CustomerRepository>();
collection.AddScoped<IProductService, ProductService>();
collection.AddScoped<IProductRepository, ProductRepository>();
collection.AddScoped<IPurchaseService, PurchaseService>();
collection.AddScoped<IPurchaseRepository, PurchaseRepository>();
collection.AddScoped<IUnitOfWork, UnitOfWork>();
collection.AddAutoMapper(typeof(MapperInitilizer));

var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json", optional: false);
IConfiguration config = builder.Build();
var connectiomString = config.GetConnectionString("DefaultConnection");

collection.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectiomString));
IServiceProvider serviceProvider = collection.BuildServiceProvider();

//Service locator
var customerService = serviceProvider.GetService<ICustomerService>();
var productService = serviceProvider.GetService<IProductService>();
var purchaseService = serviceProvider.GetService<IPurchaseService>();

#region Пункт 3 Создать консольную программу, которая выводит содержимое всех таблиц.
var customers = await customerService.GetAllAsync();
var products = await productService.GetAllAsync();
var purchases = await purchaseService.GetAllAsync();

//список кастомеров
foreach (var customer in customers)
{
    Console.WriteLine($"Customer - {customer.Name}");
}
//список продуктов
foreach (var product in products)
{
    Console.WriteLine($"Product - {product.Name}");
}
//список покупок
foreach(var purchase in purchases)
{
    Console.WriteLine($"Purchase, Product Name - {purchase.Product.Name}, " +
        $" Customer Name - {purchase.Product.Name}");
}
#endregion

#region 4. Добавить в программу возможность добавления в таблицу на выбор.
CustomerDto customerDto = new CustomerDto()
{
    Name = "Name7"
};
var createdCustomer = await customerService.InsertAsync(customerDto);
Console.WriteLine($"\nСозданный кастомер");
Console.WriteLine($"Customer Id = {createdCustomer.CustomerID}," +
    $" Name = {createdCustomer.Name}");

#endregion


