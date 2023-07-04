using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class Rezervasyon
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string TelefonNo { get; set; } = null!;

    public int Sayi { get; set; }

    public DateTime Tarih { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
