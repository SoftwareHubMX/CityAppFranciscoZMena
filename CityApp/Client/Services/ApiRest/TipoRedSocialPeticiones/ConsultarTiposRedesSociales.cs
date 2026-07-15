using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoRedSocialPeticiones
{
    public class ConsultarTiposRedesSociales
    {
        private HttpClient Cliente;
        public ConsultarTiposRedesSociales(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoRedSocial>>> ConsultarTiposRedesSocialesAsync()
        {
            Response<List<TipoRedSocial>> response = new Response<List<TipoRedSocial>>();

            string url = "TipoRedSocial/ConsultarTiposRedesSociales";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoRedSocial>>>().Result;
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
