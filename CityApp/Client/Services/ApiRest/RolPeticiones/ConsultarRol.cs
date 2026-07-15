using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RolPeticiones
{
    public class ConsultarRol
    {
        private HttpClient Cliente;
        public ConsultarRol(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Rol>> ConsultarRolAsync(int idRol)
        {
            Response<Rol> response = new Response<Rol>();

            string url = "Rol/ConsultarRol";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idRol;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Rol>>().Result;
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
