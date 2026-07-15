using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DiscapacidadPeticiones
{
    public class ConsultarDiscapacidades
    {
        private HttpClient Cliente;
        public ConsultarDiscapacidades(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Discapacidad>>> ConsultarDiscapacidadesAsync()
        {
            Response<List<Discapacidad>> response = new Response<List<Discapacidad>>();

            string url = "Discapacidad/ConsultarDiscapacidades";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Discapacidad>>>().Result;
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
