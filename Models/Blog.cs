using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Image { get; set; }

    public bool Onay { get; set; }

    public string? Mesaj { get; set; }

    public DateTime Tarih { get; set; }
}
