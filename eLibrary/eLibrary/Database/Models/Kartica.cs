using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Kartica")]
[Index("KorisnikId", Name = "IX_Kartica_KorisnikID")]
public partial class Kartica
{
    [Key]
    [Column("KarticaID")]
    public int KarticaId { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string BrojKartice { get; set; } = null!;

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [ForeignKey("KorisnikId")]
    [InverseProperty("Karticas")]
    public virtual Korisnik? Korisnik { get; set; }
}
