using System;
using System.Collections.Generic;

namespace DemoAPI.Models;

public partial class Pokemon
{
    public int PokedexNumber { get; set; }

    public string Name { get; set; } = null!;

    public int? Hp { get; set; }

    public int? Attack { get; set; }

    public int? Defense { get; set; }

    public int? SpecialAttack { get; set; }

    public int? SpecialDefense { get; set; }

    public int? Speed { get; set; }

    public int? Generation { get; set; }

    public virtual ICollection<Type> Types { get; set; } = new List<Type>();
}
