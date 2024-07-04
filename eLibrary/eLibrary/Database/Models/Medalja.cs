using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Medalja")]
public partial class Medalja
{
    [Key]
    [Column("MedaljaID")]
    public int MedaljaId { get; set; }

    [StringLength(50)]
    public string? NazivMedalje { get; set; }

    public byte[]? SlikaMedalje { get; set; }

    [InverseProperty("Medalja")]
    public virtual ICollection<KorisnikMedalja> KorisnikMedaljas { get; set; } = new List<KorisnikMedalja>();
}
