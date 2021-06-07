using Anuncios.Servicios.Interfaces;
using AnunciosWebMVC.Anuncios.Servicios.DataTransferO;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Anuncios.Servicios.Servicios
{
    public class AnuncioServicio : IAnuncio
    {
        public async Task<List<Anuncio>> GetAnunciosAsync()
        {
            List<Anuncio> anuncios = new List<Anuncio>();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Anuncio/");

                using (response = await httpClient.GetAsync(string.Format("Listar")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        anuncios = JsonConvert.DeserializeObject<List<Anuncio>>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return anuncios;
        }

        public async Task<List<AnuncioView>> GetAnunciosPaginaAsync(int pagina)
        {
            List<AnuncioView> anuncios = new List<AnuncioView>();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Anuncio/");

                using (response = await httpClient.GetAsync(string.Format("ListarPagina?pagina={0}", pagina)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        anuncios = JsonConvert.DeserializeObject<List<AnuncioView>>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return anuncios;
        }

        public async Task<Anuncio> GetAnuncioIdAsync(int? Id)
        {
            Anuncio anuncio = new Anuncio();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Anuncio/");

                //using (response = await httpClient.GetAsync(string.Format("Detalle?id=8")))
                using (response = await httpClient.GetAsync(string.Format("Detalle?id={0}", Id)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        anuncio = JsonConvert.DeserializeObject<Anuncio>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return anuncio;
        }

        public async Task<Anuncio> PostAnuncioInsert(Anuncio anuncio)
        {
            HttpResponseMessage response;
            Anuncio anuncioDto = new Anuncio();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Anuncio/Registrar");

                using (response = await httpClient.PostAsync("", anuncio, new JsonMediaTypeFormatter()))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        anuncioDto = JsonConvert.DeserializeObject<Anuncio>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            return anuncioDto;
        }

        public async Task<Anuncio> PostAnuncioUpdate(Anuncio anuncio)
        {
            HttpResponseMessage response;
            Anuncio anuncioDto = new Anuncio();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Anuncio/");

                using (response = await httpClient.PostAsync(string.Format("Modificar?id={0}", anuncio.Id), anuncio, new JsonMediaTypeFormatter()))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        anuncioDto = JsonConvert.DeserializeObject<Anuncio>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            return anuncioDto;
        }

        public async Task<Anuncio> PostAnuncioDelete(int? Id)
        {
            HttpResponseMessage response;
            Anuncio anuncioDto = new Anuncio();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Anuncio/");

                using (response = await httpClient.PostAsync(string.Format("Borrar?id={0}", Id), anuncioDto, new JsonMediaTypeFormatter()))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        //anuncioDto = JsonConvert.DeserializeObject<Anuncio>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            return anuncioDto;
        }

    }
    
}
