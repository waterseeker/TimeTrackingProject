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
    public class TimeEntriesController : Controller
    {
        private readonly ProjectTimeTrackingContext _context;

        public TimeEntriesController(ProjectTimeTrackingContext context)
        {
            _context = context;    
        }

        // GET: TimeEntries
        public async Task<IActionResult> Index()
        {
            var projectTimeTrackingContext = _context.TimeEntries.Include(t => t.Employee).AsNoTracking().Include(t => t.Project).AsNoTracking();
            return View(await projectTimeTrackingContext.ToListAsync());
        }

        // GET: TimeEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeEntry = await _context.TimeEntries
                .Include(t => t.Employee)
                .Include(t => t.Project)
                .SingleOrDefaultAsync(m => m.TimeEntryID == id);
            if (timeEntry == null)
            {
                return NotFound();
            }

            return View(timeEntry);
        }

        // GET: TimeEntries/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeFirstName", "EmployeeFirstName");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectName", "ProjectName");
            return View();
        }

        // POST: TimeEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeEntryID,ProjectID,EmployeeID,DateWorked,TimeWorked")] TimeEntry timeEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "EmployeeFirstName", timeEntry.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectDescription", timeEntry.ProjectID);
            return View(timeEntry);
        }

         //GET: TimeEntries/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }
        
             var timeEntry = await _context.TimeEntries.SingleOrDefaultAsync(m => m.TimeEntryID == id);
             if (timeEntry == null)
             {
                 return NotFound();
             }
             ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeFirstName", "EmployeeFirstName", timeEntry.EmployeeID);
             ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", timeEntry.ProjectID);
             return View(timeEntry);
         }


        // POST: TimeEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeEntryID,ProjectID,EmployeeID,DateWorked,TimeWorked")] TimeEntry timeEntry)
        {
            if (id != timeEntry.TimeEntryID)
            {
                return NotFound();
            }
        
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeEntryExists(timeEntry.TimeEntryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "EmployeeFirstName", timeEntry.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectDescription", timeEntry.ProjectID);
            return View(timeEntry);
        }

        // GET: TimeEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeEntry = await _context.TimeEntries
                .Include(t => t.Employee)
                .Include(t => t.Project)
                .SingleOrDefaultAsync(m => m.TimeEntryID == id);
            if (timeEntry == null)
            {
                return NotFound();
            }

            return View(timeEntry);
        }

        // POST: TimeEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeEntry = await _context.TimeEntries.SingleOrDefaultAsync(m => m.TimeEntryID == id);
            _context.TimeEntries.Remove(timeEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TimeEntryExists(int id)
        {
            return _context.TimeEntries.Any(e => e.TimeEntryID == id);
        }
    }
}
