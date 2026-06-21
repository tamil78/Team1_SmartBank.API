using System.Collections.Generic;
using Team1_SmartBank.API.Interfaces;
using Team1_SmartBank.API.Models;

namespace Team1_SmartBank.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _repo.GetById(id);
        }

        public void CreateCustomer(Customer customer)
        {
            _repo.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _repo.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _repo.Delete(id);
        }
    }
}