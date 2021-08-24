using dotnetcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.DAL
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options){ }
    }
}
