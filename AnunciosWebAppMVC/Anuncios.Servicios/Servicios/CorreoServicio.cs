using Anuncios.Servicios.Interfaces;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Correos.Servicios.Servicios
{
    public class CorreoServicio : ICorreo
    {
        public async Task<List<Correo>> GetCorreosAsync(string webapi)
        {
            List<Correo> correos = new List<Correo>();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(webapi + "Correo/");

                using (response = await httpClient.GetAsync(string.Format("Listar")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        correos = JsonConvert.DeserializeObject<List<Correo>>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return correos;
        }
        public async Task<Correo> GetCorreoIdAsync(int? Id, string webapi)
        {
            Correo correo = new Correo();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(webapi + "Correo/");

                //using (response = await httpClient.GetAsync(string.Format("Detalle?id=8")))
                using (response = await httpClient.GetAsync(string.Format("Detalle?id={0}", Id)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        correo = JsonConvert.DeserializeObject<Correo>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return correo;
        }

        public async Task<Correo> PostCorreoInsert(Correo correo, string webapi)
        {
            HttpResponseMessage response;
            Correo correoDto = new Correo();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(webapi + "Correo/Registrar");

                using (response = await httpClient.PostAsync("", correo, new JsonMediaTypeFormatter()))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        correoDto = JsonConvert.DeserializeObject<Correo>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            return correoDto;
        }
    }
}
