using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Ocjena")]
public partial class Ocjena
{
    [Key]
    [Column("OcjenaID")]
    public int OcjenaId { get; set; }

    [Column("Ocjena")]
    public int? Ocjena1 { get; set; }

    public bool? TipOcjene { get; set; }

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [ForeignKey("KorisnikId")]
    [InverseProperty("Ocjenas")]
    public virtual Korisnik? Korisnik { get; set; }
}
