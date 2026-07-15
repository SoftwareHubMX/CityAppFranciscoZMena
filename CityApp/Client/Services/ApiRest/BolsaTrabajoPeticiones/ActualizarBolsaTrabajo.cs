using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones
{
    public class ActualizarBolsaTrabajo
    {
        private HttpClient Cliente;
        public ActualizarBolsaTrabajo(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarBolsaTrabajoAsync(string token, BolsaTrabajo bolsaTrabajo)
        {
            Response<object> response = new Response<object>();

            string url = "BolsaTrabajo/ActualizarBolsaTrabajo";
            Peticion<BolsaTrabajo> peticion = new Peticion<BolsaTrabajo>();
            peticion.Token = token;
            peticion.Data = bolsaTrabajo;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<BolsaTrabajo>>(url, peticion);
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
