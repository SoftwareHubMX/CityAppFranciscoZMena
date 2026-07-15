using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ContadorAccesoPeticiones
{
    public class ContadorAccesoPeticiones
    {
        private ResetearContador ResetearContador;

        public ContadorAccesoPeticiones(HttpClient cliente)
        {
            ResetearContador = new ResetearContador(cliente);
        }

        public async Task<Response<object>> resetearContador(string token)
        {
            Response<object> response = await ResetearContador.ResetearContadorAsync(token);
            return response;
        }
    }
}
