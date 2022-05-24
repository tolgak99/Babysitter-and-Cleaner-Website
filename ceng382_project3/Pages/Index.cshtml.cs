using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ceng382_project3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IList<Servants> Servants { get; set; }

        public int ServantsCount { get; set; }

        public IndexModel(ILogger<IndexModel> logger, UserManager<User> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task OnGet()
        {
            Servants = await _context.Servants.Where(u => u.IsApproved.Equals(true))
                                              .Where(t => t.IsActive == true).ToListAsync();
            ServantsCount = Servants.Count;
        }
    }
}
