using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AnuncioPeticiones
{
    public class EditarAnuncio
    {
        private HttpClient Cliente;
        public EditarAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EditarAnuncioAsync(string token, Anuncio anuncio)
        {
            Response<object> response = new Response<object>();

            string url = "Anuncio/EditarAnuncio";
            Peticion<Anuncio> peticion = new Peticion<Anuncio>();
            peticion.Token = token;
            peticion.Data = anuncio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Anuncio>>(url, peticion);
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
