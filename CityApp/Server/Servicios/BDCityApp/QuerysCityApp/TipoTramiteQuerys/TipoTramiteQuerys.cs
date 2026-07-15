using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys
{
    public class TipoTramiteQuerys
    {
        private TipoTramiteSelect TipoTramiteSelect;
        private TiposTramitesSelect TiposTramitesSelect;

        public TipoTramiteQuerys (CityAppContext cityAppContex)
        {
            TipoTramiteSelect = new TipoTramiteSelect(cityAppContex);
            TiposTramitesSelect = new TiposTramitesSelect(cityAppContex);   
        }

        public Response<TipoTramite> SelectTipoTramite(int idTipoTramite)
        {
            return TipoTramiteSelect.SelectTipoTramite (idTipoTramite);
        }
        public Response<IEnumerable<TipoTramite>> SelectTiposTramites()
        {
            return TiposTramitesSelect.SelectTiposTramites();
        }
    }
}
