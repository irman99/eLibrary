using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("ZanroviKnjiga")]
[Index("KnjigaId", Name = "IX_ZanroviKnjiga_KnjigaID")]
[Index("ZanrId", Name = "IX_ZanroviKnjiga_ZanrID")]
public partial class ZanroviKnjiga
{
    [Key]
    [Column("ZanroviKnjigaID")]
    public int ZanroviKnjigaId { get; set; }

    [Column("KnjigaID")]
    public int KnjigaId { get; set; }

    [Column("ZanrID")]
    public int ZanrId { get; set; }

    [ForeignKey("KnjigaId")]
    [InverseProperty("ZanroviKnjigas")]
    public virtual Knjiga Knjiga { get; set; } = null!;

    [ForeignKey("ZanrId")]
    [InverseProperty("ZanroviKnjigas")]
    public virtual Zanr Zanr { get; set; } = null!;
}
