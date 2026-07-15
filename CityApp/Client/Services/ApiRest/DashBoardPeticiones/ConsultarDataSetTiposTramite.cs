using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DashBoardPeticiones
{
    public class ConsultarDataSetTiposTramite
    {
        private HttpClient Cliente;
        public ConsultarDataSetTiposTramite(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<ChartData>>> ConsultarTiposTramiteAsync(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();

            string url = "DashBoard/ConsultarTiposTramite";
            Peticion<FechasDashBoard> peticion = new Peticion<FechasDashBoard>();
            peticion.Token = token;
            peticion.Data = fechasDashBoard;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FechasDashBoard>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<ChartData>>>().Result;
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
