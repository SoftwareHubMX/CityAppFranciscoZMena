using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PostulacionPeticiones
{
    public class ConsultarFiltroPostulaciones
    {
        private HttpClient Cliente;
        public ConsultarFiltroPostulaciones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Postulacion>>> ConsultarFiltroPostulacionesAsync(string token, FiltroPostulacion filtroPostulacion)
        {
            Response<List<Postulacion>> response = new Response<List<Postulacion>>();

            string url = "Postulacion/ConsultarFiltroPostulacion";
            Peticion<FiltroPostulacion> peticion = new Peticion<FiltroPostulacion>();
            peticion.Token = token;
            peticion.Data = filtroPostulacion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroPostulacion>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Postulacion>>>().Result;
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
