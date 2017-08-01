using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTimeTracking.Data;
using ProjectTimeTracking.Models.ProjectViewModels;

namespace ProjectTimeTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectTimeTrackingContext _context;

        public HomeController(ProjectTimeTrackingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<EmploymentTypeGroup> data =
                from employee in _context.Employees
                group employee by employee.KindOfEmployment into employmentGroup
                select new EmploymentTypeGroup()
                {
                    KindOfEmployment = employmentGroup.Key,
                    EmployeeCount = employmentGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
