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
            customerRepository.GetCustomer(2);
        }
    }
}
