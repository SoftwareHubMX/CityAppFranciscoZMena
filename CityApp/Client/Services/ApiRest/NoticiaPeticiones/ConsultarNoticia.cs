using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class ConsultarNoticia
    {
        private HttpClient Cliente;
        public ConsultarNoticia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Noticia>> ConsultarNoticiaAsync(int idNoticia)
        {
            Response<Noticia> response = new Response<Noticia>();

            string url = "Noticia/ConsultarNoticia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idNoticia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Noticia>>().Result;
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
