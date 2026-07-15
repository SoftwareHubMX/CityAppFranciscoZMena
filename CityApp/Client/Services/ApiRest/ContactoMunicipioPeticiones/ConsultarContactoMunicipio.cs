using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones
{
    public class ConsultarContactoMunicipio
    {
        private HttpClient Cliente;
        public ConsultarContactoMunicipio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<ContactoMunicipio>> ConsultarContactoMunicipioAsync(string token, int idContactoMunicipio)
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();

            string url = "ContactoMunicipio/ConsultarContactoMunicipio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idContactoMunicipio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<ContactoMunicipio>>().Result;
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
