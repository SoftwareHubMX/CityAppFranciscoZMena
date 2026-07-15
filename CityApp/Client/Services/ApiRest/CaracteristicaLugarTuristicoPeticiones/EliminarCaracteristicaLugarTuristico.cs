using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CaracteristicaLugarTuristicoPeticiones
{
    public class EliminarCaracteristicaLugarTuristico
    {
        private HttpClient Cliente;
        public EliminarCaracteristicaLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarCaracteristicaLugarTuristicoAsync(string token, int idCaracteristicaLugarTuristico)
        {
            Response<object> response = new Response<object>();

            string url = "CaracteristicaLugarTuristico/EliminarCaracteristicaLugarTuristico";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idCaracteristicaLugarTuristico;
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
