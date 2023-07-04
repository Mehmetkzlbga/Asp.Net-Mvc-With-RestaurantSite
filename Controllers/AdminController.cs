using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="1")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
