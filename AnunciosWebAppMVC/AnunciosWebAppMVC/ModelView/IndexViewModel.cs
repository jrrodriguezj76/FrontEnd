using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnunciosWebMVC.Anuncios.Servicios.Models;

namespace AnunciosWebAppMVC.ModelView
{
    public class IndexViewModel : PaginaModelo
    {
            public List<Anuncio> AnunciosPagina { get; set; }
    }
}
