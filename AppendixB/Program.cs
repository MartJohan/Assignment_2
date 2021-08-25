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
            List<CustomerSpender> CountryOccuranceList = (List<CustomerSpender>)cr.GetTopSpenders(10);


            foreach(var item in CountryOccuranceList)
            {
                Console.WriteLine($"{item.CustomerFirstname} {item.CustomerLastname} {item.TotalAmount}");
            }
        }
    }
}
