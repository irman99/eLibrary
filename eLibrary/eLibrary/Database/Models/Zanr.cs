using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("Zanr")]
public partial class Zanr
{
    [Key]
    [Column("ZanrID")]
    public int ZanrId { get; set; }

    [StringLength(30)]
    public string? NazivZanra { get; set; }

    [ForeignKey("ZanrId")]
    [InverseProperty("Zanrs")]
    public virtual ICollection<Knjiga> Knjigas { get; set; } = new List<Knjiga>();
}
