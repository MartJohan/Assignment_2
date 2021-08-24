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
            Customer customer = customerRepository.GetCustomer(2);

            List<CustomerCountry> list = (List<CustomerCountry>)customerRepository.CountCustomersPerCountry();


            foreach(var item in list)
            {
                Console.WriteLine($"{item.Country} has {item.CustomerCount}");
            }

           // Console.WriteLine($"{customer.ID}  {customer.Firstname}  {customer.Lastname}  {customer.Country}" +
             //   $"{customer.Email}  {customer.PostalCode}  {customer.PhoneNumber}");

        }
    }
}
