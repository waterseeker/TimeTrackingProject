using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTimeTracking.Data;
using ProjectTimeTracking.Models;

namespace ProjectTimeTracking.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectTimeTrackingContext _context;

        public ProjectsController(ProjectTimeTrackingContext context)
        {
            _context = context;    
        }

        // GET: Projects
        public async Task<IActionResult> Index(
                        string sortOrder,
                        string currentFilter,
                        string searchString,
                        int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ProjectNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "project_name" : "";
            ViewData["CompletionTimeEstimateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "completion_time" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var projects = from p in _context.Projects
                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.ProjectName.Contains(searchString)
                                       || p.ProjectDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "project_name":
                    projects = projects.OrderBy(p => p.ProjectName);
                    break;
                case "completion_time":
                    projects = projects.OrderBy(p => p.CompletionTimeEstimate);
                    break;
                default:
                    projects = projects.OrderByDescending(p => p.ProjectName);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Project>.CreateAsync(projects.AsNoTracking(), page ?? 1, pageSize));
        }
        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .SingleOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            PopulateProjectsDropDownList();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,ProjectName,ProjectDescription,CompletionTimeEstimate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateProjectsDropDownList(project.ProjectID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }
            PopulateProjectsDropDownList(project.ProjectID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectToUpdate = await _context.Projects
                .SingleOrDefaultAsync(p => p.ProjectID == id);

            if (await TryUpdateModelAsync<Project>(projectToUpdate,
                "",
                p => p.CompletionTimeEstimate, p => p.ProjectID, p => p.ProjectName))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Index");
            }
            PopulateProjectsDropDownList(projectToUpdate.ProjectID);
            return View(projectToUpdate);
        }

        private void PopulateProjectsDropDownList(object selectedProject = null)
        {
            var projectsQuery = from p in _context.Projects
                                   orderby p.ProjectName
                                   select p;
            ViewBag.ProjectID = new SelectList(projectsQuery.AsNoTracking(), "ProjectID", "Name", selectedProject);
        }


        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .SingleOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectID == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}
