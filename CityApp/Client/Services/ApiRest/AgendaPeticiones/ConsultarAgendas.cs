using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AgendaPeticiones
{
    public class ConsultarAgendas
    {
        private HttpClient Cliente;
        public ConsultarAgendas(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Agenda>>> ConsultarAgendasAsync(FiltroAgenda filtroAgendas)
        {
            Response<List<Agenda>> response = new Response<List<Agenda>>();

            string url = "Agenda/ConsultarAgendas";
            Peticion<FiltroAgenda> peticion = new Peticion<FiltroAgenda>();
            peticion.Data = filtroAgendas;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroAgenda>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Agenda>>>().Result;
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
