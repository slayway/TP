using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project
{
    public class ProjectRole
    {
        public int Id { get; set; }
        public String PJRole { get; set; }
        public int? Accesslvl { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
        
       // public ProjectRole()
        //{
          //  Employees = new List<Employee>();
       // }
    }
}
