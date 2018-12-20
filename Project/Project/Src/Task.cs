using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime PlanedImpDate { get; set; }
        public DateTime? ActualImpDate { get; set; }
        public String Status { get; set; }
        public int ProjectId { get; set; }
        public int CreatorId { get; set; }
        public int ExecutorId { get; set; }
        
    }
}
