using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PostulacionPeticiones
{
    public class CrearPostulacion
    {
        private HttpClient Cliente;
        public CrearPostulacion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearPostulacionAsync(string token, Postulacion postulacion)
        {
            Response<object> response = new Response<object>();

            string url = "Postulacion/CrearPostulacion";
            Peticion<Postulacion> peticion = new Peticion<Postulacion>();
            peticion.Token = token;
            peticion.Data = postulacion;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Postulacion>>(url, peticion);
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
