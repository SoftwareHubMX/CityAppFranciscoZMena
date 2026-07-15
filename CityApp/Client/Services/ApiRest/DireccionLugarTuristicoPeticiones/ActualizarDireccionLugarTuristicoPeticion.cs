using CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DireccionLugarTuristicoPeticiones
{
    public class ActualizarDireccionLugarTuristicoPeticion
    {
        private HttpClient Cliente;
        public ActualizarDireccionLugarTuristicoPeticion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarDireccionLugarTuristicoAsync(string token, ActualizarDireccionLugarTuristico actualizarDireccionLugarTuristico)
        {
            Response<object> response = new Response<object>();

            string url = "DireccionLugarTuristico/ActualizarDireccionLugarTuristico";
            Peticion<ActualizarDireccionLugarTuristico> peticion = new Peticion<ActualizarDireccionLugarTuristico>();
            peticion.Data = actualizarDireccionLugarTuristico;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<ActualizarDireccionLugarTuristico>>(url, peticion);
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
