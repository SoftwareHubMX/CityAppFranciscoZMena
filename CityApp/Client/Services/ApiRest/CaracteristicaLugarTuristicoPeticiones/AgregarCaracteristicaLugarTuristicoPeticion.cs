using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CaracteristicaLugarTuristicoPeticiones
{
    public class AgregarCaracteristicaLugarTuristicoPeticion
    {
        private HttpClient Cliente;
        public AgregarCaracteristicaLugarTuristicoPeticion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> AgregarCaracteristicaLugarTuristicoAsync(string token, AgregarCaracteristicaLugarTuristico agregarCaracteristicaLugarTuristico)
        {
            Response<object> response = new Response<object>();

            string url = "CaracteristicaLugarTuristico/AgregarCaracteristicaLugarTuristico";
            Peticion<AgregarCaracteristicaLugarTuristico> peticion = new Peticion<AgregarCaracteristicaLugarTuristico>();
            peticion.Data = agregarCaracteristicaLugarTuristico;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<AgregarCaracteristicaLugarTuristico>>(url, peticion);
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
