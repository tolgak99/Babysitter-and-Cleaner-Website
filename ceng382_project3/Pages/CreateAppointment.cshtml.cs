using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ceng382_project3.Pages
{
    public class CreateAppointmentModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateAppointmentModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public string RatedUSERID { get; set; }

        [BindProperty]
        public DateTime DueDate { get; set; }

        [BindProperty]
        public string Address { get; set; }

        public IList<Servants> Servants { get; set; }

        public IList<User> Users { get; set; }

        public async Task OnGet(string ratedUserID)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            RatedUSERID = ratedUserID;
            Servants = await _context.Servants.Where(u => u.UserId.Equals(RatedUSERID)).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            Servants = await _context.Servants.Where(u => u.UserId.Equals(RatedUSERID)).ToListAsync();

            Users = await _context.Users.Where(u => u.Id.Equals(userId)).ToListAsync();

            var userAppo = new Appointments();

            userAppo.ServantId = RatedUSERID;
            userAppo.CustomerId = userId;
            userAppo.IsActive = true;
            userAppo.Task = Servants[0].Job;
            userAppo.Deadline = DueDate;
            userAppo.Address = Address;

            if (Users[0].Budget > 50)
            {
                Users[0].Budget -= 50;
                await _context.Appointments.AddAsync(userAppo);
                await _context.SaveChangesAsync();
                return RedirectToPage("./BabySitterList");
            }
            else
            {
                return RedirectToPage("./Checkout");
            }
        }

    }
}
