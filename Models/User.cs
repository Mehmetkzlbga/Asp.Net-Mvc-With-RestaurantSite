using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class User
{
    public int Id { get; set; }

    [Display(Name = "İsim", Prompt = "İsminizi yazınız")]
    public string Name { get; set; } = null!;

    [Display(Name = "Soyisim", Prompt = "Soyisminizi yazınız")]
    public string Surname { get; set; } = null!;

    [Display(Name = "Kullanıcı Adı", Prompt = "Kullanıcı Adınızı yazınız")]
    public string UserName { get; set; } = null!;

    public int RolId { get; set; }

    [Display(Name = "Şifre", Prompt = "Şifrenizi yazınız")]
    public string? Password { get; set; }

    public virtual ICollection<Rezervasyon> Rezervasyons { get; set; } = new List<Rezervasyon>();

    public virtual Rol? Rol { get; set; } = null!;
}
