using System;
using System.Collections.Generic;

namespace LAB3.Models;

public partial class Betyg
{
    public int BetygId { get; set; }

    public int? StudentId { get; set; }

    public int? FkKursId { get; set; }

    public int? LärareId { get; set; }

    public DateOnly? BetygsDatum { get; set; }

    public int? Betyg1 { get; set; }

    public virtual Kur? FkKurs { get; set; }

    public virtual Personal? Lärare { get; set; }

    public virtual Student? Student { get; set; }
}
