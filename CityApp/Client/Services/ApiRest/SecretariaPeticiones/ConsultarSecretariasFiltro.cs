using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SecretariaPeticiones
{
    public class ConsultarSecretariasFiltro
    {
        private HttpClient Cliente;
        public ConsultarSecretariasFiltro(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Secretaria>>> ConsultarSecretariasFiltroAsync(string token, FiltroSecretaria filtroSecretaria)
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();

            string url = "Secretaria/ConsultarSecretariasFiltro";
            Peticion<FiltroSecretaria> peticion = new Peticion<FiltroSecretaria>();
            peticion.Token = token;
            peticion.Data = filtroSecretaria;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroSecretaria>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Secretaria>>>().Result;
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
