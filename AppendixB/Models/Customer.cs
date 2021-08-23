using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.Models
{
    public class Customer
    {
        /*
        * Read all customers, display ID, firstname, lastname, country, postal code, phone number and email
        * Read specific customer by id, display everything listed above
        * Read a specific customer by name
        * Return a page of customers. take in limit and offset as parameters
        * Add a new customer with fields listed above
        * update a customer
        * return number of customers in each country in descending order
        * For a customer return their most popular genre
        */
        private int ID { get; set; }

        private string firstname { get; set; }

        private string lastname { get; set; }

        private CustomerCountry country { get; set; }

        private string postalCode { get; set; }

        private string phoneNumber { get; set; }

        private string email { get; set; }


    }
}
