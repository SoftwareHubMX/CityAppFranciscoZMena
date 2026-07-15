using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones
{
    public class ConsultarFiltroRutaRecoleccion
    {
        private HttpClient Cliente;
        public ConsultarFiltroRutaRecoleccion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<RutaRecoleccion>>> ConsultarFiltroRutaRecoleccionAsync(string token, FiltroRutaRecoleccion filtroRutaRecoleccion)
        {
            Response<List<RutaRecoleccion>> response = new Response<List<RutaRecoleccion>>();

            string url = "RutaRecoleccion/ConsultarFiltroRutasRecolecciones";
            Peticion<FiltroRutaRecoleccion> peticion = new Peticion<FiltroRutaRecoleccion>();
            peticion.Token = token;
            peticion.Data = filtroRutaRecoleccion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroRutaRecoleccion>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<RutaRecoleccion>>>().Result;
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
