using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class CrearNormatividad
    {
        private HttpClient Cliente;
        public CrearNormatividad(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearNormatividadAsync(string token, Normatividad Normatividad)
        {
            Response<object> response = new Response<object>();

            string url = "Normatividad/CrearNormatividad";
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
