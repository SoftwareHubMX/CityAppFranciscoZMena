using CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalCargaExcelPredioLogic
{
    public class InsertHistoricoPredio
    {
        private HistoricoPredioPeticiones HistoricoPredioPeticiones;

        public InsertHistoricoPredio(HttpClient cliente)
        {
            HistoricoPredioPeticiones = new HistoricoPredioPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, HistoricoPredio historicoPredio)
        {
            Response<int> response = await HistoricoPredioPeticiones.crearHistoricoPredio(token, historicoPredio);
            return response;
        }
    }
}
