using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAut_HernandezMargot.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Máximo 20 caracteres")]
        [DisplayName("Título")]
        public string? Title { get; set; }

        [StringLength(220)]
        [Required(ErrorMessage = "Máximo 220 caracteres")]
        [DisplayName("Comentario")]
        public string? ReviewContent { get; set; }

        [Range(1, 10, ErrorMessage = "Puntuación entre 1 y 10")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [DisplayName("Puntuación")]
        public int Rating { get; set; }

        public int ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        [InverseProperty("Reviews")]   // No se va a meter en la base de datos, si no se pone da error a la hora de hacer la migracion
        public virtual Artist? Artist { get; set; } = null!;
    }


}
