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
            string sql = "Select CustomerId, Firstname, Lastname, Country, PostalCode, Phone, Email from Customer where CustomerId like @id";
            Customer customer = new Customer();

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Customer tempCustomer = new()
                    {
                        ID = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Country = reader.GetString(3),
                        PostalCode = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        Email = reader.GetString(6),
                    };
                    customer = tempCustomer;
                }
            }
            Connection.Close();
            return customer;
        }

        public Customer GetCustomer(string firstname, string lastname)
        {
            Connection.Open();
            string sql = "Select CustomerId, Firstname, Lastname, Country, PostalCode, Phone, Email from Customer where FirstName like @firstname and LastName like @lastname ";
            Customer customer = new Customer();

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                command.Parameters.AddWithValue("@firstname", "%" + firstname + "%");
                command.Parameters.AddWithValue("@lastname", "%" + lastname + "%");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Customer tempCustomer = new()
                    {
                        ID = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Country = reader.GetString(3),
                        PostalCode = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        Email = reader.GetString(6),
                    };
                    customer = tempCustomer;
                }
            }
            Connection.Close();
            return customer;
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
            Console.WriteLine("ølaksdaskøld");
        }
    }
}
