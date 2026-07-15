using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CitaPeticiones
{
    public class CrearCita
    {
        private HttpClient Cliente;
        public CrearCita(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearCitaAsync(string token, Cita cita)
        {
            Response<object> response = new Response<object>();

            string url = "Cita/CrearCita";
            Peticion<Cita> peticion = new Peticion<Cita>();
            peticion.Token = token;
            peticion.Data = cita;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Cita>>(url, peticion);
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
