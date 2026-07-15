using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys.Select
{
    public class TipoPagoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoPago> SelectCityApp = new SelectCityApp<TipoPago>();

        public TipoPagoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoPago> SelectTipoPago(int idTipoPago)
        {
            Response<TipoPago> response = new Response<TipoPago>();

            try
            {
                response.Data = CityAppContext.TiposPago.Where(d => d.IdTipoPago == idTipoPago).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
