using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetcore.Models;

namespace dotnetcore.DAL
{
    public interface ICustomerRepository
    {
        /*
         * Read all customers, display ID, firstname, lastname, country, postal code, phone number and email
         * Read specific customer by id, display everything listed above
         * Read a specific customer by name
         * Return a page of customers. take in limit and offset as parameters
         * Add a new customer with fields listed above
         * update a customer
         * return number of customers in each country in descending order
         * For a customer return their most popular genre
         */

        public IEnumerable<Customer> ReadAllCustomers();

        public Customer GetCustomer(int id);

        public Customer GetCustomer(string firstname, string lastname);

        public IEnumerable<Customer> ReadCustomersInRange(int offset, int limit);

        public void AddCustomer(Customer customer);

        public void UpdateCustomer(Customer customer);

        public IEnumerable<Customer> CountCustomersPerCountry();

        public CustomerSpender GetTopSpenders();

        public CustomerSpender GetTopSpenders(int limit);

        public CustomerGenre GetMostPopularGenreForCustomer(Customer customer);
    }
}
