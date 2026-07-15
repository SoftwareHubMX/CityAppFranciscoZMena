using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class ActualizarNormatividad
    {
        private HttpClient Cliente;
        public ActualizarNormatividad(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarNormatividadAsync(string token, Normatividad Normatividad)
        {
            Response<object> response = new Response<object>();

            string url = "Normatividad/ActualizarNormatividad";
            Peticion<Normatividad> peticion = new Peticion<Normatividad>();
            peticion.Token = token;
            peticion.Data = Normatividad;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Normatividad>>(url, peticion);
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
