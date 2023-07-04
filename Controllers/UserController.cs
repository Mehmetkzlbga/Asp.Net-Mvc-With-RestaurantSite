using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        //Kullanıcının rezervasyon verdikten sonra rezervasyonları listeleyebileceği kısmı yöneten controller
       
        private readonly Cafe2Context _context;

        public UserController()
        {
            _context = new Cafe2Context();
        }

        public async Task<IActionResult> Index()
        {
            var cafe2Context = _context.Rezervasyons.Include(r => r.User);
            return View(await cafe2Context.ToListAsync());
        }

        // GET: Rezervasyon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rezervasyons == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyons
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }
    }
}
