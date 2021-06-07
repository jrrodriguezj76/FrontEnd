using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AnunciosWebMVC.Models
{
    public partial class Correo
    {
        public int IdCorreo { get; set; }
        [StringLength(50, ErrorMessage = "Nombre no debe ser mayor a 50 caracteres")]
        [Required( ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }
        [EmailAddress(ErrorMessage = "Utilice formato de correo correcto")]
        [Required(ErrorMessage = "Correo es obligatorio")]
        public string Correo1 { get; set; }
        [Required(ErrorMessage = "Mensaje es obligatorio")]
        [StringLength(100, ErrorMessage = "Nombre no debe ser mayor a 100 caracteres")]
        public string Mensaje { get; set; }
    }
}
