using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class ConsultarCuentasFiltroCuentas
    {
        private HttpClient Cliente;
        public ConsultarCuentasFiltroCuentas(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Cuenta>>> ConsultarCuentasFiltroCuentasAsync(FiltroCuentas filtroCuentas)
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();

            string url = "Cuenta/ConsultarCuentasFiltroCuentas";
            Peticion<FiltroCuentas> peticion = new Peticion<FiltroCuentas>();
            peticion.Data = filtroCuentas;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroCuentas>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Cuenta>>>().Result;
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
