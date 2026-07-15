using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CitaPeticiones
{
    public class ConsultarCitas
    {
        private HttpClient Cliente;
        public ConsultarCitas(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Cita>>> ConsultarFiltroCitasAsync(string token, FiltroCitas filtroCita)
        {
            Response<List<Cita>> response = new Response<List<Cita>>();

            string url = "Cita/ConsultarFiltroCitas";
            Peticion<FiltroCitas> peticion = new Peticion<FiltroCitas>();
            peticion.Token = token;
            peticion.Data = filtroCita;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroCitas>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Cita>>>().Result;
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
