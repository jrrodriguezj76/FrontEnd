using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AnunciosWebMVC.Models
{
    public partial class Anuncio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string Titulo { get; set; }
        public int IdTipo { get; set; }
        public double Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}
