using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoNoticiaPeticiones
{
    public class EliminarArchivoNoticia
    {
        private HttpClient Cliente;
        public EliminarArchivoNoticia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoNoticiaAsync(string token, int idArchivoNotocia)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoNoticia/EliminarArchivoNoticia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoNotocia;
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
