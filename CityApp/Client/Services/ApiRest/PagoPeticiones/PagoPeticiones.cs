using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;

namespace CityApp.Client.Services.ApiRest.PagoPeticiones
{
    public class PagoPeticiones
    {
        private CrearPagoPeticion CrearPagoPeticion;
        private ConsultarPagosAdministrador ConsultarPagosAdministrador;
        private ConsultarPago ConsultarPago;
        private ActualizarPago ActualizarPago;
        private EliminarPago EliminarPago;

        public PagoPeticiones(HttpClient cliente)
        {
            CrearPagoPeticion = new CrearPagoPeticion(cliente);
            ConsultarPagosAdministrador = new ConsultarPagosAdministrador(cliente);
            ConsultarPago = new ConsultarPago(cliente);
            ActualizarPago = new ActualizarPago(cliente);
            EliminarPago = new EliminarPago(cliente);
        }

        public async Task<Response<PagoTarjeta>> crearPagoPeticion(int idCuenta, CrearPago crearPago)
        {
            Response<PagoTarjeta> response = await CrearPagoPeticion.CrearPagoAsync(idCuenta, crearPago);
            return response;
        }

        public async Task<Response<List<Pago>>> consultarPagosAdministrador(string token, FiltroPagos filtroPagos)
        {
            Response<List<Pago>> response = await ConsultarPagosAdministrador.ConsultarPagosAdministradorAsync(token, filtroPagos);
            return response;
        }

        public async Task<Response<Pago>> consultarPago(string token, int idPago)
        {
            Response<Pago> response = await ConsultarPago.ConsultarPagoAsync(idPago, token);
            return response;
        }

        public async Task<Response<object>> actualizarPago(string token, Pago pago)
        {
            Response<object> response = await ActualizarPago.ActualizarPagoAsync(token, pago);
            return response;
        }

        public async Task<Response<object>> eliminarPago(string token, int idPago)
        {
            Response<object> response = await EliminarPago.EliminarPagoAsync(idPago, token);
            return response;
        }
    }
}
