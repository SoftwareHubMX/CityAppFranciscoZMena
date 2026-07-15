using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;
using CityApp.Shared.Entities.BDSqlServerCityApp;

namespace CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones
{
    public class CrearRutaRecoleccion
    {
        private HttpClient Cliente;
        public CrearRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearRutaRecoleccionAsync(string token, RutaRecoleccion rutaRecoleccion)
        {
            Response<int> response = new Response<int>();

            string url = "RutaRecoleccion/CrearRutaRecoleccion";
            Peticion<RutaRecoleccion> peticion = new Peticion<RutaRecoleccion>();
            peticion.Token = token;
            peticion.Data = rutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<RutaRecoleccion>>(url, peticion);
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
