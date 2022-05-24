using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ceng382_project3.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Task { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
    }
}
