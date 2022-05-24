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
    public class AddRatingModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public string Rate { get; set; }

        [BindProperty]
        public bool isAlreadyRated { get; set; }

        public Servants Servant { get; set; }


        [BindProperty]
        public string RatedUSERID { get; set; }

        public IList<Servants> Servants { get; set; }

        public IList<UserRating> isRated { get; set; }

        public AddRatingModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGet(string ratedUserID)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            RatedUSERID = ratedUserID;
            Servants = await _context.Servants.Where(u => u.UserId.Equals(RatedUSERID)).ToListAsync();
            isRated = await _context.UserRatings.Where(u => u.whoRated.Equals(userId)).Where(t => t.userId.Equals(RatedUSERID)).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var userRating = new UserRating();

            userRating.Rating = Convert.ToInt32(Rate);
            userRating.userId = RatedUSERID;
            userRating.whoRated = userId;

            Servants = await _context.Servants.Where(u => u.UserId.Equals(RatedUSERID)).ToListAsync();
            isRated = await _context.UserRatings.Where(t => t.userId.Equals(RatedUSERID)).ToListAsync();

            if (Servants[0].Rating == 0)
                Servants[0].Rating = Convert.ToInt32(Rate);
            else
                Servants[0].Rating = (Servants[0].Rating + Convert.ToInt32(Rate)) / (isRated.Count + 1);

            await _context.UserRatings.AddAsync(userRating);
            await _context.SaveChangesAsync();
            return RedirectToPage("./BabySitterList");
        }
    }
}
