using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones
{
    public class ConsultarColoniasRutaRecoleccion
    {
        private HttpClient Cliente;
        public ConsultarColoniasRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }
        public async Task<Response<List<ColoniaRutaRecoleccion>>> ConsultarColoniasRutaRecoleccionAsync(string token, int idRutaRecoleccion)
        {
            Response<List<ColoniaRutaRecoleccion>> response = new Response<List<ColoniaRutaRecoleccion>>();

            string url = "ColoniaRutaRecoleccion/ConsultarColoniasRutaRecoleccion";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idRutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<ColoniaRutaRecoleccion>>>().Result;
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
