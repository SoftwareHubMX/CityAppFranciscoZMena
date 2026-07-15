using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AgendaPeticiones
{
    public class EliminarAgenda
    {
        private HttpClient Cliente;
        public EliminarAgenda(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarAgendaAsync(string token, int idAgenda)
        {
            Response<object> response = new Response<object>();

            string url = "Agenda/EliminarAgenda";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idAgenda;
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
