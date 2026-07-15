using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AnuncioPeticiones
{
    public class CrearAnuncio
    {
        private HttpClient Cliente;
        public CrearAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearAnuncioAsync(string token, Anuncio anuncio)
        {
            Response<int> response = new Response<int>();

            string url = "Anuncio/CrearAnuncio";
            Peticion<Anuncio> peticion = new Peticion<Anuncio>();
            peticion.Token = token;
            peticion.Data = anuncio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Anuncio>>(url, peticion);
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
