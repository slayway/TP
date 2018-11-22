using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Document
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public byte[] FileData { get; set; }

        public int TaskId { get; set; }
    }
}
