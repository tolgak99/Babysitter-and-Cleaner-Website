using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ceng382_project3.Pages
{
    [Authorize]
    public class CreateTodoModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateTodoModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public List<SelectListItem> Jobs { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "C", Text = "Choose Job"},
            new SelectListItem {Value = "Babysitter", Text = "Babysitter"},
            new SelectListItem {Value = "Housekeeper", Text = "Housekeeper"},
            new SelectListItem {Value = "Nany", Text = "Nany"},
        };

        [BindProperty]
        public ToDo Todo { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public string Username { get; set; }

        public byte[] ProfilePicture { get; set; }
        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "LastName")]
            public string LasName { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Birth Date")]
            public DateTime DOB { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "City")]
            public string City { get; set; }


            [Display(Name = "Profile Picture")]
            public byte[] Picture { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            ProfilePicture = user.Picture;
            Input = new InputModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LasName = user.LasName,
                DOB = user.DOB,
                City = user.City,
                PhoneNumber = phoneNumber
            };

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            Todo.IsActive = true;
            Todo.IsApproved = false;
            Todo.Timestamp = DateTime.Now;

            Todo.UserId = userId;
            _context.ToDos.Add(Todo);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
