using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class EliminarNormatividad
    {
        private HttpClient Cliente;
        public EliminarNormatividad(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarNormatividadAsync(string token, int idNormatividad)
        {
            Response<object> response = new Response<object>();

            string url = "Normatividad/EliminarNormatividad";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idNormatividad;
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
