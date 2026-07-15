using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones
{
    public class ConsultarContactosSeguridadPublica
    {
        private HttpClient Cliente;
        public ConsultarContactosSeguridadPublica(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<ContactoSeguridadPublica>>> ConsultarContactosSeguridadPublicaAsync(string token)
        {
            Response<List<ContactoSeguridadPublica>> response = new Response<List<ContactoSeguridadPublica>>();

            string url = "ContactoSeguridadPublica/ConsultarContactosSeguridadPublica";
            Peticion<object> peticion = new Peticion<object>();
            //peticion.Token = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<ContactoSeguridadPublica>>>().Result;
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
