using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DashBoardPeticiones
{
    public class ConsultarUltimosIngresos
    {
        private HttpClient Cliente;
        public ConsultarUltimosIngresos(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<UltimoPago>>> ConsultarUltimosIngresosAsync(string token)
        {
            Response<List<UltimoPago>> response = new Response<List<UltimoPago>>();

            string url = "DashBoard/ConsultarUltimosIngresos";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<UltimoPago>>>().Result;
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
