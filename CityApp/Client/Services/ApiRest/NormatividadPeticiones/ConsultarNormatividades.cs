using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class ConsultarNormatividades
    {
        private HttpClient Cliente;
        public ConsultarNormatividades(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Normatividad>>> ConsultarNormatividadesAsync(string token)
        {
            Response<List<Normatividad>> response = new Response<List<Normatividad>>();

            string url = "Normatividad/ConsultarNormatividades";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Normatividad>>>().Result;
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
