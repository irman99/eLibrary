using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("KnjigaKorisnik")]
[Index("KnjigaId", Name = "IX_KnjigaKorisnik_KnjigaID")]
[Index("KorisnikId", Name = "IX_KnjigaKorisnik_KorisnikID")]
public partial class KnjigaKorisnik
{
    [Key]
    [Column("KnjigaKorisnikID")]
    public int KnjigaKorisnikId { get; set; }

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [Column("KnjigaID")]
    public int? KnjigaId { get; set; }

    [ForeignKey("KnjigaId")]
    [InverseProperty("KnjigaKorisniks")]
    public virtual Knjiga? Knjiga { get; set; }

    [ForeignKey("KorisnikId")]
    [InverseProperty("KnjigaKorisniks")]
    public virtual Korisnik? Korisnik { get; set; }
}
