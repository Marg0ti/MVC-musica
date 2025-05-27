using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("MediaType")]
public partial class MediaType
{
    [Key]
    public int MediaTypeId { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    public string? Name { get; set; }

    [InverseProperty("MediaType")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
