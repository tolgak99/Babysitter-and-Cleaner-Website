using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ceng382_project3.Models
{
    public class UserRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string userId { get; set; }
        public string whoRated { get; set; }
    }
}
