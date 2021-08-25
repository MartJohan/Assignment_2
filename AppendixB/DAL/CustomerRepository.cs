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
            string sql = "Insert into Customer (FirstName, LastName, Country, PostalCode, Phone, Email)" +
                "Values (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
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
                Connection.Close();
            }
        }

        /// <summary>
        /// Returns a list of type CustomerCountry containing the amount of people in each country
        /// </summary>
        public IEnumerable<CustomerCountry> CountCustomersPerCountry()
        {
            try
            {
                string sql = "SELECT COUNT(CustomerId) AS Amount, Country FROM Customer GROUP BY Country ORDER BY Amount DESC";
                List<CustomerCountry> CountryOccuranceList = new List<CustomerCountry>();
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerCountry customerCountry = new()
                            {
                                CustomerCount = reader.GetInt32(0),
                                Country = reader.GetString(1),
                            };
                            CountryOccuranceList.Add(customerCountry);
                        }
                    }
                    Connection.Close();
                }
                return CountryOccuranceList;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Takes in an id and finds the appropriate customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An object of type Customer</returns>
        public Customer GetCustomer(int id)
        {
            try
            {
                string sql = "SELECT CustomerId, Firstname, Lastname, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId LIKE @id";
                Customer customer = new Customer();


                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    Connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
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
                    Connection.Close();
                }
                return customer;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Takes in the firstname and lastname of a customer and tries to find him/her
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>Returns a Customer object of specified customer</returns>
        public Customer GetCustomer(string firstname, string lastname)
        {
            try
            {
                string sql = "SELECT CustomerId, Firstname, Lastname, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @firstname AND LastName LIKE @lastname ";
                Customer customer = new Customer();

                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    Connection.Open();
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
                    Connection.Close();
                }
                return customer;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public CustomerGenre GetMostPopularGenreForCustomer(Customer customer)
        {
            //For a given customer find their most popular genre, which means the genre that with the most tracks in the Invoice table
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerSpender> GetTopSpenders()
        {
            try
            {
                string sql = "SELECT Customer.FirstName, Customer.LastName, SUM(Invoice.Total) as Money_Spent" +
                " from Invoice " +
                "INNER JOIN Customer ON Invoice.CustomerId = Customer.CustomerId" +
                "  GROUP BY Customer.FirstName, Customer.LastName Order BY Money_Spent desc";

                List<CustomerSpender> list = new List<CustomerSpender>();

                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerSpender customer = new()
                            {
                                CustomerFirstname = reader.GetString(0),
                                CustomerLastname = reader.GetString(1),
                                TotalAmount = reader.GetDecimal(2),
                            };
                            list.Add(customer);
                        }
                    }
                    Connection.Close();
                }
                return list;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<CustomerSpender> GetTopSpenders(int limit)
        {
            try
            {
                string sql = "SELECT TOP (@limit) Customer.FirstName, Customer.LastName, SUM(Invoice.Total)" +
                " as Money_Spent from Invoice INNER JOIN Customer ON" +
                " Invoice.CustomerId = Customer.CustomerId GROUP BY Customer.FirstName, Customer.LastName" +
                " Order BY Money_Spent desc";

                List<CustomerSpender> list = new List<CustomerSpender>();
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    Connection.Open();
                    command.Parameters.AddWithValue("@limit", limit);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerSpender customer = new()
                            {
                                CustomerFirstname = reader.GetString(0),
                                CustomerLastname = reader.GetString(1),
                                TotalAmount = reader.GetDecimal(2),
                            };
                            list.Add(customer);
                        }
                    }
                    Connection.Close();
                }
                return list;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            Customer customer;
            
            string sql = "Select * from Customer";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
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
                Connection.Close();
            }
            return customerList;
        }

        public IEnumerable<Customer> ReadCustomersInRange(int offset, int limit)
        {
            List<Customer> customerList = new List<Customer>();
            Customer customer;
            
            string sql = "Select * from Customer ORDER BY CustomerId ASC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
            Console.WriteLine(sql);

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
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
                Connection.Close();
            }
            return customerList;
        }

        public void UpdateCustomer(Customer customer, CustomerKeys[] keys, string[] values)
        {
            if(keys.Length != values.Length)
            {
                throw new ArgumentException("Keys and string need to be the same size");
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < keys.Length; i++)
            {
                string updateSubString = keys[i] + "= '" + values[i] + "',";
                stringBuilder.Append(updateSubString);
            }
            //Remove trailing comma
            stringBuilder.Length--;

            string sql = "UPDATE Customer SET " + stringBuilder.ToString() + "WHERE CustomerID = " + customer.ID;
            Console.WriteLine(sql);

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
<<<<<<< HEAD
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
                Connection.Close();

=======
                command.ExecuteNonQuery();
                Connection.Close();
>>>>>>> development_tien
            }


        }
    }
}
