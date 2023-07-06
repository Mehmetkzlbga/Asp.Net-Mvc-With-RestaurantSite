using Microsoft.Identity.Client;
using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.MetaData
{
    public class RezervasyonMetaData
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "EPosta", Prompt = "Eposta yazınız")]
        public string Email { get; set; } = null!;

        [Display(Name = "Telefon Numarası")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "En az 11 karakter girmelisiniz")]
        public string TelefonNo { get; set; } = null!;

        [Display(Name = "Kaç kişilik")]
        [Range(0, int.MaxValue, ErrorMessage = "Eksi değer girilemez.")]
        public int Sayi { get; set; }

        public DateTime Tarih { get; set; }

        [Display(Name = "Üye ismi")]
        public int? UserId { get; set; }

        [Display(Name = "Üye")]
        public virtual User? User { get; set; }
    }
}
