using CarApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CarApplication.DAL
{
    public class CarModelContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<BrandModel> BrandModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}