using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DiaRutaPeticiones
{
    public class ConsultarDiasRuta
    {
        private HttpClient Cliente;
        public ConsultarDiasRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }
        public async Task<Response<List<DiaRuta>>> ConsultarDiasRutaAsync(int idRutaRecoleccion)
        {
            Response<List<DiaRuta>> response = new Response<List<DiaRuta>>();

            string url = "DiaRuta/ConsultarDiasRuta";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idRutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<DiaRuta>>>().Result;
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
