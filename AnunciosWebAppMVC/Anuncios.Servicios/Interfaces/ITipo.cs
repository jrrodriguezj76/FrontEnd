using AnunciosWebMVC.Anuncios.Servicios.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anuncios.Servicios.Interfaces
{
    public interface ITipo
    {
        Task<List<Tipo>> GetTiposAsync();
        //Task<Anuncio> PostTiposInsert(Anuncio anuncio);
        Task<Tipo> GetTipoIdAsync(int? Id);
        //Task<Anuncio> PostAnuncioUpdate(Anuncio anuncio);
        //Task<Anuncio> PostAnuncioDelete(int? Id);


    }
}