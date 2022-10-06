using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using VMS.Infrastructure;
using AutoMapper;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace VMS.Controllers
{    
    public class OpportunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public int PageSize = 15;
        public int ManagePostsPageSize = 9;
        private Mapper Mapper = (Mapper) new MapperConfiguration(cfg => {
            cfg.CreateMap<CreateOpportunityViewModel, Opportunity>();
        }).CreateMapper();

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
            ViewBag.AdvHumSortParm = sortOrder == "Advocacy & Human Rights" ? "Advocacy & Human Rights" : "Advocacy & Human Rights";
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
            ViewBag.HelpKidsSortParm = sortOrder == "Help kids" ? "Help kids" : "Help kids";
            ViewBag.HungerSortParm = sortOrder == "Fighting Hunger" ? "Fighting Hunger" : "Fighting Hunger";

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(new OpportunitiesListViewModel
                {
                    Opportunities = _context.Opportunity.Where(s => s.OpportunityName.Contains(searchString) || s.City.Contains(searchString) || s.State.Contains(searchString) || s.Zip.Contains(searchString) || s.Description.Contains(searchString)).Where(s => !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing)
                    .Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.OpportunityName.Contains(searchString) || s.City.Contains(searchString) || s.State.Contains(searchString) || s.Zip.Contains(searchString) || s.Description.Contains(searchString) && !s.ArchivedStatus && s.EndDate >= DateTime.Today).Where(s => !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }

                });
                
            }

            return sortOrder switch
            {
                "Virtual" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.Virtual && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.Virtual && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Group" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.GroupActivity && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.GroupActivity && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "OneDay" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.TypeOfOpportunity == "One Day" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.TypeOfOpportunity == "One Day" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Internship" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.TypeOfOpportunity == "Summer Internship" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.TypeOfOpportunity == "Summer Internship" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
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

                    Opportunities = _context.Opportunity.OrderBy(s => s.StartDate).Where(s => !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today).Count()
                    }
                }),
                "Animals" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Animals" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Animals" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Support our troops" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Support our troops" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Support our troops" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Advocacy & Human Rights" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Advocacy & Human Rights" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Advocacy & Human Rights" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Comfort the sick" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Comfort the sick" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Comfort the sick" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Save the Planet" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Save the Planet" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Save the Planet" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Homeless" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Homeless").Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Homeless" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Community Support" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Community Support" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Community Support" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Help Refugees" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Help Refugees" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Help Refugees" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Computers & Technology" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Computers & Technology" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Computers & Technology" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Donations" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Donations" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Donations" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Education & Literacy" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Education & Literacy" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Education & Literacy" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Elderly" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Elderly" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Elderly" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Help kids" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Help kids" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Help kids" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                "Fighting Hunger" => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.OrderBy(s => s.CreateDate).Where(s => s.InterestAreas == "Fighting Hunger" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => s.InterestAreas == "Fighting Hunger" && !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
                    }
                }),
                _ => View(new OpportunitiesListViewModel
                {

                    Opportunities = _context.Opportunity.Where(t => !t.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).OrderByDescending(p => p.CreateDate).Skip((page - 1) * PageSize).Take(PageSize) ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Opportunity.Where(s => !s.ArchivedStatus).Where(s => s.EndDate >= DateTime.Today || s.OnGoing).Count()
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
                    ItemsPerPage = ManagePostsPageSize,
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
        public async Task<IActionResult> ShowSearchResults(String searchPhrase)
        {
            return View("Browse", await _context.Opportunity.Where( j => j.OpportunityName.Contains(searchPhrase)).ToListAsync());
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
        public async Task<IActionResult> Apply(Application application, int? oppId)
        {
            var opp = await _context.Application.Where(t => (t.Volunteer.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) && (t.Opportunity.Id == oppId)).ToListAsync();
            if (opp.Count > 0)
            {
                TempData["message"] = $"You have already applied to this opportunity!";
                return RedirectToAction(nameof(List));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Id();
                    application.Volunteer = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
                    application.Opportunity = await _context.Opportunity.FindAsync(oppId);
                    
                    application.OppName = application.Opportunity.OpportunityName;
                    application.OppId = application.Opportunity.Id;
                    application.IsVirtual = application.Opportunity.Virtual;
                    application.VolsNeeded = application.Opportunity.VolunteersNeeded;
                    application.VolunteerName = application.Volunteer.FirstName + " " + application.Volunteer.LastName;
                    application.OppDate = application.Opportunity.StartDate.Date.ToString("d") + " - " + application.Opportunity.EndDate.Date.ToString("d");
                    application.OppTime = application.Opportunity.StartTime.ToShortTimeString() + " - " + application.Opportunity.EndTime.ToShortTimeString();
                    application.OppLocation = application.Opportunity.City + ", " + application.Opportunity.State + ", " + application.Opportunity.Zip + " at " +
                        application.Opportunity.Address1 + " " + application.Opportunity.Address2;

                    /*try - this info wasnt pulling from the volunteer property in application so I added in here*/
                    application.AboutYou = application.Volunteer.AboutYou;
                    application.InstagramLink = application.Volunteer.InstagramLink;
                    application.FacebookLink = application.Volunteer.FacebookLink;
                    application.TwitterLink = application.Volunteer.TwitterLink;
                    application.OtherWebsite = application.Volunteer.OtherWebsite;
                    application.School = application.Volunteer.OtherWebsite;


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
            var model = new CreateOpportunityViewModel
            {
                AvailableInterestAreas = GetInterestAreas()
            };
            return View(model);
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Create(CreateOpportunityViewModel model, Opportunity opportunity)
        //public async Task<IActionResult> Create([Bind("Id,VolunteersNeeded,OpportunityName,Address1,Address2,City,State,Zip,Country,Description,Requirements,AgeBracket,GradeLevel,InterestAreas,TypeOfOpportunity,Virtual,GroupActivity,OnGoing,StartDate,StartTime,EndDate,EndTime,CreateDate,CompanyLogo")]
        public async Task<IActionResult> Create(CreateOpportunityViewModel model)
        {
            var opportunity = Mapper.Map<Opportunity>(model);

            if (ModelState.IsValid)
            {
                var userId = User.Id();
                opportunity.VolunteersApplied = 0;
                opportunity.CreateDate = DateTime.UtcNow;
                opportunity.InterestAreas = String.Join(",", model.SelectedInterestAreas);
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
            var view = await _context.Application.Where(t => t.Volunteer.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                                                        && !t.Opportunity.ArchivedStatus).Include(e => e.Opportunity).ToListAsync();
            return View(view);

        }

        public async Task<IActionResult> ManageApplicants()
        {

            List<Application> applications = await _context.Application.Where(t => t.Opportunity.CreateUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value && !t.Opportunity.ArchivedStatus).OrderByDescending(t => t.OppName).ToListAsync();

            return View(applications);
        }


        [HttpPost]
        public async Task<IActionResult> ApproveApplicant(int applicationId, Application application, Opportunity opportunity)
        {
            

            if (ModelState.IsValid)
            {
                application = await _context.Application
                    .Include(a=>a.Volunteer)
                    .Where(a=>a.Id==applicationId)
                    .FirstOrDefaultAsync();
                opportunity = await _context.Opportunity
                    .Where(o => o.Id == application.OppId)
                    .Include(t => t.CreateUser)
                    .FirstOrDefaultAsync();
                
                int volunteersSignedUp = opportunity.VolunteersApplied;
                var mailer = new SendEmail();
                if (volunteersSignedUp < opportunity.VolunteersNeeded)
                {
                    if (application.Status == true)
                    {
                        application.Status = false;
                        volunteersSignedUp--;
                        opportunity.VolunteersApplied = volunteersSignedUp;
                        mailer.sendEmail(application, opportunity, false); ;

                    }
                    else
                    {
                        application.Status = true;
                        volunteersSignedUp++;
                        opportunity.VolunteersApplied = volunteersSignedUp;
                        mailer.sendEmail(application, opportunity, true);
                        
                    } 
                }
                else
                {
                    if (application.Status == true)
                    {
                        application.Status = false;
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
        public async Task<IActionResult> WithdrawApplication(int id, Opportunity opportunity)
        {

            var application = await _context.Application.FindAsync(id);
            opportunity = await _context.Opportunity.FindAsync(application.OppId);
            int volunteersSignedUp = opportunity.VolunteersApplied;
            if (application.Status == true)
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
        }

        // GET: Opportunities/ViewApplicant/5
        public async Task<IActionResult> ViewApplicant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application.Include(t=>t.Volunteer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        private IList<SelectListItem> GetInterestAreas()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Advocacy & Human Rights", Value = "Advocacy & Human Rights"},
                new SelectListItem {Text = "Animals", Value = "Animals"},
                new SelectListItem {Text = "Comfort the city", Value = "Comfort the city"},
                new SelectListItem {Text = "Community Support", Value = "Community Support"},
                new SelectListItem {Text = "Computers & Technology", Value = "Computers & Technology"},
                new SelectListItem {Text = "Donations", Value = "Donations"},
                new SelectListItem {Text = "Education & Literacy", Value = "Education & Literacy"},
                new SelectListItem {Text = "Elderly", Value = "Elderly"},
                new SelectListItem {Text = "Help Kids", Value = "Help Kids"},
                new SelectListItem {Text = "Help Refugees", Value = "Help Refugees"},
                new SelectListItem {Text = "Help the Homeless", Value = "Help the Homeless"},
                new SelectListItem {Text = "Save the Planet", Value = "Save the Planet"},
                new SelectListItem {Text = "Support our Troops", Value = "Support our Troops"},
                new SelectListItem {Text = "Fighting Hunger", Value = "Fighting Hunger"},

            };
        }
    }
}
