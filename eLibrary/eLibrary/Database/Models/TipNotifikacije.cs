using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("TipNotifikacije")]
public partial class TipNotifikacije
{
    [Key]
    [Column("TipNotifikacijeID")]
    public int TipNotifikacijeId { get; set; }

    [StringLength(30)]
    public string? NazivNotifikacije { get; set; }

    [InverseProperty("TipNotifikacije")]
    public virtual ICollection<Notifikacije> Notifikacijes { get; set; } = new List<Notifikacije>();
}
