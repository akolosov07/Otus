using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Newtonsoft.Json;

namespace WebClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(10000);
            // создадим тестового кастомера
            CustomerCreateRequest customerRequest = RandomCustomer();

            // 5. Отправляет данные, созданные в пункте 2.2., на сервер;
            long id = await CreateCustomerPostTest(customerRequest);

            // 6. По полученному ID от сервера запросить созданного пользователя с сервера и вывести на экран.
            var customer = await GetCustomerGetTest(id);

            // и вывести на экран
            Console.WriteLine($"Customer Id = {customer.Id}, FirstName = {customer.Firstname}," +
                $" LastName = {customer.Lastname} ");
        }

        /// <summary>
        /// 4. Генерирует случайным образом данные для создания нового "Клиента" на сервере;
        /// </summary>
        /// <returns></returns>
        private static CustomerCreateRequest RandomCustomer()
        {
            var dummyCustomer = new Faker<CustomerCreateRequest>()
                .RuleFor(c => c.Firstname, f => f.Name.FirstName())
                .RuleFor(c => c.Lastname, f => f.Name.LastName())
                .Generate(1);
            return dummyCustomer.FirstOrDefault();
        }

        /// <summary>
        /// 6. Отправляет данные, созданные в пункте 2.2., на сервер;
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns></returns>
        private static async Task<long> CreateCustomerPostTest(CustomerCreateRequest customerRequest)
        {
            var json = JsonConvert.SerializeObject(customerRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:5001/api/customers";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            return System.Int64.Parse(result);
        }

        private static async Task<Customer> GetCustomerGetTest(long id)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync($"https://localhost:5001/api/customers/{id}");

            var customer = JsonConvert.DeserializeObject<Customer>(content);
            return customer;
        }
    }
}