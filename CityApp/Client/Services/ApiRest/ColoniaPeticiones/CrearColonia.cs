using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ColoniaPeticiones
{
    public class CrearColonia
    {
        private HttpClient Cliente;
        public CrearColonia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearColoniaAsync(string token, Colonia colonia)
        {
            Response<object> response = new Response<object>();

            string url = "Colonia/CrearColonia";
            Peticion<Colonia> peticion = new Peticion<Colonia>();
            peticion.Token = token;
            peticion.Data = colonia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Colonia>>(url, peticion);
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
