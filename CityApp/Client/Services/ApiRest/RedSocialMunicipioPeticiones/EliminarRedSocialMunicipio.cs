using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RedSocialMunicipioPeticiones
{
    public class EliminarRedSocialMunicipio
    {
        private HttpClient Cliente;
        public EliminarRedSocialMunicipio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarRedSocialMunicipioAsync(string token, int idRedSocialMunicipio)
        {
            Response<object> response = new Response<object>();

            string url = "RedSocialMunicipio/EliminarRedSocialMunicipio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idRedSocialMunicipio;
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
