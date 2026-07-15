using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class ConsultarDependenciasFiltro
    {
        private HttpClient Cliente;
        public ConsultarDependenciasFiltro(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Dependencia>>> ConsultarDependenciasFiltroAsync(string token, FiltroDependencia filtroDependencia)
        {
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();

            string url = "Dependencia/ConsultarDependenciasFiltro";
            Peticion<FiltroDependencia> peticion = new Peticion<FiltroDependencia>();
            peticion.Token = token;
            peticion.Data = filtroDependencia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroDependencia>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Dependencia>>>().Result;
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
