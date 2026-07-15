using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EstatusAlertaPeticiones
{
    public class ConsultarEstatusAlerta
    {
        private HttpClient Cliente;
        public ConsultarEstatusAlerta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<EstatusAlerta>>> ConsultarEstatusAlertaAsync()
        {
            Response<List<EstatusAlerta>> response = new Response<List<EstatusAlerta>>();

            string url = "EstatusAlerta/ConsultarEstatusAlerta";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<EstatusAlerta>>>().Result;
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
