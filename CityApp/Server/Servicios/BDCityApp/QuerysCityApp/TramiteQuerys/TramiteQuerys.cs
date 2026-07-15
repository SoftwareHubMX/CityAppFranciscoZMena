using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys
{
    public class TramiteQuerys
    {
        private TramiteInsert TramiteInsert;
        private TramiteUpdate TramiteUpdate;
        private TramiteDelete TramiteDelete;
        private TramiteSelect TramiteSelect;
        private TramitesSelect TramitesSelect;
        private IdTramiteSelect IdTramiteSelect;

        public TramiteQuerys(CityAppContext cityAppContext)
        {
            TramiteInsert = new TramiteInsert(cityAppContext);
            TramiteUpdate = new TramiteUpdate(cityAppContext);
            TramiteDelete = new TramiteDelete(cityAppContext);
            TramiteSelect = new TramiteSelect(cityAppContext);
            TramitesSelect = new TramitesSelect(cityAppContext);
            IdTramiteSelect = new IdTramiteSelect(cityAppContext);
        }

        //Insert
        public Response<object> InsertTramite(Tramite tramite)
        {
            return TramiteInsert.InsertTramite(tramite);
        }

        //Update
        public Response<object> UpdateTramite(Tramite tramite)
        {
            return TramiteUpdate.UpdateTramite(tramite);
        }

        //Delete
        public Response<object> DeleteTramite(Tramite tramite)
        {
            return TramiteDelete.DeleteTramite(tramite);
        }

        //Select
        public Response<Tramite> SelectTramiteIdTramite(int idTramite)
        {
            return TramiteSelect.SelectTramiteIdTramite(idTramite);
        }
        public Response<Tramite> SelectTramiteIdTipoTramite(int idTipoTramite)
        {
            return TramiteSelect.SelectTramiteIdTipoTramite(idTipoTramite);
        }
        public Response<IEnumerable<Tramite>> SelectTramites(int idDependencia)
        {
            return TramitesSelect.SelectTramites(idDependencia);
        }
        public Response<IEnumerable<Tramite>> SelectTramiteFirltoTramite(FiltroTramite filtroTramite)
        {
            return TramitesSelect.SelectTramiteFirltoTramite(filtroTramite);
        }
        public Response<int> SelectTramiteConceptoDescripcion(string concepto, string descripcion)
        {
            return IdTramiteSelect.SelectTramiteConceptoDescripcion(concepto, descripcion);
        }

        public Response<IEnumerable<Tramite>> SelectTramiteTiposTramites(int idTipoTramite, FechasDashBoard fechasDashBoard)
        {
            return TramitesSelect.SelectTramiteTiposTramites(idTipoTramite, fechasDashBoard);
        }

    }
}
    