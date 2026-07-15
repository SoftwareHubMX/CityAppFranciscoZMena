using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones
{
    public class AgregarArchivoLugarTuristico
    {
        private HttpClient Cliente;
        public AgregarArchivoLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarArchivoLugarTuristicoAsync(MultipartFormDataContent content, int idLugarTuristico, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("ArchivoLugarTuristico/AgregarArchivoLugarTuristico/" + idLugarTuristico + "/" + token, content);

            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<string>>().Result;
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
