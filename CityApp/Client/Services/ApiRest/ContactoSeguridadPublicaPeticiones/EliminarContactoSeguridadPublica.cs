using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones
{
    public class EliminarContactoSeguridadPublica
    {
        private HttpClient Cliente;
        public EliminarContactoSeguridadPublica(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarContactoSeguridadPublicaAsync(string token, int idContactoSeguridadPublica)
        {
            Response<object> response = new Response<object>();

            string url = "ContactoSeguridadPublica/EliminarContactoSeguridadPublica";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idContactoSeguridadPublica;
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
