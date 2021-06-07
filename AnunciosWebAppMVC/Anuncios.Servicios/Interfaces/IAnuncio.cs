
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
        Task<List<Anuncio>> GetAnunciosAsync(string _webapi);
        Task<List<AnuncioView>> GetAnunciosPaginaAsync(int pagina, string _webapi);
        Task<Anuncio> PostAnuncioInsert(Anuncio anuncio, string _webapi);
        Task<Anuncio> GetAnuncioIdAsync(int? Id, string _webapi);
        Task<Anuncio> PostAnuncioUpdate(Anuncio anuncio, string _webapi);
        Task<Anuncio> PostAnuncioDelete(int? Id, string _webapi);


    }
}
