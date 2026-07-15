using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoAgendaPeticiones
{
    public class EliminarArchivoAgenda
    {
        private HttpClient Cliente;
        public EliminarArchivoAgenda(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoAgendaAsync(string token, int idArchivoNotocia)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoAgenda/EliminarArchivoAgenda";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoNotocia;
            peticion.Token = token;

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
