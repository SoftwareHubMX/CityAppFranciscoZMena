

using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoDirectorioQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoDirectorioQuerys
{
    public class TipoDirectorioQuerys
    {
        private TipoDirectorioSelect TipoDirectorioSelect;
        private TiposDirectorioSelect TiposDirectorioSelect;

        public TipoDirectorioQuerys(CityAppContext cityAppContex)
        {
            TipoDirectorioSelect = new TipoDirectorioSelect(cityAppContex);
            TiposDirectorioSelect = new TiposDirectorioSelect(cityAppContex);
        }

        public Response<TipoDirectorio> SelectTipoDirectorio(int idTipoDirectorio)
        {
            return TipoDirectorioSelect.SelectTipoDirectorio(idTipoDirectorio);
        }
        public Response<IEnumerable<TipoDirectorio>> SelectTiposDirectorio()
        {
            return TiposDirectorioSelect.SelectTiposDirectorio();
        }
    }
}
