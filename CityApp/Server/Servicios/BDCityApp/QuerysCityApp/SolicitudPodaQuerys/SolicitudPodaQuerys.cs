using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SolicitanteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys
{
    public class SolicitudPodaQuerys
    {
        private SolicitudPodaDelete SolicitudPodaDelete;
        private SolicitudPodaInsert SolicitudPodaInsert;
        private SolicitudPodaSelect SolicitudPodaSelect;
        private SolicitudesPodaSelect SolicitudesPodaSelect;
        private SolicitudPodaUpdate SolicitudPodaUpdate;

        public SolicitudPodaQuerys(CityAppContext cityAppContext)
        {
            SolicitudPodaDelete = new SolicitudPodaDelete(cityAppContext);
            SolicitudPodaInsert = new SolicitudPodaInsert(cityAppContext);
            SolicitudPodaSelect = new SolicitudPodaSelect(cityAppContext);
            SolicitudesPodaSelect = new SolicitudesPodaSelect(cityAppContext);
            SolicitudPodaUpdate = new SolicitudPodaUpdate(cityAppContext);
        }
        //Delete
        public Response<object> DeleteSolicitudPoda(SolicitudPoda solicitudPoda)
        {
            return SolicitudPodaDelete.DeleteSolicitudPoda(solicitudPoda);
        }

        //Insert
        public Response<object> InsertSolicitudPoda(SolicitudPoda solicitudPoda)
        {
            return SolicitudPodaInsert.InsertSolicitudPoda(solicitudPoda);
        }

        //Select
        public Response<SolicitudPoda> SelectSolicitudPodaIdSolicitudPoda(int idSolicitudPoda)
        {
            return SolicitudPodaSelect.SelectSolicitudPodaIdSolicitudPoda(idSolicitudPoda);
        }
        public Response<SolicitudPoda> SelectLastIdSolicitudPoda()
        {
            return SolicitudPodaSelect.SelectLastIdSolicitudPoda();
        }
        public Response<IEnumerable<SolicitudPoda>> SelectSolicitudPodaFiltroSolicitudPoda(FiltroSolicitud filtroSolicitud)
        {
            return SolicitudesPodaSelect.SelectSolicitudPodaFiltroSolicitudPoda(filtroSolicitud);
        }
        public Response<IEnumerable<SolicitudPoda>> SelectSolicitudesPoda()
        {
            return SolicitudesPodaSelect.SelectSolicitudesPoda();
        }

        //Update
        public Response<object> UpdateSolicitudPoda(SolicitudPoda solicitudPoda)
        {
            return SolicitudPodaUpdate.UpdateSolicitudPoda(solicitudPoda);
        }
    }
}
