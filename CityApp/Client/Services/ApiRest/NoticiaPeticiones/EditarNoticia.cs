using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class EditarNoticia
    {
        private HttpClient Cliente;
        public EditarNoticia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EditarNoticiaAsync(string token, Noticia noticia)
        {
            Response<object> response = new Response<object>();

            string url = "Noticia/EditarNoticia";
            Peticion<Noticia> peticion = new Peticion<Noticia>();
            peticion.Token = token;
            peticion.Data = noticia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Noticia>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<object>>().Result;
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
