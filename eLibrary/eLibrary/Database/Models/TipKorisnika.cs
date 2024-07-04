using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("TipKorisnika")]
[Index("TipKorisnika1", Name = "UQ__TipKoris__DB142111DAF9DD2B", IsUnique = true)]
public partial class TipKorisnika
{
    [Key]
    public int IdTipKorisnika { get; set; }

    [Column("TipKorisnika")]
    [StringLength(50)]
    public string? TipKorisnika1 { get; set; }

    [InverseProperty("TipKorisnika")]
    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
