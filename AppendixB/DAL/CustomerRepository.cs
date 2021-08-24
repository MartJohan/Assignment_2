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

        public IEnumerable<CustomerCountry> CountCustomersPerCountry()
        {
            Connection.Open();
            string sql = "SELECT COUNT(CustomerId) AS Amount, Country FROM Customer GROUP BY Country ORDER BY Amount DESC";
            List<CustomerCountry> CountryOccuranceList = new List<CustomerCountry>();
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        CustomerCountry customerCountry = new()
                        {
                            CustomerCount = reader.GetInt32(0),
                            Country = reader.GetString(1),
                        };
                        CountryOccuranceList.Add(customerCountry);
                    }
                }
            }
            Connection.Close();
            return CountryOccuranceList;
        }

        public Customer GetCustomer(int id)
        {
            Connection.Open();
            string sql = "SELECT CustomerId, Firstname, Lastname, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId LIKE @id";
            Customer customer = new Customer();

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Customer tempCustomer = new()
                    {
                        //reader.IsDBNull(x) ? null : reader.GetString(x)
                        ID = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Country = reader.IsDBNull(3) ? null : reader.GetString(3),
                        PostalCode = reader.IsDBNull(3) ? null : reader.GetString(4),
                        PhoneNumber = reader.IsDBNull(3) ? null : reader.GetString(5),
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
            string sql = "SELECT CustomerId, Firstname, Lastname, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @firstname AND LastName LIKE @lastname ";
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
                        Country = reader.IsDBNull(3) ? null : reader.GetString(3),
                        PostalCode = reader.IsDBNull(3) ? null : reader.GetString(4),
                        PhoneNumber = reader.IsDBNull(3) ? null : reader.GetString(5),
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
