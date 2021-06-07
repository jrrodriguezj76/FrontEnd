using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnunciosWebMVC.Anuncios.Servicios.Models.ModelView
{
    public class AnunciosView
    {
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        public int Tipo { get; set; }
        public double Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}
