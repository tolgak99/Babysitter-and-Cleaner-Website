using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ceng382_project3.Pages
{
    [Authorize(Roles="Admin")]
    public class AprroveToDoModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AprroveToDoModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IList<ToDo> Todos { get; set; }

        public IList<Servants> Servants { get; set; }

        [BindProperty]
        public ToDo Todo { get; set; }

        [BindProperty]
        public Servants Servant { get; set; }
        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles[0].ToString() == "Admin")
            {
                Servants = await _context.Servants.ToListAsync();
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var TaskFromDb = await _context.Servants.FindAsync(Servant.Id);
            if (TaskFromDb.IsApproved == false)
                TaskFromDb.IsApproved = true;
            else
                TaskFromDb.IsApproved = false;
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
