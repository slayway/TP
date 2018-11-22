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
        public DateTime DateOfCreation { get; set; }
        public DateTime PlannedImpDate { get; set; }
        public DateTime ActualImpDate { get; set; }

        public List<Document> Documents { get; set; }
    }
}
