using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAlertaRutaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAlertaRutaQuerys
{
    public class TipoAlertaRutaQuerys
    {
        private TiposAlertaRutaSelect TiposAlertaRutaSelect;
        private TipoAlertaRutaSelect TipoAlertaRutaSelect;

        public TipoAlertaRutaQuerys(CityAppContext cityAppContext)
        {
            TiposAlertaRutaSelect = new TiposAlertaRutaSelect(cityAppContext);
            TipoAlertaRutaSelect = new TipoAlertaRutaSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoAlertaRuta>> SelectTiposAlertaRuta()
        {
            return TiposAlertaRutaSelect.SelectTiposAlertaRuta();
        }

        public Response<TipoAlertaRuta> SelectTipoAlertaRuta(int idTipoAlertaRuta)
        {
            return TipoAlertaRutaSelect.SelectTipoAlertaRuta(idTipoAlertaRuta);
        }
    }
}
