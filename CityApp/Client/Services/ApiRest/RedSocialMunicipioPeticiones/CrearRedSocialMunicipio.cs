using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RedSocialMunicipioPeticiones
{
    public class CrearRedSocialMunicipio
    {
        private HttpClient Cliente;
        public CrearRedSocialMunicipio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearRedSocialMunicipioAsync(string token, RedSocialMunicipio RedSocialMunicipio)
        {
            Response<int> response = new Response<int>();

            string url = "RedSocialMunicipio/CrearRedSocialMunicipio";
            Peticion<RedSocialMunicipio> peticion = new Peticion<RedSocialMunicipio>();
            peticion.Data = RedSocialMunicipio;
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<RedSocialMunicipio>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<int>>().Result;
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
