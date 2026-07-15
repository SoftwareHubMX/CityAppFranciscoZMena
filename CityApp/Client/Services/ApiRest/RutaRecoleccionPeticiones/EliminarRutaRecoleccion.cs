using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones
{
    public class EliminarRutaRecoleccion
    {
        private HttpClient Cliente;
        public EliminarRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarRutaRecoleccionAsync(string token, int idRutaRecoleccion)
        {
            Response<object> response = new Response<object>();

            string url = "RutaRecoleccion/EliminarRutaRecoleccion";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idRutaRecoleccion;
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
