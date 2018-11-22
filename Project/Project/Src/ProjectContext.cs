using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("DbConnection")
        {
            Database.SetInitializer<ProjectContext>(new CreateDatabaseIfNotExists<ProjectContext>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<WorkingGroup> WorkingGroups { get; set; }
        public DbSet<Project> Projects { get; set; }
   
    }
}
