using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Autor")]
[Index("IdKorisnik", Name = "UQ__Autor__58FE570FC3ABC52F", IsUnique = true)]
public partial class Autor
{
    [Key]
    [Column("AutorID")]
    public int AutorId { get; set; }

    public int? IdKorisnik { get; set; }

    [ForeignKey("IdKorisnik")]
    [InverseProperty("Autor")]
    public virtual Korisnik? IdKorisnikNavigation { get; set; }

    [InverseProperty("Autor")]
    public virtual ICollection<Knjiga> Knjigas { get; set; } = new List<Knjiga>();
}
