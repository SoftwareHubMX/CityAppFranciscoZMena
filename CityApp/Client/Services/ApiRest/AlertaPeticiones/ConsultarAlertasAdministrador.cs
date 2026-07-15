using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaPeticiones
{
    public class ConsultarAlertasAdministrador
    {
        private HttpClient Cliente;
        public ConsultarAlertasAdministrador(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Alerta>>> ConsultarAlertasAdministradorAsync(string token, int idEstatusAlerta)
        {
            Response<List<Alerta>> response = new Response<List<Alerta>>();

            string url = "Alerta/ConsultarAlertasAdministrador";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idEstatusAlerta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Alerta>>>().Result;
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
