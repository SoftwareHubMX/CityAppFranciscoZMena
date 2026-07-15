using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoLugarTuisticoPeticiones
{
    public class ConsultaTiposLugarTuristico
    {
        private HttpClient Cliente;
        public ConsultaTiposLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoLugarTuristico>>> ConsultaTiposLugarTuristicoAsync()
        {
            Response<List<TipoLugarTuristico>> response = new Response<List<TipoLugarTuristico>>();

            string url = "TipoLugarTuistico/ConsultaTiposLugarTuristico";
            Peticion<object> peticion = new Peticion<object>();


            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoLugarTuristico>>>().Result;
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
