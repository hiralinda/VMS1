using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.Domain;
using VMS.Services;

namespace VMS.Areas.Identity.Pages.Account.Manage.Notifications
{

    public class IndexModel : PageModel
    {

        private readonly INotificationService _notificationService;

        public IList<Interest> Interests { get; private set; }

        public IndexModel(INotificationService notificationService)
        {
            _notificationService = notificationService;

            Interests = new List<Interest>();
        }

        public async Task OnGet()
        {
            Interests = await _notificationService.ListAll();
        }
    }
}
