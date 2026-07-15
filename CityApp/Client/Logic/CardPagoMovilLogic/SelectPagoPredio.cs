using CityApp.Client.Services.ApiRest.PredioPeticiones;
using CityApp.Shared.Models.ControllersModels.PredioSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardPagoMovilLogic
{
    public class SelectPagoPredio
    {
        private PredioPeticiones PredioPeticiones;

        public SelectPagoPredio(HttpClient cliente)
        {
            PredioPeticiones = new PredioPeticiones(cliente);
        }

        public async Task<Response<InformacionPagoPredio>> Select(int idPredio, string token)
        {
            Response<InformacionPagoPredio> response = await PredioPeticiones.consultarPredioPago(idPredio, token);
            return response;
        }
    }
}
