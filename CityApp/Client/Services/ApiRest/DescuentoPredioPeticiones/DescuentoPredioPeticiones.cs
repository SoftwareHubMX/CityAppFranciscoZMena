using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones
{
    public class DescuentoPredioPeticiones
    {
        private CrearDescuentoPredio CrearDescuentoPredio;
        private ConsultarDescuentosPredios ConsultarDescuentosPredios;
        private ConsultarDescuentosPrediosHoy ConsultarDescuentosPrediosHoy;
        private EliminarDescuentoPredio EliminarDescuentoPredio;

        public DescuentoPredioPeticiones(HttpClient cliente)
        {
            CrearDescuentoPredio = new CrearDescuentoPredio(cliente);
            ConsultarDescuentosPredios = new ConsultarDescuentosPredios(cliente);
            ConsultarDescuentosPrediosHoy = new ConsultarDescuentosPrediosHoy(cliente);
            EliminarDescuentoPredio = new EliminarDescuentoPredio(cliente);
        }

        public async Task<Response<object>> crearDescuentoPredio(string token, DescuentoPredio descuentoPredio)
        {
            Response<object> response = await CrearDescuentoPredio.CrearDescuentoPredioAsync(token, descuentoPredio);
            return response;
        }

        public async Task<Response<List<DescuentoPredio>>> consultarDescuentosPredios(string token, FiltroDescuentoPredios filtroDescuentoPredios)
        {
            Response<List<DescuentoPredio>> response = await ConsultarDescuentosPredios.ConsultarDescuentosPrediosAsync(token, filtroDescuentoPredios);
            return response;
        }

        public async Task<Response<List<DescuentoPredio>>> consultarDescuentosPrediosHoy()
        {
            Response<List<DescuentoPredio>> response = await ConsultarDescuentosPrediosHoy.ConsultarDescuentosPrediosHoyAsync();
            return response;
        }

        public async Task<Response<object>> eliminarDescuentoPredio(string token, int idDescuentoPredio)
        {
            Response<object> response = await EliminarDescuentoPredio.EliminarDescuentoPredioAsync(token, idDescuentoPredio);
            return response;
        }
    }
}
