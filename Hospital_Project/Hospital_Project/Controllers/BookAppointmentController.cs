using Hospital_Project.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Project.Controllers {
    public class BookAppointmentController : Controller {
        private readonly ApplicationDbContext _context = new();
        public IActionResult Index() {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }
        public IActionResult Details(string drName) {
            var doctors = _context.Doctors.Where(e => e.Name == drName).FirstOrDefault();
            return View(doctors);
        }

        public IActionResult AddDetails(string patientName, DateOnly date, TimeOnly time, int doc_id) {
            _context.Appointments.Add(new() {
                PatientName = patientName,
                AppointmentDate = date,
                AppointmentTime = time,
               
            });
            _context.SaveChanges();
            return RedirectToAction(nameof(Success));
        }
        public IActionResult Success() {
            return View();
        }
    }
}
