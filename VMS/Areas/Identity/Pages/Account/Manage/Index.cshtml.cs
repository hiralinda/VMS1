﻿using System;
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
            public string NonprofitName { get; set; }

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
            public string School { get; set; }

            public bool IsStudent { get; set; }

            public DateTime Dob { get; set; }

            public int Age {get; set;}

            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

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
            var address = user.Address;
            var zip = user.Zip;
            var school = user.School;
            var isStudent = user.IsStudent;
            var doB = user.Birthdate;
            var today = DateTime.Today;
            var age = today.Year - doB.Year;
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                NonprofitName = nonprofitName,
                School = school,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
                Address = address,
                Zip = zip,
                Dob = doB,
                Age = age,
                UserName = userName,
                Email = email
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

            var school = user.School;
            var nonprofitName = user.OrganizationName;
            var isStudent = user.IsStudent;
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;
            var address = user.Address;
            var zip = user.Zip;
            var userName = user.UserName;
            var email = user.Email;

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
                user.Address = Input.Address;
                await _userManager.UpdateAsync(user);
            }

            if (Input.School != school)
            {
                user.School = Input.School;
                await _userManager.UpdateAsync(user);
            }

            if (Input.IsStudent != isStudent)
            {
                user.IsStudent = Input.IsStudent;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Zip != zip)
            {
                user.Zip = Input.Zip;
                await _userManager.UpdateAsync(user);
            }

            if (Input.NonprofitName != nonprofitName)
            {
                user.OrganizationName = Input.NonprofitName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.UserName != userName)
            {
                user.UserName = Input.UserName;
                await _userManager.UpdateAsync(user);
            }

            var emailAddress = await _userManager.GetEmailAsync(user);
            if (Input.Email != emailAddress)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set email address.";
                    return RedirectToPage();
                }
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
