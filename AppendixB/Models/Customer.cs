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
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public CustomerCountry Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


    }
}
