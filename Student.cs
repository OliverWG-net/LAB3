using System;
using System.Collections.Generic;

namespace LAB3;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Personnummer { get; set; } = null!;

    public int? FkKlassId { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual Klass? FkKlass { get; set; }
}
