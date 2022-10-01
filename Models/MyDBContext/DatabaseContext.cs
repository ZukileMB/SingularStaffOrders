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

        }
        public virtual DbSet<Products> Products { get; set; }
    }
}
