using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
