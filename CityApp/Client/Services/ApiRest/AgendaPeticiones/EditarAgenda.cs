using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AgendaPeticiones
{
    public class EditarAgenda
    {
        private HttpClient Cliente;
        public EditarAgenda(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EditarAgendaAsync(string token, Agenda agenda)
        {
            Response<object> response = new Response<object>();

            string url = "Agenda/EditarAgenda";
            Peticion<Agenda> peticion = new Peticion<Agenda>();
            peticion.Token = token;
            peticion.Data = agenda;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Agenda>>(url, peticion);
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
