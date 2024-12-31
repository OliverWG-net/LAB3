using System;
using System.Collections.Generic;

namespace LAB3;

public partial class Klass
{
    public int KlassId { get; set; }

    public string? KlassNamn { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
