using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Komentari")]
public partial class Komentari
{
    [Key]
    [Column("KomentarID")]
    public int KomentarId { get; set; }

    [Column("KnjigaID")]
    public int? KnjigaId { get; set; }

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [StringLength(255)]
    public string Sadrzaj { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? VrijemeKomentara { get; set; }

    [ForeignKey("KnjigaId")]
    [InverseProperty("Komentaris")]
    public virtual Knjiga? Knjiga { get; set; }

    [ForeignKey("KorisnikId")]
    [InverseProperty("Komentaris")]
    public virtual Korisnik? Korisnik { get; set; }
}
