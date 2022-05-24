using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ceng382_project3.Models
{
    public class Servants
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LasName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        [PersonalData]
        public string City { get; set; }

        [PersonalData]
        public string Job { get; set; }

        [PersonalData]
        public string Description { get; set; }

        [PersonalData]
        public byte[] Picture { get; set; }

        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }

        public int Rating { get; set; }

    }
}
