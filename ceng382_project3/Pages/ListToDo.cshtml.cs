using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ceng382_project3.Pages
{
    [Authorize]
    public class ListToDoModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public List<InputModel> Users { get; set; }

        public ListToDoModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            Users = new();
        }
        public IList<Appointments> Appoint { get; set; }

        //private IList<User> UserNames { get; set; }

        //public IList<User> Users { get; set; }

        

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string City { get; set; }

            [Required]
            [DataType(DataType.DateTime)]
            public DateTime DeadLine { get; set; }

            [Required]
            [DataType(DataType.DateTime)]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Address { get; set; }

        }
        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count != 0)
            {
                if (roles[0].ToString() == "Admin")
                {
                    Appoint = await _context.Appointments.ToListAsync();
                }
                // you can also check other roles
                // e.g. else if (roles[0].ToString() == "DatabseAdmin")
                // ...
            }
            else
            {

                var query = (from m in _context.Appointments
                             join dm in _context.Users on m.CustomerId equals dm.Id
                             where m.ServantId == userId
                             select new
                             {
                                 CustomerName = dm.FirstName,
                                 CustomerLastName = dm.LasName,
                                 CustomerCity = dm.City,
                                 CustomerPhone = dm.PhoneNumber,
                                 AppointmentDate = m.Deadline,
                                 AppointmentAddress = m.Address
                             }).ToList();

                foreach (var item in query)
                {
                    if (item.AppointmentDate < DateTime.Now.AddDays(30))
                    { 
                        InputModel Input = new InputModel();

                        Input.FirstName = item.CustomerName;
                        Input.LastName = item.CustomerLastName;
                        Input.City = item.CustomerCity;
                        Input.DeadLine = item.AppointmentDate;
                        Input.Address = item.AppointmentAddress;
                        Input.PhoneNumber = item.CustomerPhone;

                        Users.Add(Input);
                    }
                }

            }
        }
    }
}
