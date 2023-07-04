using System.ComponentModel.DataAnnotations;
namespace Restaurant.ViewModels
{
    public class LoginView
    {
        [Required,Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required, Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
