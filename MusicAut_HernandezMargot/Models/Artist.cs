using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Artist")]
public partial class Artist
{
    [Key]
    public int ArtistId { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    [DisplayName("Nombre")]
    public string? Name { get; set; }

    [InverseProperty("Artist")]
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    [InverseProperty("Artist")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
