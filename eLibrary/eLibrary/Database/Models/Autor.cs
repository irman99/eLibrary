using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Autor")]
public partial class Autor
{
    [Key]
    [Column("AutorID")]
    public int AutorId { get; set; }

    [Column("KorisnikID")]
    public int? KorisnikId { get; set; }

    [InverseProperty("Autor")]
    public virtual ICollection<Knjiga> Knjigas { get; set; } = new List<Knjiga>();

    [ForeignKey("KorisnikId")]
    [InverseProperty("Autors")]
    public virtual Korisnik? Korisnik { get; set; }
}
