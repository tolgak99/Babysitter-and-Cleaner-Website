using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ceng382_project3.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CreditCard { get; set; }
        public DateTime Time { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
