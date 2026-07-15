using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.RolPeticiones
{
    public class ConsultarRoles
    {
        private HttpClient Cliente;
        public ConsultarRoles (HttpClient cliente)
        {
            Cliente = cliente;  
        }

        public async Task<Response<List<Rol>>> ConsultarRolesAsync()
        {
            Response<List<Rol>> response = new Response<List<Rol>> ();
            string url = "Rol/ConsultarRoles";
            Peticion<object> peticion = new Peticion<object> ();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Rol>>>().Result;
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
