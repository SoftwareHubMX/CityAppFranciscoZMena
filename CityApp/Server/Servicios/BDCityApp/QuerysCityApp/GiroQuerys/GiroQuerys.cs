using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.GiroQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.GiroQuerys
{
    public class GiroQuerys
    {
        private GiroSelect GiroSelect;
        private GirosSelect GirosSelect;

        public GiroQuerys(CityAppContext cityAppContex)
        {
            GiroSelect = new GiroSelect(cityAppContex);
            GirosSelect = new GirosSelect(cityAppContex);
        }

        public Response<Giro> SelectGiro(int idGiro)
        {
            return GiroSelect.SelectGiro(idGiro);
        }
        public Response<IEnumerable<Giro>> SelectGiros()
        {
            return GirosSelect.SelectGiros();
        }
    }
}
