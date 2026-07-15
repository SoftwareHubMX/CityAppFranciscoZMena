using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones
{
    public class EliminarBolsaTrabajo
    {
        private HttpClient Cliente;
        public EliminarBolsaTrabajo(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarBolsaTrabajoAsync(string token, int idBolsaTrabajo)
        {
            Response<object> response = new Response<object>();

            string url = "BolsaTrabajo/EliminarBolsaTrabajo";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idBolsaTrabajo;
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
