using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones
{
    public class ActualizarRutaRecoleccion
    {
        private HttpClient Cliente;
        public ActualizarRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarRutaRecoleccionAsync(string token, RutaRecoleccion rutaRecoleccion)
        {
            Response<object> response = new Response<object>();

            string url = "RutaRecoleccion/ActualizarRutaRecoleccion";
            Peticion<RutaRecoleccion> peticion = new Peticion<RutaRecoleccion>();
            peticion.Token = token;
            peticion.Data = rutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<RutaRecoleccion>>(url, peticion);
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
