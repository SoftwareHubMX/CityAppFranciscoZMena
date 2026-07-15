using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoPagoLogic
{
    public class ConsultarTiposPagoLogic
    {
        private TipoPagoQuerys TipoPagoQuerys;

        public ConsultarTiposPagoLogic(CityAppContext cityAppContext)
        {
            TipoPagoQuerys = new TipoPagoQuerys(cityAppContext);
        }

        public Response<List<TipoPago>> Consultar()
        {
            Response<List<TipoPago>> response = new Response<List<TipoPago>>();

            Response<IEnumerable<TipoPago>> responseTipoPago = TipoPagoQuerys.SelectTiposPago();
            response.Status = responseTipoPago.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoPago.Data.ToList();
            }

            return response;
        }
    }
}
