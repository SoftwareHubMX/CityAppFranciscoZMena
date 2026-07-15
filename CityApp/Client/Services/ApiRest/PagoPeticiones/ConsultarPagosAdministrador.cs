using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PagoPeticiones
{
    public class ConsultarPagosAdministrador
    {
        private HttpClient Cliente;
        public ConsultarPagosAdministrador(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Pago>>> ConsultarPagosAdministradorAsync(string token, FiltroPagos filtroPagos)
        {
            Response<List<Pago>> response = new Response<List<Pago>>();

            string url = "Pago/ConsultarPagosAdministrador";
            Peticion<FiltroPagos> peticion = new Peticion<FiltroPagos>();
            peticion.Token = token;
            peticion.Data = filtroPagos;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroPagos>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Pago>>>().Result;
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
