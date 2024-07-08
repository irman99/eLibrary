using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Korisnik")]
[Index("KorisnickoIme", Name = "UQ__Korisnik__992E6F92044E7587", IsUnique = true)]
public partial class Korisnik
{
    [Key]
    public int IdKorisnik { get; set; }

    [StringLength(30)]
    public string Ime { get; set; } = null!;

    [StringLength(30)]
    public string Prezime { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string KorisnickoIme { get; set; } = null!;

    public byte[]? Fotografija { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DatumRodjenja { get; set; }

    [Column("TipKorisnikaID")]
    public int? TipKorisnikaId { get; set; }

    [StringLength(50)]
    public string? LozinkaHash { get; set; }

    [StringLength(50)]
    public string? LozinkaSalt { get; set; }

    [InverseProperty("Korisnik")]
    public virtual ICollection<Autor> Autors { get; set; } = new List<Autor>();

    [InverseProperty("Korisnik")]
    public virtual ICollection<Kartica> Karticas { get; set; } = new List<Kartica>();

    [InverseProperty("Korisnik")]
    public virtual ICollection<KnjigaKorisnik> KnjigaKorisniks { get; set; } = new List<KnjigaKorisnik>();

    [InverseProperty("Korisnik")]
    public virtual ICollection<Komentari> Komentaris { get; set; } = new List<Komentari>();

    [InverseProperty("Korisnik")]
    public virtual ICollection<KorisnikMedalja> KorisnikMedaljas { get; set; } = new List<KorisnikMedalja>();

    [InverseProperty("Korisnik")]
    public virtual ICollection<Notifikacije> Notifikacijes { get; set; } = new List<Notifikacije>();

    [InverseProperty("IdKorisnikNavigation")]
    public virtual ICollection<Ocjene> OcjeneIdKorisnikNavigations { get; set; } = new List<Ocjene>();

    [InverseProperty("IdKorisnikPosiljalacNavigation")]
    public virtual ICollection<Ocjene> OcjeneIdKorisnikPosiljalacNavigations { get; set; } = new List<Ocjene>();

    [ForeignKey("TipKorisnikaId")]
    [InverseProperty("Korisniks")]
    public virtual TipKorisnika? TipKorisnika { get; set; }
}
