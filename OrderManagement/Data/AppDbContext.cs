using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
 
        public DbSet<SOOrder> SOOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SOItem> SOItems { get; set; }  
    }
}
