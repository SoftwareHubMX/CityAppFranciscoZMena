using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones
{
    public class CrearContactoMunicipio
    {
        private HttpClient Cliente;
        public CrearContactoMunicipio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearContactoMunicipioAsync(string token, ContactoMunicipio ContactoMunicipio)
        {
            Response<int> response = new Response<int>();

            string url = "ContactoMunicipio/CrearContactoMunicipio";
            Peticion<ContactoMunicipio> peticion = new Peticion<ContactoMunicipio>();
            peticion.Token = token;
            peticion.Data = ContactoMunicipio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<ContactoMunicipio>>(url, peticion);
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
