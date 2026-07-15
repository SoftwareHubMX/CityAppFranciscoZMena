using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones
{
    public class ConsultarContactoSeguridadPublica
    {
        private HttpClient Cliente;
        public ConsultarContactoSeguridadPublica(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<ContactoSeguridadPublica>> ConsultarContactoSeguridadPublicaAsync(string token, int idContactoSeguridadPublica)
        {
            Response<ContactoSeguridadPublica> response = new Response<ContactoSeguridadPublica>();

            string url = "ContactoSeguridadPublica/ConsultarContactoSeguridadPublica";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idContactoSeguridadPublica;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<ContactoSeguridadPublica>>().Result;
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
