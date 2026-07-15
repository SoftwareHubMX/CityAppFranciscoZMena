using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones
{
    public class DescargarArchivoAnuncio
    {
        private HttpClient Cliente;
        public DescargarArchivoAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarArchivoAnuncioAsync(string imagen, int idAnuncio)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "ArchivoAnuncio/DescargarArchivoAnuncio";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = imagen;
            peticion.Identificador = idAnuncio.ToString();

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<byte[]>>().Result;
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
