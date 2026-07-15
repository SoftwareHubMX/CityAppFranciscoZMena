using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones
{
    public class EliminarColoniaRutaRecoleccion
    {
        private HttpClient Cliente;
        public EliminarColoniaRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarColoniaRutaRecoleccionAsync(string token, ColoniaRutaRecoleccion ColoniaRutaRecoleccion)
        {
            Response<object> response = new Response<object>();

            string url = "ColoniaRutaRecoleccion/EliminarColoniaRutaRecoleccion";
            Peticion<ColoniaRutaRecoleccion> peticion = new Peticion<ColoniaRutaRecoleccion>();
            peticion.Token = token;
            peticion.Data = ColoniaRutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<ColoniaRutaRecoleccion>>(url, peticion);
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
