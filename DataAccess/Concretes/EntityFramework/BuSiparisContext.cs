using Core.Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class BuSiparisContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BuSiparis;Trusted_Connection=true");
        }
        
        public DbSet<User> users { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<Service> service { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<ServiceCategory> serviceCategory { get; set; }
        public DbSet<MainServiceCategory> mainServiceCategory { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        
    }
}
