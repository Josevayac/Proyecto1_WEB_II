using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace AllBusinesLands.Models
{
    [Table("Bienes")]
    public class Bien
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Detalle { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [DisplayName ("Email Contacto")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName ("Fecha publicado")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [DisplayName("Hora publicado")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraIngreso { get; set; }

        [Required]
        public bool Estado { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}