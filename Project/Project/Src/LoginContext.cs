using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project
{
    public class LoginContext : DbContext
    {
        public LoginContext() : base("DbConnection")
        {
            Database.SetInitializer<LoginContext>(new CreateDatabaseIfNotExists<LoginContext>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
   
    }
}
