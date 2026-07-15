using CityApp.Client.Services.ApiRest.PagoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;

namespace CityApp.Client.Logic.CardValidacionPago
{
    public class InsertPago
    {
        private PagoPeticiones PagoPeticiones;

        public InsertPago(HttpClient cliente)
        {
            PagoPeticiones = new PagoPeticiones(cliente);
        }

        public async Task<Response<PagoTarjeta>> Insert(int idCuenta, CrearPago crearPago)
        {
            Response<PagoTarjeta> response = await PagoPeticiones.crearPagoPeticion(idCuenta, crearPago);
            return response;
        }
    }
}
