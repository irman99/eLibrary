using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Notifikacije")]
public partial class Notifikacije
{
    [Key]
    [Column("NotifikacijaID")]
    public int NotifikacijaId { get; set; }

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [StringLength(100)]
    public string Poruka { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime VrijemeNotifikacije { get; set; }

    [Column("TipNotifikacijeID")]
    public int TipNotifikacijeId { get; set; }

    public bool? Procitana { get; set; }

    [ForeignKey("KorisnikId")]
    [InverseProperty("Notifikacijes")]
    public virtual Korisnik? Korisnik { get; set; }

    [ForeignKey("TipNotifikacijeId")]
    [InverseProperty("Notifikacijes")]
    public virtual TipNotifikacije TipNotifikacije { get; set; } = null!;
}
