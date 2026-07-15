using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AnuncioPeticiones
{
    public class ConsultarAnuncio
    {
        private HttpClient Cliente;
        public ConsultarAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Anuncio>> ConsultarAnuncioAsync(int idAnuncio)
        {
            Response<Anuncio> response = new Response<Anuncio>();

            string url = "Anuncio/ConsultarAnuncio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idAnuncio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Anuncio>>().Result;
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
