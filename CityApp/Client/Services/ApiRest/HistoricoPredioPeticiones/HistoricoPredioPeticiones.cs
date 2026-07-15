using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones
{
    public class HistoricoPredioPeticiones
    {
        private CrearHistoricoPredio CrearHistoricoPredio;
        private ConsultarHistoricosPredios ConsultarHistoricosPredios;
        private EliminarHistoricoPredio EliminarHistoricoPredio;

        public HistoricoPredioPeticiones(HttpClient cliente)
        {
            CrearHistoricoPredio = new CrearHistoricoPredio(cliente);
            ConsultarHistoricosPredios = new ConsultarHistoricosPredios(cliente);
            EliminarHistoricoPredio = new EliminarHistoricoPredio(cliente);
        }

        public async Task<Response<int>> crearHistoricoPredio(string toke, HistoricoPredio HistoricoPredio)
        {
            Response<int> response = await CrearHistoricoPredio.CrearHistoricoPredioAsync(toke, HistoricoPredio);
            return response;
        }

        public async Task<Response<List<HistoricoPredio>>> consultarHistoricosPredios(string token, FiltroHistoricoPredio filtroHistoricoPredios)
        {
            Response<List<HistoricoPredio>> response = await ConsultarHistoricosPredios.ConsultarHistoricosPrediosAsync(token, filtroHistoricoPredios);
            return response;
        }

        public async Task<Response<object>> eliminarHistoricoPredio(string toke, int idHistoricoPredio)
        {
            Response<object> response = await EliminarHistoricoPredio.EliminarHistoricoPredioAsync(toke, idHistoricoPredio);
            return response;
        }
    }
}
