using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoAtencionContactoPeticiones
{
    public class ConsultarTiposAtencionesContacto
    {
        private HttpClient Cliente;
        public ConsultarTiposAtencionesContacto(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoAtencionContacto>>> ConsultarTiposAtencionesContactoAsync()
        {
            Response<List<TipoAtencionContacto>> response = new Response<List<TipoAtencionContacto>>();

            string url = "TipoAtencionContacto/ConsultarTiposAtencionesContacto";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoAtencionContacto>>>().Result;
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
