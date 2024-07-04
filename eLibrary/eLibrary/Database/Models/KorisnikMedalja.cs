using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("KorisnikMedalja")]
public partial class KorisnikMedalja
{
    [Key]
    [Column("KorisnikMedaljaID")]
    public int KorisnikMedaljaId { get; set; }

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [Column("MedaljaID")]
    public int? MedaljaId { get; set; }

    [ForeignKey("KorisnikId")]
    [InverseProperty("KorisnikMedaljas")]
    public virtual Korisnik? Korisnik { get; set; }

    [ForeignKey("MedaljaId")]
    [InverseProperty("KorisnikMedaljas")]
    public virtual Medalja? Medalja { get; set; }
}
