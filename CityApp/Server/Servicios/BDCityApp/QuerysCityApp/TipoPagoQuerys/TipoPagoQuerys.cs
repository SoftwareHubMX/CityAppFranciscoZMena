using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys
{
    public class TipoPagoQuerys
    {
        private TiposPagoSelect TiposPagoSelect;
        private TipoPagoSelect TipoPagoSelect;

        public TipoPagoQuerys(CityAppContext cityAppContext)
        {
            TiposPagoSelect = new TiposPagoSelect(cityAppContext);
            TipoPagoSelect = new TipoPagoSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoPago>> SelectTiposPago()
        {
            return TiposPagoSelect.SelectTiposPago();
        }

        public Response<TipoPago> SelectTipoPago(int idTipoPago)
        {
            return TipoPagoSelect.SelectTipoPago(idTipoPago);
        }
    }
}
