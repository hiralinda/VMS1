using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.Models;

namespace VMS.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Nonprofit Name")]
            public string nonprofitName { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Profile Picture")]
            public byte[] ProfilePicture { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Zip")]
            public string Zip { get; set; }

            [Display(Name = "School")]
            public string school { get; set; }

            public bool isStudent { get; set; }

            public DateTime dob { get; set; }

            public int Age {get; set;}

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var nonprofitName = user.OrganizationName;
            var profilePicture = user.ProfilePicture;
            var address = user.address;
            var zip = user.zip;
            var school = user.school;
            var isStudent = user.isStudent;
            var DoB = user.birthdate;
            var today = DateTime.Today;
            var age = today.Year - DoB.Year;
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                nonprofitName = nonprofitName,
                school = school,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
                Address = address,
                Zip = zip,
                dob = DoB,
                Age = age
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

            var school = user.school;
            var nonprofitName = user.OrganizationName;
            var isStudent = user.isStudent;
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;
            var address = user.address;
            var zip = user.zip;

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Address != address)
            {
                user.address = Input.Address;
                await _userManager.UpdateAsync(user);
            }

            if (Input.school != school)
            {
                user.school = Input.school;
                await _userManager.UpdateAsync(user);
            }

            if (Input.isStudent != isStudent)
            {
                user.isStudent = Input.isStudent;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Zip != zip)
            {
                user.zip = Input.Zip;
                await _userManager.UpdateAsync(user);
            }

            if (Input.nonprofitName != nonprofitName)
            {
                user.OrganizationName = Input.nonprofitName;
                await _userManager.UpdateAsync(user);
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

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
