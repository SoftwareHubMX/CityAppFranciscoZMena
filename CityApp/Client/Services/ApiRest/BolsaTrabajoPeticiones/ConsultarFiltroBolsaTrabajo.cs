using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones
{
    public class ConsultarFiltroBolsaTrabajo
    {
        private HttpClient Cliente;
        public ConsultarFiltroBolsaTrabajo(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<BolsaTrabajo>>> ConsultarFiltroBolsaTrabajoAsync(string token, FiltroBolsaTrabajo filtroBolsaTrabajo)
        {
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();

            string url = "BolsaTrabajo/ConsultarFiltroBolsaTrabajo";
            Peticion<FiltroBolsaTrabajo> peticion = new Peticion<FiltroBolsaTrabajo>();
            peticion.Token = token;
            peticion.Data = filtroBolsaTrabajo;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroBolsaTrabajo>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<BolsaTrabajo>>>().Result;
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
