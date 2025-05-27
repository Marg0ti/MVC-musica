using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Genre")]
public partial class Genre
{
    [Key]
    public int GenreId { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    public string? Name { get; set; }

    [InverseProperty("Genre")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
