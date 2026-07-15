using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoPagoPeticiones
{
    public class TipoPagoPeticiones
    {
        private ConsultarTiposPago ConsultarTiposPago;

        public TipoPagoPeticiones(HttpClient cliente)
        {
            ConsultarTiposPago = new ConsultarTiposPago(cliente);
        }

        public async Task<Response<List<TipoPago>>> consultarTiposPago()
        {
            Response<List<TipoPago>> response = await ConsultarTiposPago.ConsultarTiposPagoAsync();
            return response;
        }
    }
}
