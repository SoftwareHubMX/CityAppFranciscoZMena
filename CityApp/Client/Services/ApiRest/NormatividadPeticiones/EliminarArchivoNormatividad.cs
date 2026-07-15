using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class EliminarArchivoNormatividad
    {
        private HttpClient Cliente;
        public EliminarArchivoNormatividad(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoNormatividadAsync(string token, string archivo)
        {
            Response<object> response = new Response<object>();

            string url = "Normatividad/EliminarArchivoNormatividad";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = archivo;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
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
