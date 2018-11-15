using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project
{
    public class Employee
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }

        
        [ForeignKey("Accesslvl")]
        public Int32? accesslvl { get; set; }
        public ProjectRole Accesslvl { get; set; }
    }
}
