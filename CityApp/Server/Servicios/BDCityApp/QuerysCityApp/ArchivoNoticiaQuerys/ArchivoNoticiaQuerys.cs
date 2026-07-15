using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys
{
    public class ArchivoNoticiaQuerys
    {
        private ArchivoNoticiaInsert ArchivoNoticiaInsert;
        private ArchivosNoticiaSelect ArchivosNoticiaSelect;
        private ArchivoNoticiaSelect ArchivoNoticiaSelect;
        private ArchivoNoticiaDelete ArchivoNoticiaDelete;
        private ArchivosNoticiaDelete ArchivosNoticiaDelete;

        public ArchivoNoticiaQuerys(CityAppContext cityAppContext)
        {
            ArchivoNoticiaInsert = new ArchivoNoticiaInsert(cityAppContext);
            ArchivosNoticiaSelect = new ArchivosNoticiaSelect(cityAppContext);
            ArchivoNoticiaSelect = new ArchivoNoticiaSelect(cityAppContext);
            ArchivoNoticiaDelete = new ArchivoNoticiaDelete(cityAppContext);
            ArchivosNoticiaDelete = new ArchivosNoticiaDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertArchivoNoticia(ArchivoNoticia archivoNoticia)
        {
            return ArchivoNoticiaInsert.InsertArchivoNoticia(archivoNoticia);
        }

        //select
        public Response<IEnumerable<ArchivoNoticia>> SelectArchivosNoticiaIdNoticia(int idNoticia)
        {
            return ArchivosNoticiaSelect.SelectArchivosNoticiaIdNoticia(idNoticia);
        }
        public Response<ArchivoNoticia> SelectArchivoNoticiaIdArchivoNoticia(int idArchivoNoticia)
        {
            return ArchivoNoticiaSelect.SelectArchivoNoticiaIdArchivoNoticia(idArchivoNoticia);
        }
        public Response<ArchivoNoticia> SelectArchivoNoticiaIdNoticiaPrincipal(int idNoticia)
        {
            return ArchivoNoticiaSelect.SelectArchivoNoticiaIdNoticiaPrincipal(idNoticia);
        }
        public Response<ArchivoNoticia> SelectArchivoNoticiaIdNoticiaFirst(int idNoticia)
        {
            return ArchivoNoticiaSelect.SelectArchivoNoticiaIdNoticiaFirst(idNoticia);
        }

        //delete
        public Response<object> DeleteArchivoNoticia(ArchivoNoticia archivoNoticia)
        {
            return ArchivoNoticiaDelete.DeleteArchivoNoticia(archivoNoticia);
        }
        public Response<object> DeleteArchivosNoticia(IEnumerable<ArchivoNoticia> archivosNoticia)
        {
            return ArchivosNoticiaDelete.DeleteArchivosNoticia(archivosNoticia);
        }
    }
}
