using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones
{
    public class EliminarArchivoAnuncio
    {
        private HttpClient Cliente;
        public EliminarArchivoAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoAnuncioAsync(string token, int idArchivoAnuncio)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoAnuncio/EliminarArchivoAnuncio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoAnuncio;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
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
