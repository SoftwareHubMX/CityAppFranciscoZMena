using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PagoPeticiones
{
    public class CrearPagoPeticion
    {
        private HttpClient Cliente;
        public CrearPagoPeticion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<PagoTarjeta>> CrearPagoAsync(int idCuenta, CrearPago crearPago)
        {
            Response<PagoTarjeta> response = new Response<PagoTarjeta>();

            string url = "Pago/CrearPago";
            Peticion<CrearPago> peticion = new Peticion<CrearPago>();
            peticion.Identificador = idCuenta.ToString();
            peticion.Data = crearPago;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearPago>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<PagoTarjeta>>().Result;
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
