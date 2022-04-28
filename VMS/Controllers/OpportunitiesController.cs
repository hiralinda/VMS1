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
        public int PageSize = 15;

        public OpportunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*GET: Opportunities browse method*/
        public ActionResult List(string searchString, string sortOrder, int page = 1)
        {
            /*Main Filters*/
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date" : "Date";

            ViewBag.VirtualSortParm = sortOrder == "Virtual" ? "Virtual" : "Virtual";
            ViewBag.InPersonSortParm = sortOrder == "InPerson" ? "In Person" : "InPerson";
            ViewBag.OngoingSortParm = sortOrder == "Ongoing" ? "Ongoing" : "Ongoing";
            ViewBag.OneDaySortParm = sortOrder == "OneDay" ? "One Day" : "OneDay"; 
            ViewBag.InternSortParm = sortOrder == "Internship" ? "Internship" : "Internship";
            ViewBag.GroupSortParm = sortOrder == "Group" ? "Group" : "Group";
            ViewBag.IndividualSortParm = sortOrder == "Individual" ? "Individual" : "Individual";

            /*Category Sorts*/
            ViewBag.AnimalSortParm = sortOrder == "Animals" ? "animals" : "Animals";
            ViewBag.AdvHumSortParm = sortOrder == "Advocacy and Human Rights" ? "Advocacy and Human Rights" : "Advocacy and Human Rights";
            ViewBag.SuppTroopsParm = sortOrder == "Support our troops" ? "Support our troops" : "Support our troops";
            ViewBag.ComSickSortParm = sortOrder == "Comfort the sick" ? "Comfort the sick" : "Comfort the sick";
            ViewBag.SavePlanetParm = sortOrder == "Save the Planet" ? "Save the Planet" : "Save the Planet";
            ViewBag.HomelessParm = sortOrder == "Homeless" ? "Homeless" : "Homeless";
            ViewBag.CommunitySortParm = sortOrder == "Community Support" ? "Community Support" : "Community Support";
            ViewBag.HelpRefSortParm = sortOrder == "Help Refugees" ? "Help Refugees" : "Help Refugees";
            ViewBag.CompTechSortParm = sortOrder == "Computers & Technology" ? "Computers & Technology" : "Computers & Technology";
            ViewBag.DonationSortParm = sortOrder == "Donations" ? "Donations" : "Donations";
            ViewBag.EduLitSortParm = sortOrder == "Education & Literacy" ? "Education & Literacy" : "Education & Literacy";
            ViewBag.ElderlySortParm = sortOrder == "Elderly" ? "Elderly" : "Elderly";
            ViewBag.HelpKidsSortParm = sortOrder == "Help other kids" ? "Help other kids" : "Help other kids";


            if (!String.IsNullOrEmpty(searchString))
            {
                return View(new OpportunitiesListViewModel
                {
                    Opportunities = _context.Opportunity.Where(s => s.OpportunityName.Contains(searchString) || s.City.Contains(searchString) || s.State.Contains(searchString) || s.Zip.Contains(searchString) || s.Description.Contains(searchString))
                    .Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.OpportunityName.Contains(searchString) || s.City.Contains(searchString) || s.State.Contains(searchString) || s.Zip.Contains(searchString) || s.Description.Contains(searchString)).Count()
                    }

                });
                
            }

            return sortOrder switch
            {
                "Virtual" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.Virtual && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.Virtual && !s.ArchivedStatus).Count()
                    }
                }),
                "InPerson" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => !s.Virtual && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => !s.Virtual && !s.ArchivedStatus).Count()
                    }
                }),
                "Group" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.GroupActivity && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.GroupActivity && !s.ArchivedStatus).Count()
                    }
                }),
                "Individual" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => !s.GroupActivity && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => !s.GroupActivity && !s.ArchivedStatus).Count()
                    }
                }),
                "OneDay" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.TypeOfOpportunity == "One Day" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.TypeOfOpportunity == "One Day" && !s.ArchivedStatus).Count()
                    }
                }),
                "Internship" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.TypeOfOpportunity == "Summer Internship" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.TypeOfOpportunity == "Summer Internship" && !s.ArchivedStatus).Count()
                    }
                }),
                "Ongoing" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.OnGoing && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.OnGoing && !s.ArchivedStatus).Count()
                    }
                }),
                "Date" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.StartDate).Where(s => !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => !s.ArchivedStatus).Count()
                    }
                }),
                "Animals" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Animals" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Animals" && !s.ArchivedStatus).Count()
                    }
                }),
                "Support our troops" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Support our troops" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Support our troops" && !s.ArchivedStatus).Count()
                    }
                }),
                "Advocacy and Human Rights" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Advocacy and Human Rights" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Advocacy and Human Rights" && !s.ArchivedStatus).Count()
                    }
                }),
                "Comfort the sick" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Comfort the sick" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Comfort the sick" && !s.ArchivedStatus).Count()
                    }
                }),
                "Save the Planet" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Save the Planet" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Save the Planet" && !s.ArchivedStatus).Count()
                    }
                }),
                "Homeless" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Homeless" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Homeless" && !s.ArchivedStatus).Count()
                    }
                }),
                "Community Support" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Community Support" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Community Support" && !s.ArchivedStatus).Count()
                    }
                }),
                "Help Refugees" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Help Refugees" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Help Refugees" && !s.ArchivedStatus).Count()
                    }
                }),
                "Computers & Technology" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Computers & Technology" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Computers & Technology" && !s.ArchivedStatus).Count()
                    }
                }),
                "Donations" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Donations" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Donations" && !s.ArchivedStatus).Count()
                    }
                }),
                "Education & Literacy" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Education & Literacy" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Education & Literacy" && !s.ArchivedStatus).Count()
                    }
                }),
                "Elderly" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Elderly" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Elderly" && !s.ArchivedStatus).Count()
                    }
                }),
                "Help other kids" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Help other kids" && !s.ArchivedStatus).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Help other kids" && !s.ArchivedStatus).Count()
                    }
                }),
                _ => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.Where(t => !t.ArchivedStatus).OrderByDescending(p => p.CreateDate).Skip((page - 1) * PageSize).Take(PageSize) ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => !s.ArchivedStatus).Count()
                    }
                }),
            };
        }

        // GET: Opportunities // Managing Opportunities
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            /*Original */
            /*return View(await _context.Opportunity.Where(t => t.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync());*/
            
            /*Pagination*/
            return View(new OpportunitiesListViewModel
            {

                Opportunities = _context.Opportunity.Where(t => (!t.ArchivedStatus) && t.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _context.Opportunity.Where(t => (!t.ArchivedStatus) && t.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).Count()
                }
            });
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
            return View("List", await _context.Opportunity.OrderByDescending(s => s.CreateDate).ToListAsync());
        }

        public async Task<IActionResult> ReverseAlphabetical()
        {
            return View("Index", await _context.Opportunity.OrderByDescending(s => s.OpportunityName).ToListAsync());
        }

        public async Task<IActionResult> BrowseReverseAlphabetical()
        {
            return View("List", await _context.Opportunity.OrderByDescending(s => s.OpportunityName).ToListAsync());
        }

        // GET: Application
        [Authorize]
        public async Task<IActionResult> Apply(Application application, int? oppID)
        {
            if (_context.Application.Where(t => (t.volunteer.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) && (t.opportunity.Id == oppID)).ToList().Any())
            {
                TempData["message"] = $"You have already applied to this opportunity!";
                return RedirectToAction(nameof(List));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Id();
                    application.volunteer = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
                    application.opportunity = await _context.Opportunity.FindAsync(oppID);
                    
                    application.oppName = application.opportunity.OpportunityName;
                    application.oppID = application.opportunity.Id;
                    application.volsNeeded = application.opportunity.VolunteersNeeded;
                    application.volunteerName = application.volunteer.FirstName + " " + application.volunteer.LastName;
                    application.oppDate = application.opportunity.StartDate.Date.ToString("d") + " - " + application.opportunity.EndDate.Date.ToString("d");
                    application.oppTime = application.opportunity.StartTime.ToShortTimeString() + " - " + application.opportunity.EndTime.ToShortTimeString();
                    application.oppLocation = application.opportunity.City + ", " + application.opportunity.State + ", " + application.opportunity.Zip + " at " +
                        application.opportunity.Address1 + " " + application.opportunity.Address2;

                    /*try - this info wasnt pulling from the volunteer property in application so I added in here*/
                    application.AboutYou = application.volunteer.AboutYou;
                    application.InstagramLink = application.volunteer.InstagramLink;
                    application.FacebookLink = application.volunteer.FacebookLink;
                    application.TwitterLink = application.volunteer.TwitterLink;
                    application.OtherWebsite = application.volunteer.OtherWebsite;
                    application.School = application.volunteer.OtherWebsite;


                    _context.Add(application);
                    await _context.SaveChangesAsync();
                    TempData["message"] = $"Application successful!";
                    return RedirectToAction(nameof(List));
                }
            }

            return RedirectToAction(nameof(List));
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
        public async Task<IActionResult> Create([Bind("Id,VolunteersNeeded,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,AgeBracket,GradeLevel,InterestAreas,TypeOfOpportunity,Virtual,GroupActivity,OnGoing,StartDate,StartTime,EndDate,EndTime,CreateDate,CompanyLogo")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Id();
                opportunity.VolunteersApplied = 0;
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,VolunteersNeeded,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,AgeBracket,GradeLevel,InterestAreas,TypeOfOpportunity,Virtual,GroupActivity,OnGoing,StartDate,StartTime,EndDate,EndTime,CreateDate,CompanyLogo")] Opportunity opportunity)
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

            return View(await _context.Application.Where(t => t.volunteer.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value && !t.opportunity.ArchivedStatus).ToListAsync());

        }

        public async Task<IActionResult> ManageApplicants()
        {

            List<Application> applications = await _context.Application.Where(t => t.opportunity.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value && !t.opportunity.ArchivedStatus).OrderByDescending(t => t.oppName).ToListAsync();

            return View(applications);
        }


        [HttpPost]
        public async Task<IActionResult> ApproveApplicant(int ApplicationID, Application application, Opportunity opportunity)
        {
            if(ModelState.IsValid)
            {
                application = await _context.Application.FindAsync(ApplicationID);
                opportunity = await _context.Opportunity.FindAsync(application.oppID);
                int volunteersSignedUp = opportunity.VolunteersApplied;

                if(volunteersSignedUp < opportunity.VolunteersNeeded)
                {
                    if (application.status == true)
                    {
                        application.status = false;
                        volunteersSignedUp--;
                        opportunity.VolunteersApplied = volunteersSignedUp;
                    }
                    else
                    {
                        application.status = true;
                        volunteersSignedUp++;
                        opportunity.VolunteersApplied = volunteersSignedUp;
                    }
                }
                else
                {
                    if (application.status == true)
                    {
                        application.status = false;
                        volunteersSignedUp--;
                        opportunity.VolunteersApplied = volunteersSignedUp;
                    }
                    else
                    {
                        TempData["message"] = $"This opportunity is full!";
                    }
                }

                _context.Update(application);
                _context.Update(opportunity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ManageApplicants));
            }

            return View(application);
        }

        [Authorize]
        [HttpPost, ActionName("withdrawApplication")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> withdrawApplication(int id, Opportunity opportunity)
        {

            var application = await _context.Application.FindAsync(id);
            opportunity = await _context.Opportunity.FindAsync(application.oppID);
            int volunteersSignedUp = opportunity.VolunteersApplied;
            if (application.status == true)
            {
                volunteersSignedUp--;
                opportunity.VolunteersApplied = volunteersSignedUp;
            }

            _context.Update(opportunity);
            _context.Application.Remove(application);
            
            await _context.SaveChangesAsync();
            TempData["message"] = $"Application withdrawn";
            return RedirectToAction(nameof(ViewApplications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveOpportunity(int id, [Bind("Id,VolunteersNeeded,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,AgeBracket,GradeLevel,InterestAreas,TypeOfOpportunity,Virtual,GroupActivity,OnGoing,StartDate,StartTime,EndDate,EndTime,CreateDate,CompanyLogo")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    opportunity.CreateDate = opportunity.CreateDate;
                    opportunity.ArchivedDate = DateTime.UtcNow;
                    opportunity.ArchivedStatus = true;
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                    TempData["message"] = $"Event moved to archives.";
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
            return RedirectToAction();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreOpportunity(int id, [Bind("Id,VolunteersNeeded,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,AgeBracket,GradeLevel,InterestAreas,TypeOfOpportunity,Virtual,GroupActivity,OnGoing,StartDate,StartTime,EndDate,EndTime,CreateDate,CompanyLogo")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    opportunity.CreateDate = DateTime.UtcNow;
                    opportunity.ArchivedStatus = false;
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                    TempData["message"] = $"Event no longer archived.";
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
            return RedirectToAction();
        }

        public async Task<IActionResult> ViewArchived(int page = 1)
        {

            return View(await _context.Opportunity.Where(t => (t.ArchivedStatus) && t.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync());
        }

        // GET: Opportunities/ViewOrg/5
        public async Task<IActionResult> ViewOrg(int? id)
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
            /*return View();*/
        }
    }
}
