using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SesionPeticiones
{
    public class ConsultarSesion
    {
        private HttpClient Cliente;
        public ConsultarSesion(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Sesion>> ConsultarSesionAsync(LoginData loginData)
        {
            Response<Sesion> response = new Response<Sesion>();

            string url = "Sesion/ConsultarSesion";
            Peticion<LoginData> peticion = new Peticion<LoginData>();
            peticion.Data = loginData;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<LoginData>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Sesion>>().Result;
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
