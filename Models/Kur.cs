using System;
using System.Collections.Generic;

namespace LAB3.Models;

public partial class Kur
{
    public int KursId { get; set; }

    public string? KursNamn { get; set; }

    public int? FkLärareId { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual Personal? FkLärare { get; set; }
}
