using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class AboutController : Controller
    {
        private readonly Cafe2Context _context;
        public AboutController()
        {
            _context = new Cafe2Context();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
