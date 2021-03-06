﻿using System;
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
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [DisplayName("Hora de ingreso")]
        public DateTime HoraIngreso { get; set; }

        [Required]
        public bool Estado { get; set; }

        public string image_path { set; get; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}