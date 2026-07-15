using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoCitaPeticiones
{
    public class ConsultarTiposCita
    {
        private HttpClient Cliente;
        public ConsultarTiposCita(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoCita>>> ConsultaTiposCitaAsync()
        {
            Response<List<TipoCita>> response = new Response<List<TipoCita>>();

            string url = "TipoCita/ConsultaTiposCita";
            Peticion<object> peticion = new Peticion<object>();


            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoCita>>>().Result;
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
