using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaPeticiones
{
    public class ActualizarEstatusAlerta
    {
        private HttpClient Cliente;
        public ActualizarEstatusAlerta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarEstatusAlertaAsync(string token, int idAlerta, int idEstatusAlerta)
        {
            Response<object> response = new Response<object>();

            string url = "Alerta/ActualizarEstatusAlerta";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Identificador = idAlerta.ToString();
            peticion.Data = idEstatusAlerta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
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
