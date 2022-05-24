using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ceng382_project3.Data;
using ceng382_project3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ceng382_project3.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public List<SelectListItem> Cities { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "C", Text = "Choose City"},
            new SelectListItem {Value = "Ankara", Text = "Ankara"},
            new SelectListItem {Value = "İstanbul", Text = "İstanbul"},
            new SelectListItem {Value = "İzmir", Text = "İzmir"},
        };

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        [BindProperty]
        public Servants Servant { get; set; }

        public string Username { get; set; }

        public byte[] ProfilePicture { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    await FileUpload.FormFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length > 0 && memoryStream.ToArray() != user.Picture)
                    {
                        user.Picture = memoryStream.ToArray();

                        //var TaskFromDb = await _context.Servants.FindAsync(user.Id);
                        //TaskFromDb.Picture = memoryStream.ToArray();

                    }
                }
                catch (NullReferenceException)
                {

                }
            }
            if (Input.DOB != user.DOB)
            {
                user.DOB = Input.DOB;
            }
            if (Input.City != user.City)
            {
                user.City = Input.City;
            }
            if (Input.Email != user.Email)
            {
                user.Email = Input.Email;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
            }
            return RedirectToPage();
        }
    }
}
