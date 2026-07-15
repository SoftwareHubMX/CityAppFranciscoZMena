using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones
{
    public class CrearLugarTuristicoPeticion
    {
        private HttpClient Cliente;
        public CrearLugarTuristicoPeticion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearLugarTuristicoAsync(string token, CrearLugarTuristico crearLugarTuristico)
        {
            Response<int> response = new Response<int>();

            string url = "LugarTuristico/CrearLugarTuristico";
            Peticion<CrearLugarTuristico> peticion = new Peticion<CrearLugarTuristico>();
            peticion.Data = crearLugarTuristico;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearLugarTuristico>>(url, peticion);
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
