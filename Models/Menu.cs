using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Image { get; set; } = null!;

    public bool? Ozel { get; set; } = null!;

    public double Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
