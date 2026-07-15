using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones
{
    public class ConsultarRutaRecoleccion
    {
        private HttpClient Cliente;
        public ConsultarRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<RutaRecoleccion>> ConsultarRutaRecoleccionAsync(string token, int idRutaRecoleccion)
        {
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();

            string url = "RutaRecoleccion/ConsultarRutaRecoleccion";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idRutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<RutaRecoleccion>>().Result;
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
