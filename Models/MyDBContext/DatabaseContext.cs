using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models.MyDBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("MycontextDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
