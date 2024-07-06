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

    [InverseProperty("Zanr")]
    public virtual ICollection<ZanroviKnjiga> ZanroviKnjigas { get; set; } = new List<ZanroviKnjiga>();
}
