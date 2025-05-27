using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Album")]
[Index("ArtistId", Name = "IFK_AlbumArtistId")]
public partial class Album
{
    [Key]
    [DisplayName("Id del álbum")]
    public int AlbumId { get; set; }

    [StringLength(160)]
    [Unicode(false)]
    [DisplayName("Título")]
    public string Title { get; set; } = null!;

    public int ArtistId { get; set; }

    [ForeignKey("ArtistId")]
    [InverseProperty("Albums")]
    [DisplayName("Nombre del artista")]
    public virtual Artist? Artist { get; set; } = null!;

    [InverseProperty("Album")]
    [DisplayName("Canciones")]
    public virtual ICollection<Track>? Tracks { get; set; } = new List<Track>();
}
