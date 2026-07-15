using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones
{
    public class ActualizarContactoMunicipio
    {
        private HttpClient Cliente;
        public ActualizarContactoMunicipio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarContactoMunicipioAsync(string token, ContactoMunicipio ContactoMunicipio)
        {
            Response<object> response = new Response<object>();

            string url = "ContactoMunicipio/ActualizarContactoMunicipio";
            Peticion<ContactoMunicipio> peticion = new Peticion<ContactoMunicipio>();
            peticion.Token = token;
            peticion.Data = ContactoMunicipio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<ContactoMunicipio>>(url, peticion);
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
