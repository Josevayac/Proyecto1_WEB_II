using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AllBusinesLands.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="N° Anuncio")]
        public int BienId { get; set; }
        
        public string UserId { get; set; }

        [Required]
        public string Contenido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraIngreso { get; set; }

        public bool Estado { get; set; }

        public virtual Bien Bien { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}