using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class ConsultarNormatividad
    {
        private HttpClient Cliente;
        public ConsultarNormatividad(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Normatividad>> ConsultarNormatividadAsync(string token, int idNormatividad)
        {
            Response<Normatividad> response = new Response<Normatividad>();

            string url = "Normatividad/ConsultarNormatividad";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idNormatividad;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Normatividad>>().Result;
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
