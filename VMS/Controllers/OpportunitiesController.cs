using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VMS.Data;
using VMS.Models;
using VMS.Models.ViewModels;

namespace VMS.Controllers
{    
    public class OpportunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opportunities // Managing Opportunities
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Opportunity.Where(t => t.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync());


            /*return View(await _context.Opportunity.Include(t => t.CreateUser).ToListAsync());

            return View(await _context.Opportunity.Where(t => t.CreateUser.FirstName == User.Identity.Name).ToListAsync());*/


        }


        // GET: Opportunities // browse
        public async Task<IActionResult> Browse()
        {
            return View(await _context.Opportunity.ToListAsync());
        }

        // GET: Opportunities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }
        
        // GET: Opportunities/PublicDetails/5
        public async Task<IActionResult> PublicDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity.Include(t => t.CreateUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // GET: Opportunities/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Opportunities/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Browse", await _context.Opportunity.Where( j => j.OpportunityName.Contains(SearchPhrase)).ToListAsync());
        }

        // POST: Opportunities/MostRecent
        public async Task<IActionResult> Recent()
        {
            return View("Index", await _context.Opportunity.OrderByDescending(s => s.CreateDate).Include(t => t.CreateUser).ToListAsync());
        }

        // POST: Opportunities/MostRecent
        public async Task<IActionResult> BrowseRecent()
        {
            return View("Browse", await _context.Opportunity.OrderByDescending(s => s.CreateDate).ToListAsync());
        }

        public async Task<IActionResult> ReverseAlphabetical()
        {
            return View("Index", await _context.Opportunity.OrderByDescending(s => s.OpportunityName).ToListAsync());
        }

        public async Task<IActionResult> BrowseReverseAlphabetical()
        {
            return View("Browse", await _context.Opportunity.OrderByDescending(s => s.OpportunityName).ToListAsync());
        }

        // GET: Application
        [Authorize]
        public async Task<IActionResult> Apply(Application application, int? oppID)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Id();
                application.volunteer = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
                application.opportunity = await _context.Opportunity.FindAsync(oppID);

                application.oppName = application.opportunity.OpportunityName;
                application.volunteerName = application.volunteer.FirstName + " " + application.volunteer.LastName;
                application.oppDate = application.opportunity.StartDate.ToString() + " - " + application.opportunity.EndDate.ToString();
                application.oppLocation = application.opportunity.City + ", " + application.opportunity.State + ", " + application.opportunity.Zip + " at " +
                    application.opportunity.Address1 + " " + application.opportunity.Address2;

                _context.Add(application);
                await _context.SaveChangesAsync();
                TempData["message"] = $"Application successful!";
                return RedirectToAction(nameof(Browse));
            }
            return View(application);
        }

        // GET: Opportunities/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,StartDate,EndDate,CreateDate")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Id();
                opportunity.CreateDate = DateTime.UtcNow;
                opportunity.CreateUser = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                TempData["message"] = $"Created!";
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }


        // GET: Opportunities1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity.FindAsync(id);
            if (opportunity == null)
            {
                return NotFound();
            }
            return View(opportunity);
        }

        
        // POST: Opportunities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,StartDate,EndDate,CreateDate")] Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    opportunity.CreateDate = DateTime.UtcNow;
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                    TempData["message"] = $"Changes saved!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }



        // GET: Opportunities/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunity.FindAsync(id);
            _context.Opportunity.Remove(opportunity);
            await _context.SaveChangesAsync();
            TempData["message"] = $"Successfully Deleted!";
            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunity.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ViewApplications()
        {

            return View(await _context.Application.Where(t => t.volunteer.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync());

        }

        public async Task<IActionResult> ManageApplicants()
        {

            return View(await _context.Application.Where(t => t.opportunity.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync());

        }

    }
}
