using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.ControllersModels.PredioSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.PredioPeticiones
{
    public class PredioPeticiones
    {
        private ConsultarPredioPago ConsultarPredioPago;
        private CrearPredioPeticiones CrearPredioPeticiones;
        private ConsultarPredios ConsultarPredios;
        private ActualizarPrediosExcel ActualizarPrediosExcel;

        public PredioPeticiones(HttpClient cliente)
        {
            ConsultarPredioPago = new ConsultarPredioPago(cliente);
            CrearPredioPeticiones = new CrearPredioPeticiones(cliente);
            ConsultarPredios = new ConsultarPredios(cliente);
            ActualizarPrediosExcel = new ActualizarPrediosExcel(cliente);
        }

        public async Task<Response<InformacionPagoPredio>> consultarPredioPago(int idPredio, string token)
        {
            Response<InformacionPagoPredio> response = await ConsultarPredioPago.ConsultarPredioPagoAsync(idPredio, token);
            return response;
        }

        public async Task<Response<int>> crearPredioPeticiones(string token, CrearPredio crearPredio)
        {
            Response<int> response = await CrearPredioPeticiones.CrearPredioAsync(token, crearPredio);
            return response;
        }

        public async Task<Response<List<Predio>>> consultarPredios(string token, FiltroPredios filtroPredios)
        {
            Response<List<Predio>> response = await ConsultarPredios.ConsultarPrediosAsync(token, filtroPredios);
            return response;
        }

        public async Task<Response<object>> actualizarPrediosExcel(string token, string excel)
        {
            Response<object> response = await ActualizarPrediosExcel.ActualizarPrediosExcelAsync(token, excel);
            return response;
        }
    }
}
