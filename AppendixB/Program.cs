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
            CustomerRepository cr = new();
            Customer cus = cr.GetCustomer(3);
            Console.WriteLine("cus " + cus.Firstname);
            CustomerKeys[] a = { CustomerKeys.FirstName, CustomerKeys.LastName };
            string[] b = { "aaaaa", "bbbbbb" };
            cr.UpdateCustomer(cus, a, b);
            cus = cr.GetCustomer(3);
            Console.WriteLine("cus " + cus.Firstname);
        }
    }
}
