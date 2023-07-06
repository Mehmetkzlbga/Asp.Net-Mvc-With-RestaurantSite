using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class DenemeUserMenuController : Controller
    {
            private readonly Cafe2Context _context;

            public DenemeUserMenuController()
            {
                _context = new Cafe2Context();
            }

            // GET: DenemeUserMenuController
            public ActionResult Index()
        {
            var menuler = _context.Menus.ToList();
            return View(menuler);
        }

        // GET: DenemeUserMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DenemeUserMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DenemeUserMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DenemeUserMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DenemeUserMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DenemeUserMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DenemeUserMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
