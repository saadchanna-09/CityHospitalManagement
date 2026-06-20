using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityHospitalManagement.Data;
using CityHospitalManagement.Models;

namespace CityHospitalManagement.Controllers
{
    public class AdmissionsController : Controller
    {
        private readonly HospitalDbContext _context;

        public AdmissionsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: Admissions
        public async Task<IActionResult> Index()
        {
            var hospitalDbContext = _context.Admissions.Include(a => a.Doctor).Include(a => a.Patient);
            return View(await hospitalDbContext.ToListAsync());
        }

        // GET: Admissions/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FullName");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            return View();
        }

        // POST: Admissions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,WardType,BedNumber,AdmissionDate,Status")] Admission admission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FullName", admission.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", admission.PatientId);
            return View(admission);
        }
    }
}