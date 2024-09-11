using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customer/{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        [Route("customer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            var newCustomer = _customerService.CreateCustomer(customer);
            return Ok(newCustomer);
        }

        [HttpPut]
        [Route("customer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            var currentCustomer = _customerService.GetCustomerById(customer.Id);
            if (currentCustomer == null)
                return NotFound();

            _customerService.Update(customer);
            return Ok();
        }

        [HttpDelete]
        [Route("customer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            _customerService.Delete(id);
            return Ok();
        }
    }
}
