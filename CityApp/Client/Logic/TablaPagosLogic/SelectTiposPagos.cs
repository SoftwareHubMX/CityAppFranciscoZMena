using CityApp.Client.Services.ApiRest.TipoPagoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaPagosLogic
{
    public class SelectTiposPagos
    {
        private TipoPagoPeticiones TipoPagoPeticiones;

        public SelectTiposPagos(HttpClient cliente)
        {
            TipoPagoPeticiones = new TipoPagoPeticiones(cliente);
        }

        public async Task<Response<List<TipoPago>>> SelectAll()
        {
            Response<List<TipoPago>> response = await TipoPagoPeticiones.consultarTiposPago();
            return response;
        }
    }
}
