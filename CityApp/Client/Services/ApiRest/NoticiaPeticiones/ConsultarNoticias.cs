using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class ConsultarNoticias
    {
        private HttpClient Cliente;
        public ConsultarNoticias(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Noticia>>> ConsultarNoticiasAsync(FiltroNoticias filtroNoticias)
        {
            Response<List<Noticia>> response = new Response<List<Noticia>>();

            string url = "Noticia/ConsultarNoticias";
            Peticion<FiltroNoticias> peticion = new Peticion<FiltroNoticias>();
            peticion.Data = filtroNoticias;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroNoticias>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Noticia>>>().Result;
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
