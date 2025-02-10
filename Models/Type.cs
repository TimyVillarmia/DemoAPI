using System;
using System.Collections.Generic;

namespace DemoAPI.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Pokemon> PokedexNumbers { get; set; } = new List<Pokemon>();
}
