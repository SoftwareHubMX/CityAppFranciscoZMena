using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones
{
    public class ConsultarBolsaTrabajo
    {
        private HttpClient Cliente;
        public ConsultarBolsaTrabajo(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<BolsaTrabajo>> ConsultarBolsaTrabajoAsync(string token, int idBolsaTrabajo)
        {
            Response<BolsaTrabajo> response = new Response<BolsaTrabajo>();

            string url = "BolsaTrabajo/ConsultarBolsaTrabajo";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idBolsaTrabajo;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<BolsaTrabajo>>().Result;
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
