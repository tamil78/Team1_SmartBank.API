using System.Collections.Generic;
using Team1_SmartBank.API.Models;

namespace Team1_SmartBank.API.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}