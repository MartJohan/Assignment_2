using dotnetcore.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.DAL
{
    class CustomerRepository : ICustomerRepository
    {
        public SqlConnectionStringBuilder Builder { get; set; }
        public SqlConnection Connection { get; set; }

        public CustomerRepository()
        {
            Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = Configuration.DATASOURCE;
            Builder.InitialCatalog = Configuration.INTERNAL_CATALOG;
            Builder.IntegratedSecurity = true;

            Connection = new SqlConnection(Builder.ConnectionString);
        }


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
            Connection.Open();
            string sql = $"Select * from Customer where CustomerId = {id}";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine($"{reader.GetName(0)}  {reader.GetName(1)}");

                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}  {reader.GetString(1)}");
                    }
                }
            }
            // ID, Firstname, Last, Country, PostalC, PhoneN, Email
            Connection.Close();
            return new Customer();
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
            Connection.Open();
            string sql = $"Select * from Customer";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine($"{reader.GetName(0)}  {reader.GetName(1)}");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}  {reader.GetString(1)}");
                    }
                }
            }
            Connection.Close();
        }

        public IEnumerable<Customer> ReadCustomersInRange(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            Console.WriteLine("ølaksdaskøld");
        }
    }
}
