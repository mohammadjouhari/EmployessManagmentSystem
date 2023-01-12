using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DBContext : DbContext
    {
        public DBContext() 
        { 
        
        }

        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"server=.;database=EmployeesManagmentSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
