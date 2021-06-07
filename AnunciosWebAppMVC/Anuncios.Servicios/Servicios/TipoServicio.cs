using Anuncios.Servicios.Interfaces;
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
    public class TipoServicio : ITipo
    {
        public async Task<List<Tipo>> GetTiposAsync(string webapi)
        {
            List<Tipo> tipos = new List<Tipo>();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(webapi + "Tipo/");

                using (response = await httpClient.GetAsync(string.Format("Listar")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        tipos = JsonConvert.DeserializeObject<List<Tipo>>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return tipos;
        }


        public async Task<Tipo> GetTipoIdAsync(int? Id, string webapi)
        {
            Tipo tipo = new Tipo();
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(webapi + "Tipo/");

                //using (response = await httpClient.GetAsync(string.Format("Detalle?id=8")))
                using (response = await httpClient.GetAsync(string.Format("Detalle?id={0}", Id)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = "";
                        apiResponse = await response.Content.ReadAsStringAsync();
                        tipo = JsonConvert.DeserializeObject<Tipo>(apiResponse);
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();
                    }

                }
            }
            return tipo;
        }
    }
}
