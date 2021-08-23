using dotnetcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.DAL
{
    class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> CountCustomersPerCountry()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string name)
        {
            throw new NotImplementedException();
        }

        public CustomerGenre GetMostPopularGenreForCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public CustomerSpender GetTopSpenders()
        {
            throw new NotImplementedException();
        }

        public CustomerSpender GetTopSpenders(int limit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadCustomersInRange(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
