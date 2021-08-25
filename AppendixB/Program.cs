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
            Customer cus = cr.GetCustomer(12);

            CustomerGenre cg =  cr.GetMostPopularGenreForCustomer(cus);

            foreach (string s in cg.GenreCount.Keys)
            {
                Console.WriteLine("KEY VALUE PAIR");
                Console.WriteLine(s);
                Console.WriteLine(cg.GenreCount[s]);
            }
        }
    }
}
