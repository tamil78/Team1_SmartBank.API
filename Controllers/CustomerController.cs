using Microsoft.AspNetCore.Mvc;
using Team1_SmartBank.API.Interfaces;
using Team1_SmartBank.API.Models;
using Team1_SmartBank.API.DTOs;

namespace Team1_SmartBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // ✅ GET ALL CUSTOMERS
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _service.GetCustomers();
            return Ok(customers);
        }

        // ✅ GET CUSTOMER BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _service.GetCustomer(id);

            if (customer == null)
                return NotFound("Customer not found");

            return Ok(customer);
        }

        // ✅ REGISTER CUSTOMER ✅ (USE RegisterDto)
        [HttpPost]
        public IActionResult Register(RegisterDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password,   // (later: hash)
                Role = dto.Role            // ✅ added role
            };

            _service.CreateCustomer(customer);

            return Ok(new
            {
                message = "Customer registered successfully",
                customer
            });
        }

        // ✅ UPDATE CUSTOMER
        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            var existing = _service.GetCustomer(customer.CustomerId);

            if (existing == null)
                return NotFound("Customer not found");

            existing.FullName = customer.FullName;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
            existing.Password = customer.Password;
            existing.Role = customer.Role;   // ✅ UPDATE ROLE ALSO

            _service.UpdateCustomer(existing);

            return Ok("Customer updated successfully");
        }

        // ✅ DELETE CUSTOMER
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetCustomer(id);

            if (existing == null)
                return NotFound("Customer not found");

            _service.DeleteCustomer(id);

            return Ok("Customer deleted successfully");
        }
    }
}