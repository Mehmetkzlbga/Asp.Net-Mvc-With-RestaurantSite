using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly Cafe2Context _context;

        public AccountController()
        {
            _context = new Cafe2Context();
        }
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginView entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CheckUser(entity.UserName,entity.Password))
                    {
                        var LogedUser = _context.Users.FirstOrDefault(x=>x.UserName == entity.UserName && x.Password == entity.Password);
                        var claims = new List<Claim> // kullanıcının hak iddia ettiği şeyleri buraya yazıyoruz.
                        {
                            new Claim(ClaimTypes.NameIdentifier, entity.UserName), new Claim(ClaimTypes.Role,LogedUser.RolId.ToString())
                        };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                        if (LogedUser.RolId ==1)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else // eğer yoksa
                    {
                        throw new Exception("Böyle bir kullanıcı bulunamadı.");
                    }
                }
                else
                {
                    throw new Exception("lütfen form verilerini kontrol edin"); // HATA GÖNDERİYOR.
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View(entity);
      
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                user.RolId = 2;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }
        private bool CheckUser(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);

            return user != null;
        }
    }
}
