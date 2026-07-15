using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DiaRutaPeticiones
{
    public class EliminarDiaRuta
    {
        private HttpClient Cliente;

        public EliminarDiaRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarDiaRutaIdAsync(string token, DiaRuta diaRuta)
        {
            Response<object> response = new Response<object>();

            string url = "DiaRutaRecoleccion/EliminarDiaRuta";
            Peticion<DiaRuta> peticion = new Peticion<DiaRuta>();
            peticion.Data = diaRuta;
            peticion.Token = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<DiaRuta>>(url, peticion);
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
