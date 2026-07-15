using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoCitaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoCitaQuerys
{
    public class TipoCitaQuerys
    {
        private TiposCitaSelect TiposCitaSelect;

        public TipoCitaQuerys(CityAppContext cityAppContext)
        {
            TiposCitaSelect = new TiposCitaSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoCita>> SelectTiposCita()
        {
            return TiposCitaSelect.SelectTiposCita();
        }
    }
}
