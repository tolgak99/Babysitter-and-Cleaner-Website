using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ceng382_project3.Models
{
    public class User : IdentityUser
    {
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
        public float Budget { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [PersonalData]
        public byte[] Picture { get; set; }
    }
}
