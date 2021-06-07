using Anuncios.Servicios.Interfaces;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Correos.Servicios.Servicios
{
    public class CorreoServicio : ICorreo
    {
        public async Task<Correo> GetCorreoIdAsync(int? Id)
        {
            Correo correo = new Correo();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Correo/");

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

        public async Task<Correo> PostCorreoInsert(Correo correo)
        {
            HttpResponseMessage response;
            Correo correoDto = new Correo();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:34696/api/Correo/Registrar");

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
