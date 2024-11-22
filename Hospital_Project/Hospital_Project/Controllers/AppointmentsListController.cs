using Hospital_Project.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Project.Controllers {
    public class AppointmentsListController : Controller {
        private readonly ApplicationDbContext _context = new(); 
        public IActionResult Index() {
            var appointments = _context.Appointments.ToList();
            return View(appointments);
        }
    }
}
