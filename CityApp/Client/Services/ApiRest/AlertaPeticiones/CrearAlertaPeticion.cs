using CityApp.Shared.Models.ControllersModels.AlertaEntradaModel;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaPeticiones
{
    public class CrearAlertaPeticion
    {
        private HttpClient Cliente;
        public CrearAlertaPeticion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearAlertaAsync(CrearAlerta crearAlerta)
        {
            Response<object> response = new Response<object>();

            string url = "Alerta/CrearAlerta";
            Peticion<CrearAlerta> peticion = new Peticion<CrearAlerta>();
            peticion.Data = crearAlerta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearAlerta>>(url, peticion);
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
