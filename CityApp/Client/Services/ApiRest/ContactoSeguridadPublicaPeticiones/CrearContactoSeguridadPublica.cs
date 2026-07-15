using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones
{
    public class CrearContactoSeguridadPublica
    {
        private HttpClient Cliente;
        public CrearContactoSeguridadPublica(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearContactoSeguridadPublicaAsync(string token, ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            Response<object> response = new Response<object>();

            string url = "ContactoSeguridadPublica/CrearContactoSeguridadPublica";
            Peticion<ContactoSeguridadPublica> peticion = new Peticion<ContactoSeguridadPublica>();
            peticion.Token = token;
            peticion.Data = ContactoSeguridadPublica;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<ContactoSeguridadPublica>>(url, peticion);
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
