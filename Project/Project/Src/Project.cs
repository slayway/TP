using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Project
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        public int CustomerId { get; set; }
        public int TaskId { get; set; }
       
        public int WorkingGroupId { get; set; }
    }
}
