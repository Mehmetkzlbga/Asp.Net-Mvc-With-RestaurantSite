using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int RolId { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Rezervasyon> Rezervasyons { get; set; } = new List<Rezervasyon>();

    public virtual Rol Rol { get; set; } = null!;
}
