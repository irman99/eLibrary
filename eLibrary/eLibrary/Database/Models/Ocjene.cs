using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Ocjene")]
[Index("IdKnjiga", Name = "IX_Ocjene_IdKnjiga")]
[Index("IdKorisnik", Name = "IX_Ocjene_IdKorisnik")]
[Index("IdKorisnikPosiljalac", Name = "IX_Ocjene_IdKorisnikPosiljalac")]
public partial class Ocjene
{
    [Key]
    [Column("OcjenaID")]
    public int OcjenaId { get; set; }

    public int? IdKorisnik { get; set; }

    public int? IdKnjiga { get; set; }

    public int IdKorisnikPosiljalac { get; set; }

    public bool TipOcjene { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Rating { get; set; }

    [ForeignKey("IdKnjiga")]
    [InverseProperty("Ocjenes")]
    public virtual Knjiga? IdKnjigaNavigation { get; set; }

    [ForeignKey("IdKorisnik")]
    [InverseProperty("OcjeneIdKorisnikNavigations")]
    public virtual Korisnik? IdKorisnikNavigation { get; set; }

    [ForeignKey("IdKorisnikPosiljalac")]
    [InverseProperty("OcjeneIdKorisnikPosiljalacNavigations")]
    public virtual Korisnik IdKorisnikPosiljalacNavigation { get; set; } = null!;
}
