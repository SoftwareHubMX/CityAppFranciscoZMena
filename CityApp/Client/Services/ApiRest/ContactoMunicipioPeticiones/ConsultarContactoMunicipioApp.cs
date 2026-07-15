using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones
{
    public class ConsultarContactoMunicipioApp
    {
        private HttpClient Cliente;
        public ConsultarContactoMunicipioApp(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<ContactoMunicipio>> ConsultarContactoMunicipioAppAsync()
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();

            string url = "ContactoMunicipio/ConsultarContactoMunicipioApp";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
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
