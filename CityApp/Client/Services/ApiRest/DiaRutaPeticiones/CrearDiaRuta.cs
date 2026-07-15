using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DiaRutaPeticiones
{
    public class CrearDiaRuta
    {
        private HttpClient Cliente;
        public CrearDiaRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearDiaRutaAsync(string token, DiaRuta diaRuta)
        {
            Response<object> response = new Response<object>();

            string url = "DiaRutaRecoleccion/CrearDiaRuta";
            Peticion<DiaRuta> peticion = new Peticion<DiaRuta>();
            peticion.Token = token;
            peticion.Data = diaRuta;
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
