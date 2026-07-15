using CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DashBoardPeticiones
{
    public class ConsultarTotalesBolsasTrabajo
    {
        private HttpClient Cliente;

        public ConsultarTotalesBolsasTrabajo(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<DataSet>>> ConsultarTotalesBolsasTrabajoAsync(FiltroTotalBolsasTrabajo filtroTotalesSuperviciones, string token)
        {
            Response<List<DataSet>> response = new Response<List<DataSet>>();

            string url = "DashBoard/ConsultarTotalesBolsasTrabajo";
            Peticion<FiltroTotalBolsasTrabajo> peticion = new Peticion<FiltroTotalBolsasTrabajo>();
            peticion.Token = token;
            peticion.Data = filtroTotalesSuperviciones;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroTotalBolsasTrabajo>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<DataSet>>>().Result;
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
