using dotnetcore.DAL;
using dotnetcore.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace dotnetcore
{
    class Program
    {

        static void Main(string[] args)
        {
        CustomerRepository customerRepository = new CustomerRepository();
            IEnumerable<Customer> n = customerRepository.ReadCustomersInRange(2, 10);

            foreach (Customer c in n)
            {
                Console.WriteLine(c.ToString());
            }

            Customer customer = new Customer
            {
                Firstname = "martin",
                Lastname = "johansen",
                Email = "martin.johansen@no.experis.com"

            };
            customerRepository.AddCustomer(customer);
        }
    }
}
