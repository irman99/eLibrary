using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Knjiga")]
public partial class Knjiga
{
    [Key]
    public int IdKnjiga { get; set; }

    [StringLength(30)]
    public string Naslov { get; set; } = null!;

    [StringLength(30)]
    public string Zanr { get; set; } = null!;

    [Column("AutorID")]
    public int AutorId { get; set; }

    public DateOnly DatumIzdavanja { get; set; }

    [StringLength(200)]
    public string? Opis { get; set; }

    public bool? Dostupnost { get; set; }

    [Column(TypeName = "money")]
    public decimal? Cijena { get; set; }

    public byte[]? NaslovnaSlika { get; set; }

    [ForeignKey("AutorId")]
    [InverseProperty("Knjigas")]
    public virtual Autor Autor { get; set; } = null!;

    [InverseProperty("IdKnjigaNavigation")]
    public virtual ICollection<FajloviKnjige> FajloviKnjiges { get; set; } = new List<FajloviKnjige>();

    [InverseProperty("Knjiga")]
    public virtual ICollection<KnjigaKorisnik> KnjigaKorisniks { get; set; } = new List<KnjigaKorisnik>();

    [InverseProperty("Knjiga")]
    public virtual ICollection<Komentari> Komentaris { get; set; } = new List<Komentari>();

    [ForeignKey("KnjigaId")]
    [InverseProperty("Knjigas")]
    public virtual ICollection<Zanr> Zanrs { get; set; } = new List<Zanr>();
}
