using CityApp.Client.Services.ApiRest.PagoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaPagosLogic
{
    public class SelectPagos
    {
        private PagoPeticiones PagoPeticiones;

        public SelectPagos(HttpClient cliente)
        {
            PagoPeticiones = new PagoPeticiones(cliente);
        }

        public async Task<Response<List<Pago>>> SelectAll(string token, FiltroPagos filtroPagos)
        {
            Response<List<Pago>> response = await PagoPeticiones.consultarPagosAdministrador(token, filtroPagos);
            return response;
        }
    }
}
