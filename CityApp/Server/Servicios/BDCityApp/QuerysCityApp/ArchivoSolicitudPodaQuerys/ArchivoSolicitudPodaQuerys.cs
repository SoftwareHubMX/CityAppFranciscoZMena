using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys
{
    public class ArchivoSolicitudPodaQuerys
    {
        private ArchivoSolicitudPodaInsert ArchivoSolicitudPodaInsert;
        //private ArchivoAnuncioDelete ArchivoAnuncioDelete;
        //private ArchivosAnuncioDetete ArchivosAnuncioDetete;
        private ArchivoSolicitudPodaSelect ArchivoSolicitudPodaSelect;
        private ArchivosSolicitudPodaSelect ArchivosSolicitudPodaSelect;

        public ArchivoSolicitudPodaQuerys(CityAppContext cityAppContext)
        {
            ArchivoSolicitudPodaInsert = new ArchivoSolicitudPodaInsert(cityAppContext);
            //ArchivoAnuncioDelete = new ArchivoAnuncioDelete(cityAppContext);
            //ArchivoAnuncioSelect = new ArchivoAnuncioSelect(cityAppContext);
            ArchivoSolicitudPodaSelect = new ArchivoSolicitudPodaSelect(cityAppContext);
            ArchivosSolicitudPodaSelect = new ArchivosSolicitudPodaSelect(cityAppContext);
        }

        //Insert
        public Response<object> InsertArchivoSolicitudPoda(ArchivoSolicitidPoda archivoSolicitidPoda)
        {
            return ArchivoSolicitudPodaInsert.InsertArchivoSolicitudPoda(archivoSolicitidPoda);
        }

        //Delete
        //public Response<object> DeleteArchivoAnuncio(ArchivoAnuncio archivoAnuncio)
        //{
        //    return ArchivoAnuncioDelete.DeleteArchivoAnuncio(archivoAnuncio);
        //}
        //public Response<object> DeleteArchivosAnuncio(IEnumerable<ArchivoAnuncio> archivoAnuncio)
        //{
        //    return ArchivosAnuncioDetete.DeleteArchivosAnuncio(archivoAnuncio);
        //}

        //Select
        public Response<ArchivoSolicitidPoda> SelectArchivoSolicitudPoda(int idArchivoSolicitudPoda)
        {
            return ArchivoSolicitudPodaSelect.SelectArchivoSolicitudPoda(idArchivoSolicitudPoda);
        }
        public Response<IEnumerable<ArchivoSolicitidPoda>> SelectArchivoSolicitudPodaIdSolicitudPoda(int idSolicitudPoda)
        {
            return ArchivosSolicitudPodaSelect.SelectArchivoSolicitudPodaIdSolicitudPoda(idSolicitudPoda);
        }
    }
}
