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

    [StringLength(255)]
    public string NazivFilea { get; set; } = null!;

    [StringLength(255)]
    public string PathToFile { get; set; } = null!;

    public int? IdKnjiga { get; set; }

    [ForeignKey("IdKnjiga")]
    [InverseProperty("FajloviKnjiges")]
    public virtual Knjiga? IdKnjigaNavigation { get; set; }
}
