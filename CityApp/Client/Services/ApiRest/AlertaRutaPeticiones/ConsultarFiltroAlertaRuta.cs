using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaRutaPeticiones
{
    public class ConsultarFiltroAlertaRuta
    {
        private HttpClient Cliente;
        public ConsultarFiltroAlertaRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<AlertaRuta>>> ConsultarFiltroAlertaRutaAsync(string token, FiltroAlertaRuta filtroAlertaRuta)
        {
            Response<List<AlertaRuta>> response = new Response<List<AlertaRuta>>();

            string url = "AlertaRuta/ConsultarFiltroAlertaRuta";
            Peticion<FiltroAlertaRuta> peticion = new Peticion<FiltroAlertaRuta>();
            peticion.Token = token;
            peticion.Data = filtroAlertaRuta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroAlertaRuta>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<AlertaRuta>>>().Result;
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
