using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TramitePeticiones
{
    public class EliminarTramite
    {
        private HttpClient Cliente;
        public EliminarTramite(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarTramiteAsync(string token, int idTramite)
        {
            Response<object> response = new Response<object>();

            string url = "Tramite/EliminarTramite";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idTramite;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
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
