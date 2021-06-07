
using AnunciosWebMVC.Anuncios.Servicios.DataTransferO;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anuncios.Servicios.Interfaces
{
    public interface IAnuncio
    {
        Task<List<Anuncio>> GetAnunciosAsync();
        Task<List<AnuncioView>> GetAnunciosPaginaAsync(int pagina);
        Task<Anuncio> PostAnuncioInsert(Anuncio anuncio);
        Task<Anuncio> GetAnuncioIdAsync(int? Id);
        Task<Anuncio> PostAnuncioUpdate(Anuncio anuncio);
        Task<Anuncio> PostAnuncioDelete(int? Id);


    }
}
