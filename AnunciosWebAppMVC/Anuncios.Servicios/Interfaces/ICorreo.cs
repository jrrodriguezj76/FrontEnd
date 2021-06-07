using AnunciosWebMVC.Anuncios.Servicios.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anuncios.Servicios.Interfaces
{
    public interface ICorreo
    {
        //Task<List<Correo>> GetCorreosAsync();
        Task<Correo> PostCorreoInsert(Correo correo);
        Task<Correo> GetCorreoIdAsync(int? Id);
        //Task<Anuncio> PostCorreoUpdate(Anuncio anuncio);
        //Task<Anuncio> PostCorreoDelete(int? Id);
    }
}
