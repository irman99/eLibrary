using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

[Table("FajloviKnjige")]
public partial class FajloviKnjige
{
    [Key]
    public int IdFile { get; set; }

    [StringLength(30)]
    public string? NazivFilea { get; set; }

    [MaxLength(1)]
    public byte[]? SadrzajFilea { get; set; }

    public int? IdKnjiga { get; set; }

    [ForeignKey("IdKnjiga")]
    [InverseProperty("FajloviKnjiges")]
    public virtual Knjiga? IdKnjigaNavigation { get; set; }
}
