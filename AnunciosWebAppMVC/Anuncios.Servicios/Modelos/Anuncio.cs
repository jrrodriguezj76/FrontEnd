using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AnunciosWebMVC.Anuncios.Servicios.Models
{
    public partial class Anuncio
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Titulo no debe ser mayor a 50 caracteres")]
        [Required(ErrorMessage = "Titulo es obligatorio")]
        public string Titulo { get; set; }
        public int IdTipo { get; set; }
        [Range(0, 999999999999.99)]
        [Required(ErrorMessage = "Precio es obligatorio")]
        public double Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}
