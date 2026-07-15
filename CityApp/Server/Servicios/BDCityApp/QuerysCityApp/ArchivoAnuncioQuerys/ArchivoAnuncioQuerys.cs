using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys
{
    public class ArchivoAnuncioQuerys
    {
        private ArchivoAnuncioInsert ArchivoAnuncioInsert;
        private ArchivoAnuncioDelete ArchivoAnuncioDelete;
        private ArchivosAnuncioDetete ArchivosAnuncioDetete;
        private ArchivoAnuncioSelect ArchivoAnuncioSelect;
        private ArchivosAnuncioSelect ArchivosAnuncioSelect;

        public ArchivoAnuncioQuerys(CityAppContext cityAppContext)
        {
            ArchivoAnuncioInsert = new ArchivoAnuncioInsert(cityAppContext);
            ArchivoAnuncioDelete = new ArchivoAnuncioDelete(cityAppContext);
            ArchivoAnuncioSelect = new ArchivoAnuncioSelect(cityAppContext);
            ArchivosAnuncioSelect = new ArchivosAnuncioSelect(cityAppContext);
            ArchivosAnuncioDetete = new ArchivosAnuncioDetete(cityAppContext);
        }

        //Insert
        public Response<object> InsertArchivoAnuncio(ArchivoAnuncio archivoAnuncio)
        {
            return ArchivoAnuncioInsert.InsertArchivoAnuncio(archivoAnuncio);
        }

        //Delete
        public Response<object> DeleteArchivoAnuncio(ArchivoAnuncio archivoAnuncio)
        {
            return ArchivoAnuncioDelete.DeleteArchivoAnuncio(archivoAnuncio);
        }
        public Response<object> DeleteArchivosAnuncio(IEnumerable<ArchivoAnuncio> archivoAnuncio)
        {
            return ArchivosAnuncioDetete.DeleteArchivosAnuncio(archivoAnuncio);
        }

        //Select
        public Response<ArchivoAnuncio> SelectArchivoAnuncio(int idArchivoAnuncio)
        {
            return ArchivoAnuncioSelect.SelectArchivoAnuncio(idArchivoAnuncio);
        }
        public Response<IEnumerable<ArchivoAnuncio>> SelectArchivoAnuncioIdAnuncio( int idAnuncio)
        {
            return ArchivosAnuncioSelect.SelectArchivoAnuncioIdAnuncio(idAnuncio);
        }
    }
}
