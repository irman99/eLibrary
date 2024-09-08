using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("TipKorisnika")]
public partial class TipKorisnika
{
    [Key]
    public int TipKorisnikaId { get; set; }

    [StringLength(50)]
    public string Naziv { get; set; } = null!;

    [InverseProperty("TipKorisnika")]
    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
