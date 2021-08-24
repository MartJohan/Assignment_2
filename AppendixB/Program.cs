using dotnetcore.DAL;
using dotnetcore.Models;
using Microsoft.Data.SqlClient;
using System;

namespace dotnetcore
{
    class Program
    {

        static void Main(string[] args)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetCustomer(2);
            Console.WriteLine($"{customer.ID}  {customer.Firstname}  {customer.Lastname}  {customer.Country}" +
                $"{customer.Email}  {customer.PostalCode}  {customer.PhoneNumber}");

        }
    }
}
