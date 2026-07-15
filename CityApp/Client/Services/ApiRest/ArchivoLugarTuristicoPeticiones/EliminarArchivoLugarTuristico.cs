using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones
{
    public class EliminarArchivoLugarTuristico
    {
        private HttpClient Cliente;
        public EliminarArchivoLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoLugarTuristicoAsync(string token, int idArchivoLugarTuristico)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoLugarTuristico/EliminarArchivoLugarTuristico";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoLugarTuristico;
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
