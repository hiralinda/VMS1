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
using Microsoft.Extensions.Logging;
using VMS.Models;

namespace VMS.Areas.Identity.Pages.Account.Manage
{
    public class AboutYouModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public AboutYouModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Display(Name = "About You")]
            public string AboutYou { get; set; }

            [Display(Name = "Your Mission Statement")]
            public string MissionStatement { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var AboutYou = user.AboutYou;
            var MissionStatement = user.MissionStatement;
            Input = new InputModel
            {
                AboutYou = AboutYou,
                MissionStatement = MissionStatement
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

            var AboutYou = user.AboutYou;
            var MissionStatement = user.MissionStatement;


            if(Input.AboutYou != AboutYou)
            {
                user.AboutYou = Input.AboutYou;
                await _userManager.UpdateAsync(user);
            }

            if (Input.MissionStatement != MissionStatement)
            {
                user.MissionStatement = Input.MissionStatement;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";

            return RedirectToPage();
        }
        
        /*public void OnGet()
        {
        }*/
    }
}
