using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VMS.Data;
using VMS.Models;

namespace VMS.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opportunities
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Opportunity.ToListAsync());
        }

        // GET: Opportunities
        [Authorize]
        public async Task<IActionResult> Browse()
        {
            return View(await _context.Opportunity.ToListAsync());
        }

        // GET: detailsfake
        [Authorize]
        public async Task<IActionResult> Detailsfake()
        {
            return View(await _context.Opportunity.ToListAsync());
        }

        // GET: Application
        [Authorize]
        public async Task<IActionResult> Apply()
        {
            return View(await _context.Opportunity.ToListAsync());
        }

        // GET: Opportunities/ShowSearchForm
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Opportunities/ShowSearchResults
        [Authorize]
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Opportunity.Where( j => j.opportunityName.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Opportunities/Details/5
        [Authorize]
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

        // GET: Opportunities/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,opportunityName,center,datePosted")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                TempData["message"] = $"Created!";
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,opportunityName,center,datePosted")] Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    TempData["message"] = $"Changes Saved!";
                    await _context.SaveChangesAsync();
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
    }
}
