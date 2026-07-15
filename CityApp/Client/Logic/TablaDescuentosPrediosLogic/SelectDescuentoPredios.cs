using CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaDescuentosPrediosLogic
{
    public class SelectDescuentoPredios
    {
        private DescuentoPredioPeticiones DescuentoPredioPeticiones;

        public SelectDescuentoPredios(HttpClient cliente)
        {
            DescuentoPredioPeticiones = new DescuentoPredioPeticiones(cliente);
        }

        public async Task<Response<List<DescuentoPredio>>> SelectAll(string token, FiltroDescuentoPredios filtroDescuentoPredios)
        {
            Response<List<DescuentoPredio>> response = await DescuentoPredioPeticiones.consultarDescuentosPredios(token, filtroDescuentoPredios);
            return response;
        }
    }
}
