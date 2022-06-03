using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id:long}")]   
        public async Task<IActionResult> GetCustomerAsync([FromRoute] long id)
        {
            if(id == 0 || id < 0) return BadRequest();
            var customerDto = await _customerService.GetById(id);
            if(customerDto == null)
            {
                return StatusCode(404); // 404, если пользователь не был найден
            }
            else
            {
                return Ok(customerDto /* возвращает кастомера */); // сервер должен отдавать статус-код 200 с информацией о пользователе
            }
        }


        [HttpPost]   
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerDto newCustomer)
        {
            if(newCustomer == null) return BadRequest();
            if(string.IsNullOrEmpty(newCustomer.Lastname?.Trim())
                || string.IsNullOrEmpty(newCustomer.Firstname?.Trim())
                ) return BadRequest();
            var existCustomer = await _customerService.CheckOnFields(newCustomer);
            if(existCustomer != null)
            {
                return StatusCode(409); // 409, если пользователь с таким именем и фамилией уже существует в базе
            }
            var customerDto = await _customerService.InsertAsync(newCustomer); 
            return Ok(customerDto.Id /* Возвращает идентификатор Id */); // если пользователь добавлен без ошибок;
        }
    }
}