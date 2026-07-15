using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones
{
    public class ConsultarLugarTuristico
    {
        private HttpClient Cliente;
        public ConsultarLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<LugarTuristico>> ConsultarLugareTuristicoAsync(int idLugarTuristico)
        {
            Response<LugarTuristico> response = new Response<LugarTuristico>();

            string url = "LugarTuristico/ConsultarLugarTuristico";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idLugarTuristico;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<LugarTuristico>>().Result;
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
