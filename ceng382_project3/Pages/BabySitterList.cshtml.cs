using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ceng382_project3.Pages
{
    public class BabySitterListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public BabySitterListModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<ToDo> Todos { get; set; }

        public IList<Servants> Babysitters { get; set; }

        public string Username { get; set; }

        public byte[] ProfilePicture { get; set; }

        public bool HasSearch { get; set; }

        [BindProperty]
        public string ServantName { get; set; }

        [BindProperty]
        public string ServantJob { get; set; }

        [BindProperty]
        public string ServantCity { get; set; }

        public List<Servants> SearchResult { get; set; }

        public List<SelectListItem> Jobs { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "C", Text = "Choose Job"},
            new SelectListItem {Value = "BabySitter", Text = "BabySitter"},
            new SelectListItem {Value = "Cleaner", Text = "Cleaner"},
            new SelectListItem {Value = "Nany", Text = "Nany"},
        };

        public List<SelectListItem> Cities { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "C", Text = "Choose City"},
            new SelectListItem {Value = "Ankara", Text = "Ankara"},
            new SelectListItem {Value = "Ýstanbul", Text = "Ýstanbul"},
            new SelectListItem {Value = "Ýzmir", Text = "Ýzmir"},
        };

        public List<Servants> Search(string task,
                        string priority)
        {
            var allTodos = _context.Servants.AsQueryable();

            if (!string.IsNullOrEmpty(task))
            {
                allTodos = allTodos.Where(x => x.Job.ToLower().Contains(task.ToLower()));
            }
            if (!string.IsNullOrEmpty(priority))
            {
                allTodos = allTodos.Where(x => x.City.Equals(priority));
            }


            return allTodos.ToList();
        }

        public async Task OnGetAsync(string task,
                       string priority)
        {

            ServantJob = task;
            ServantCity = priority;

            //Require all fields
            if (!string.IsNullOrEmpty(task) && !string.IsNullOrEmpty(priority))
            {
                HasSearch = true;
                SearchResult = Search(task, priority);
            }
            else
            { 

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 var user = await _userManager.FindByIdAsync(userId);

                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Count != 0)
                {
                    if (roles[0].ToString() == "Admin")
                    {
                        Babysitters = await _context.Servants.Where(u => u.IsApproved.Equals(true)).ToListAsync();
                    }
                    else 
                    {
                        Babysitters = await _context.Servants.Where(u => u.IsApproved.Equals(true))
                                                         .Where(t => t.IsActive == true).ToListAsync();
                    }
                    // you can also check other roles
                    // e.g. else if (roles[0].ToString() == "DatabseAdmin")
                    // ...
                }
                else
                {
                    //Todos = await _context.ToDos.Where(u => u.UserId.Equals(userId)).ToListAsync();
                    Babysitters = await _context.Servants.Where(u => u.IsApproved.Equals(true))
                                                         .Where(t => t.IsActive == true).ToListAsync();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RedirectToPage("./Index");
                //return Page();
            }

            return RedirectToPage("/BabySitterList", new
            {
                task = ServantJob,
                priority = ServantCity
            });
        }


    }
}
