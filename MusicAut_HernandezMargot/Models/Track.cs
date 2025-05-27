using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Track")]
[Index("AlbumId", Name = "IFK_TrackAlbumId")]
[Index("GenreId", Name = "IFK_TrackGenreId")]
[Index("MediaTypeId", Name = "IFK_TrackMediaTypeId")]
public partial class Track
{
    [Key]
    [DisplayName("Id de canción")]
    public int TrackId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    [DisplayName("Nombre de la canción")]

    public string Name { get; set; } = null!;

    [DisplayName("Id del álbum")]
    public int? AlbumId { get; set; }

    [DisplayName("Id del tipo de medio")]
    public int MediaTypeId { get; set; }

   
    public int? GenreId { get; set; }

    [StringLength(220)]
    [Unicode(false)]
    [DisplayName("Compositor")]
    public string? Composer { get; set; }

    [DisplayName("Milisegundos")]
    public int Milliseconds { get; set; }

    public int? Bytes { get; set; }

    [Column(TypeName = "numeric(10, 2)")]
    [DisplayName("Precio")]
    public decimal UnitPrice { get; set; }


    [ForeignKey("AlbumId")]
    [InverseProperty("Tracks")]
    public virtual Album? Album { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("Tracks")]
    [DisplayName("Género")]
    public virtual Genre? Genre { get; set; }

    [InverseProperty("Track")]
    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    [ForeignKey("MediaTypeId")]
    [InverseProperty("Tracks")]
    public virtual MediaType MediaType { get; set; } = null!;

    [ForeignKey("TrackId")]
    [InverseProperty("Tracks")]
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
