using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaPeticiones
{
    public class ConsultarAlertaIdAlerta
    {
        private HttpClient Cliente;
        public ConsultarAlertaIdAlerta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Alerta>> ConsultarAlertaIdAlertaAsync(int idAlerta)
        {
            Response<Alerta> response = new Response<Alerta>();

            string url = "Alerta/ConsultarAlertaIdAlerta";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idAlerta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Alerta>>().Result;
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
