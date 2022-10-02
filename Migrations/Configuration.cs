using SingularStaffOrders.Models.MyDBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = "Migrations";
        }

        protected override void Seed(DatabaseContext context)
        {}
    }
}