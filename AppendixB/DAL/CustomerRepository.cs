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
            Connection.Open();
            string sql = "Insert into Customer (FirstName, LastName, Country, PostalCode, Phone, Email)" +
                "Values (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@FirstName", customer.Firstname);
                    command.Parameters.AddWithValue("@LastName", customer.Lastname);
                    command.Parameters.AddWithValue("@Country", customer.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PostalCode", customer.PostalCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", customer.PhoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Customer needs first name, last name, and email!");
                }

            }
            
            Connection.Close();
        }

        public IEnumerable<Customer> CountCustomersPerCountry()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            Connection.Open();
            string sql = "Select * from Customer where CustomerId = {id}";

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
            List<Customer> customerList = new List<Customer>();
            Customer customer;
            Connection.Open();
            string sql = "Select * from Customer";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine($"{reader.GetName(0)}  {reader.GetName(1)}");

                    while (reader.Read())
                    {

                        customer = new Customer {
                            Firstname = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Lastname = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Country = reader.IsDBNull(7) ? null : reader.GetString(7),
                            PostalCode = reader.IsDBNull(8) ? null : reader.GetString(8),
                            PhoneNumber = reader.IsDBNull(9) ? null : reader.GetString(9),
                            Email = reader.IsDBNull(11) ? null : reader.GetString(11)

                        };

                        customerList.Add(customer);
                        
                    }
                }
            }
            Connection.Close();
            return customerList;
        }

        public IEnumerable<Customer> ReadCustomersInRange(int offset, int limit)
        {
            List<Customer> customerList = new List<Customer>();
            Customer customer;
            Connection.Open();
            string sql = "Select * from Customer ORDER BY CustomerId ASC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
            Console.WriteLine(sql);

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@limit", limit);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine($"{reader.GetName(0)}  {reader.GetName(1)}");

                    while (reader.Read())
                    {

                        customer = new Customer
                        {
                            Firstname = reader.GetString(1),
                            Lastname = reader.GetString(2),
                            Country = reader.IsDBNull(7) ? null : reader.GetString(7),
                            PostalCode = reader.IsDBNull(8) ? null : reader.GetString(8),
                            PhoneNumber = reader.IsDBNull(9) ? null : reader.GetString(9),
                            Email = reader.GetString(11)

                        };

                        customerList.Add(customer);

                    }
                }
            }
            Connection.Close();
            return customerList;
        }

        public void UpdateCustomer(Customer customer, CustomerKeys[] keys, string[] values)
        {
            if(keys.Length != values.Length)
            {
                throw new ArgumentException("Keys and string need to be the same size");
            }
            Connection.Open();
            //TODO Finish method
            string sql = "UPDATE Customers SET ";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@FirstName", customer.Firstname);
                    command.Parameters.AddWithValue("@LastName", customer.Lastname);
                    command.Parameters.AddWithValue("@Country", customer.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PostalCode", customer.PostalCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", customer.PhoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Customer needs first name, last name, and email!");
                }

            }

            Connection.Close();
        }
    }
}
