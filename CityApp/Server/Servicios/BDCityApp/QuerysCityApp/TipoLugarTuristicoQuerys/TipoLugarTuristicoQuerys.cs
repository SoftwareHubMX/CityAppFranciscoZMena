using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoLugarTuristicoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoLugarTuristicoQuerys
{
    public class TipoLugarTuristicoQuerys
    {
        private TiposLugarTuristicoSelect TiposLugarTuristicoSelect;

        public TipoLugarTuristicoQuerys(CityAppContext cityAppContext)
        {
            TiposLugarTuristicoSelect = new TiposLugarTuristicoSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoLugarTuristico>> SelectTiposLugarTuristico()
        {
            return TiposLugarTuristicoSelect.SelectTiposLugarTuristico();
        }
    }
}
