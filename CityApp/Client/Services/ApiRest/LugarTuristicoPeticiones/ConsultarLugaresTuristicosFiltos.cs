using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones
{
    public class ConsultarLugaresTuristicosFiltos
    {
        private HttpClient Cliente;
        public ConsultarLugaresTuristicosFiltos(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<LugarTuristico>>> ConsultarLugaresTuristicosFiltosAsync(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            Response<List<LugarTuristico>> response = new Response<List<LugarTuristico>>();

            string url = "LugarTuristico/ConsultarLugaresTuristicosFiltos";
            Peticion<FiltroLugaresTuristicos> peticion = new Peticion<FiltroLugaresTuristicos>();
            peticion.Data = filtroLugaresTuristicos;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroLugaresTuristicos>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<LugarTuristico>>>().Result;
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
