using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys
{
    public class ArchivoLugarTuristicoQuerys
    {
        private ArchivoLugarTuristicoInsert ArchivoLugarTuristicoInsert;
        private ArchivoLugarTuristicoSelect ArchivoLugarTuristicoSelect;
        private ArchivosLugarTuristicoSelect ArchivosLugarTuristicoSelect;
        private ArchivoLugarTuristicoDelete ArchivoLugarTuristicoDelete;
        private ArchivosLugarTuristicoDelete ArchivosLugarTuristicoDelete;

        public ArchivoLugarTuristicoQuerys(CityAppContext cityAppContext)
        {
            ArchivoLugarTuristicoInsert = new ArchivoLugarTuristicoInsert(cityAppContext);
            ArchivoLugarTuristicoSelect = new ArchivoLugarTuristicoSelect(cityAppContext);
            ArchivosLugarTuristicoSelect = new ArchivosLugarTuristicoSelect(cityAppContext);
            ArchivoLugarTuristicoDelete = new ArchivoLugarTuristicoDelete(cityAppContext);
            ArchivosLugarTuristicoDelete = new ArchivosLugarTuristicoDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertArchivoLugarTuristico(ArchivoLugarTuristico archivoLugarTuristico)
        {
            return ArchivoLugarTuristicoInsert.InsertArchivoLugarTuristico(archivoLugarTuristico);
        }

        //select
        public Response<ArchivoLugarTuristico> SelectArchivoLugarTuristicoIdArchivoLugarTuristico(int idArchivoLugarTuristico)
        {
            return ArchivoLugarTuristicoSelect.SelectArchivoLugarTuristicoIdArchivoLugarTuristico(idArchivoLugarTuristico);
        }
        public Response<IEnumerable<ArchivoLugarTuristico>> SelectArchivosLugarTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            return ArchivosLugarTuristicoSelect.SelectArchivosLugarTuristicoIdLugarTuristico(idLugarTuristico);
        }

        //delete
        public Response<object> DeleteArchivoLugarTuristico(ArchivoLugarTuristico archivoLugarTuristico)
        {
            return ArchivoLugarTuristicoDelete.DeleteArchivoLugarTuristico(archivoLugarTuristico);
        }
        public Response<object> DeleteArchivosLugarTuristico(IEnumerable<ArchivoLugarTuristico> archivoLugarTuristico)
        {
            return ArchivosLugarTuristicoDelete.DeleteArchivosLugarTuristico(archivoLugarTuristico);
        }
    }
}
