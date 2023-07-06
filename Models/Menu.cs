using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class Menu
{
    public int Id { get; set; }

    [Display(Name = "Başlık", Prompt = "Başlık yazınız")]
    public string? Title { get; set; } = null!;

    [Display(Name = "Açıklama", Prompt = "Açıklama yazınız")]
    public string? Description { get; set; } = null!;

    //public string? Image { get; set; }

    //public bool? Ozel { get; set; }

    [Display(Name = "Fiyat", Prompt = "Fiyat yazınız")]
    public double? Price { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
