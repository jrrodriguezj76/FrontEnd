using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnunciosWebAppMVC.ModelView
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
