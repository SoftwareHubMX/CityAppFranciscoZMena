using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones
{
    public class EditarLugarTuristico
    {
        private HttpClient Cliente;
        public EditarLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EditarLugarTuristicoAsync(string token, LugarTuristico lugarTuristico)
        {
            Response<object> response = new Response<object>();

            string url = "LugarTuristico/EditarLugarTuristico";
            Peticion<LugarTuristico> peticion = new Peticion<LugarTuristico>();
            peticion.Data = lugarTuristico;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<LugarTuristico>>(url, peticion);
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
