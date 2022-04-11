using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.Models;

namespace VMS.Areas.Identity.Pages.Account.Manage
{
    public class SocialLinksModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SocialLinksModel(
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
            [Display(Name = "Instagram")]
            public string Instagram { get; set; }

            [Display(Name = "Facebook")]
            public string Facebook { get; set; }

            [Display(Name = "Twitter")]
            public string Twitter { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var instagram = user.InstagramLink;
            var facebook = user.FacebookLink;
            var twitter = user.TwitterLink;

            Input = new InputModel
            {
                Instagram = instagram,
                Facebook = facebook,
                Twitter = twitter
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

            var instagram = user.InstagramLink;
            var facebook = user.FacebookLink;
            var twitter = user.TwitterLink;

            if(Input.Instagram != instagram)
            {
                user.InstagramLink = Input.Instagram;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Facebook != facebook)
            {
                user.FacebookLink = Input.Facebook;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Twitter != twitter)
            {
                user.TwitterLink = Input.Twitter;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
