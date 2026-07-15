using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys
{
    public class ArchivoDirectorioQuerys
    {
        
            private ArchivoDirectorioInsert ArchivoDirectorioInsert;
            private ArchivoDirectorioDelete ArchivoDirectorioDelete;
            private ArchivosDirectorioDelete ArchivosDirectorioDelete;
            private ArchivoDirectorioSelect ArchivoDirectorioSelect;
            private ArchivosDirectorioSelect ArchivosDirectorioSelect;

            public ArchivoDirectorioQuerys(CityAppContext cityAppContext)
            {
                ArchivoDirectorioInsert = new ArchivoDirectorioInsert(cityAppContext);
                ArchivoDirectorioDelete = new ArchivoDirectorioDelete(cityAppContext);
                ArchivoDirectorioSelect = new ArchivoDirectorioSelect(cityAppContext);
                ArchivosDirectorioSelect = new ArchivosDirectorioSelect(cityAppContext);
                ArchivosDirectorioDelete = new ArchivosDirectorioDelete(cityAppContext);
            }

        //Insert
        public Response<object> InsertArchivoDirectorio(ArchivoDirectorio archivoDirectorio)
        {
            return ArchivoDirectorioInsert.InsertArchivoDirectorio(archivoDirectorio);
        }

        //Delete
        public Response<object> DeletetArchivoDirectorio(ArchivoDirectorio archivoDirectorio)
        {
            return ArchivoDirectorioDelete.DeleteArchivoDirectorio(archivoDirectorio);
        }
        public Response<object> DeleteArchivosDirectorio(IEnumerable<ArchivoDirectorio> archivoDirectorio)
        {
            return ArchivosDirectorioDelete.DeleteArchivosDirectorio(archivoDirectorio);
        }

        //Select
        public Response<ArchivoDirectorio> SelecttArchivoDirectorio(int idArchivoDirectorio)
            {
                return ArchivoDirectorioSelect.SelectArchivoDirectorio(idArchivoDirectorio);
            }
            public Response<IEnumerable<ArchivoDirectorio>> SelectArchivosDirectorioIdDirectorio(int idDirectorio)
            {
                return ArchivosDirectorioSelect.SelectArchivosDirectorioIdDirectorio(idDirectorio);
            }
    }
}
