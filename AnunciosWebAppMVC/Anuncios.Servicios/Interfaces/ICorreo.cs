using AnunciosWebMVC.Anuncios.Servicios.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anuncios.Servicios.Interfaces
{
    public interface ICorreo
    {
        Task<List<Correo>> GetCorreosAsync(string _webapi);
        Task<Correo> PostCorreoInsert(Correo correo, string _webapi);
        Task<Correo> GetCorreoIdAsync(int? Id, string _webapi);
        //Task<Anuncio> PostCorreoUpdate(Anuncio anuncio);
        //Task<Anuncio> PostCorreoDelete(int? Id);
    }
}
