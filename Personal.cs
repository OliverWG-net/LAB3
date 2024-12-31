using System;
using System.Collections.Generic;

namespace LAB3;

public partial class Personal
{
    public int PersonalId { get; set; }

    public string? Fnamn { get; set; }

    public string? Lnamn { get; set; }

    public string? Personnummer { get; set; }

    public string? Position { get; set; }

    public string? Avdelning { get; set; }

    public int? Lön { get; set; }

    public DateOnly? Anställningsdatum { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual ICollection<Kur> Kurs { get; set; } = new List<Kur>();
}
