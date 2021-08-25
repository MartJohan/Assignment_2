using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.Models
{
    public class CustomerSpender
    {
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
