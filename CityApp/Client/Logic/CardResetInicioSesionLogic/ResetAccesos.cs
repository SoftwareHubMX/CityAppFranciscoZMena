using CityApp.Client.Services.ApiRest.ContadorAccesoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardResetInicioSesionLogic
{
    public class ResetAccesos
    {
        private ContadorAccesoPeticiones ContadorAccesoPeticiones;

        public ResetAccesos(HttpClient cliente)
        {
            ContadorAccesoPeticiones = new ContadorAccesoPeticiones(cliente);
        }

        public async Task<Response<object>> Reset(string Token)
        {
            Response<object> response = await ContadorAccesoPeticiones.resetearContador(Token);
            return response;
        }
    }
}
