using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ceng382_project3.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public string ServantId { get; set; }
        public string CustomerId { get; set; }
        public string Task { get; set; }
        public DateTime Deadline { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
