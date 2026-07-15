using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AgendaPeticiones
{
    public class ConsultarAgenda
    {
        private HttpClient Cliente;
        public ConsultarAgenda(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Agenda>> ConsultarAgendaAsync(int idAgenda)
        {
            Response<Agenda> response = new Response<Agenda>();

            string url = "Agenda/ConsultarAgenda";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idAgenda;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Agenda>>().Result;
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
