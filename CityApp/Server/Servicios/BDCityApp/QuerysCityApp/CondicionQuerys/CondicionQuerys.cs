using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CondicionQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CondicionQuerys
{
    public class CondicionQuerys
    {
        private CondicionSelect CondicionSelect;
        private CondicionesSelect CondicionesSelect;

        public CondicionQuerys(CityAppContext cityAppContex)
        {
            CondicionSelect = new CondicionSelect(cityAppContex);
            CondicionesSelect = new CondicionesSelect(cityAppContex);
        }

        public Response<Condicion> SelectCondicion(int idCondicion)
        {
            return CondicionSelect.SelectCondicion(idCondicion);
        }
        public Response<IEnumerable<Condicion>> SelectCondiciones()
        {
            return CondicionesSelect.SelectCondiciones();
        }
    }
}
