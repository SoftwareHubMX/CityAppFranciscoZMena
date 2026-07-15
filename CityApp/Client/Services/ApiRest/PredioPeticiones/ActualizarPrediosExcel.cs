using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PredioPeticiones
{
    public class ActualizarPrediosExcel
    {
        private HttpClient Cliente;
        public ActualizarPrediosExcel(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarPrediosExcelAsync(string token, string excel)
        {
            Response<object> response = new Response<object>();

            string url = "Predio/ActualizarPrediosExcel";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Token = token;
            peticion.Data = excel;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
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
