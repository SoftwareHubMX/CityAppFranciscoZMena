using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DirectorioPeticiones
{
    public class ConsultarDirectorios
    {
        private HttpClient Cliente;
        public ConsultarDirectorios(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Directorio>>> ConsultarDirectoriosAsync(string token, FiltroDirectorio filtroDirectorio)
        {
            Response<List<Directorio>> response = new Response<List<Directorio>>();

            string url = "Directorio/ConsultarDirectoriosFiltro";
            Peticion<FiltroDirectorio> peticion = new Peticion<FiltroDirectorio>();
            peticion.Token = token;
            peticion.Data = filtroDirectorio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroDirectorio>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Directorio>>>().Result;
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
