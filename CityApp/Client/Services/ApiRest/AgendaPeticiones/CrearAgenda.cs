using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AgendaPeticiones
{
    public class CrearAgenda
    {
        private HttpClient Cliente;
        public CrearAgenda(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearAgendaAsync(string token, Agenda agenda)
        {
            Response<int> response = new Response<int>();

            string url = "Agenda/CrearAgenda";
            Peticion<Agenda> peticion = new Peticion<Agenda>();
            peticion.Token = token;
            peticion.Data = agenda;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Agenda>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<int>>().Result;
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
