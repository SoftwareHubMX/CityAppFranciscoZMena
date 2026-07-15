using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class CrearNoticia
    {
        private HttpClient Cliente;
        public CrearNoticia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearNoticiaAsync(string token, Noticia noticia)
        {
            Response<int> response = new Response<int>();

            string url = "Noticia/CrearNoticia";
            Peticion<Noticia> peticion = new Peticion<Noticia>();
            peticion.Token = token;
            peticion.Data = noticia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Noticia>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<int>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            return response;
        }
    }
}
