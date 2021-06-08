using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Routing;

namespace AnunciosWebMVC.Anuncios.Servicios.Models
{
    public class PaginaModelo
    {
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
        public string btitulo { get; set; }
        public string btipo { get; set; }
        public string bmin { get; set; }
        public string bmax { get; set; }
        public RouteValueDictionary ValoresQueryString { get; set; }
    }
}