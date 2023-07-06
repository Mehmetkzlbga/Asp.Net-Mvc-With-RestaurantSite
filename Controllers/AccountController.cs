using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.Extensions.Hosting;

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

        //Login adında bir HTTP POST eylemi tanımlanır.Bu eylem, bir LoginView nesnesi alır ve Task<IActionResult> türünde bir sonuç döner.
        //FromForm özniteliği, HTTP POST isteğinin form verilerini LoginView nesnesine dönüştürmek için kullanılır.
        public async Task<IActionResult> Login([FromForm] LoginView entity)
        {
            //try catch bu eylem içinde oluşabilecek istisnaları yakalamak ve yönetmek için kullandım
            try
            {
                //Bu ifade, LoginView nesnesinin model durumunun geçerli olup olmadığını kontrol eder.
                if (ModelState.IsValid)
                {
                    //CheckUser işlevi, kullanıcı adı ve şifre parametrelerini kontrol eder ve doğrulama başarılı ise true değerini döndürür.
                    if (CheckUser(entity.UserName,entity.Password))
                    {
                        //Bu satır, kullanıcının veritabanında mevcut olup olmadığını kontrol etmek için
                        //kullanıcı adı ve şifreyi veritabanında arar.
                       var LogedUser = _context.Users.FirstOrDefault(x=>x.UserName == entity.UserName && x.Password == entity.Password);
                        var claims = new List<Claim> // kullanıcının hak iddia ettiği şeyleri buraya yazıyoruz.
                        {
                            // kullanıcının sahip olduğu iddiaları temsil eden claim listesini  oluşturur.
                            new Claim(ClaimTypes.NameIdentifier, entity.UserName), new Claim(ClaimTypes.Role,LogedUser.RolId.ToString())
                        };

                        //Bu satır, kullanıcının iddialarını içeren bir ClaimsIdentity oluşturur.
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                        //Bu satır, bir ClaimsIdentity üzerinden oluşturulan ClaimsPrincipal nesnesini temsil eder.
                        //Bu, kullanıcının kimlik bilgilerini taşıyan bir nesnedir.
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        //Bu satır, kullanıcının kimlik bilgilerini oturumlaştırmak için HttpContext üzerinde oturum açma işlemini gerçekleştirir. 
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

        // Register adında bir http post eylemi tanımladık,bu eylem user nesnesini alır ve .. adında bir sonuç döndürür.
        public async Task<IActionResult> Register([FromForm] User user)
        {
            // user nesnesinin model durumunun geçerli olup olmadığını kontrol eder.
            if (ModelState.IsValid)
            {
                // bu satır yeni kaydedilen kullanıcının rolünü belirler. rolünü 2 olarak ayarlar 
                user.RolId = 2;

                //  Bu satır, kullanıcı nesnesini veritabanına ekler. 
                _context.Add(user);

                // Bu satır, yapılan değişiklikleri veritabanına asenkron olarak kaydeder.
                // Değişikliklerin kalıcı hale gelmesi için bu yöntem kullanılır.
                await _context.SaveChangesAsync();

                // Bu ifade, kayıt işlemi başarılı olduğunda kullanıcıyı "Login" eylemine yönlendirir. 
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
