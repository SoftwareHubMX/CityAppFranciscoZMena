using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys.Select
{
    public class TiposPagoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoPago> SelectCityApp = new SelectCityApp<TipoPago>();

        public TiposPagoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoPago>> SelectTiposPago()
        {
            Response<IEnumerable<TipoPago>> response = new Response<IEnumerable<TipoPago>>();

            try
            {
                response.Data = CityAppContext.TiposPago;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
