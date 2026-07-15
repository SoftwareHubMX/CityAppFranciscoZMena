using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EscolaridadPeticiones
{
    public class ConsultarEscolaridades
    {
        private HttpClient Cliente;
        public ConsultarEscolaridades(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Escolaridad>>> ConsultarEscolaridadesAsync()
        {
            Response<List<Escolaridad>> response = new Response<List<Escolaridad>>();

            string url = "Escolaridad/ConsultarEscolaridades";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Escolaridad>>>().Result;
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
