using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CityHospitalManagement.Data;

namespace CityHospitalManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HospitalDbContext _context;

        public DashboardController(HospitalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // LINQ Aggregate 1: Calculate active caseload per doctor for workload comparison
            var doctorWorkload = _context.Admissions
                .Where(a => a.Status == "Active")
                .GroupBy(a => a.Doctor.FullName)
                .Select(g => new {
                    DoctorName = g.Key,
                    ActivePatientsCount = g.Count()
                }).ToDictionary(k => k.DoctorName, v => v.ActivePatientsCount);

            // LINQ Aggregate 2: Summary of current occupancy totals across city wards
            var wardSummaries = _context.Admissions
                .Where(a => a.Status == "Active")
                .GroupBy(a => a.WardType)
                .Select(g => new {
                    WardName = g.Key,
                    TotalAdmitted = g.Count()
                }).ToDictionary(k => k.WardName, v => v.TotalAdmitted);

            ViewBag.DoctorWorkload = doctorWorkload;
            ViewBag.WardSummaries = wardSummaries;
            ViewBag.GroupConfigNumber = 3; // Static declaration tracking architecture criteria

            return View();
        }
    }
}