using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys
{
    public class ArchivoAgendaQuerys
    {
        private ArchivoAgendaInsert ArchivoAgendaInsert;
        private ArchivosAgendaSelect ArchivosAgendaSelect;
        private ArchivoAgendaSelect ArchivoAgendaSelect;
        private ArchivoAgendaDelete ArchivoAgendaDelete;
        private ArchivosAgendaDelete ArchivosAgendaDelete;

        public ArchivoAgendaQuerys(CityAppContext cityAppContext)
        {
            ArchivoAgendaInsert = new ArchivoAgendaInsert(cityAppContext);
            ArchivosAgendaSelect = new ArchivosAgendaSelect(cityAppContext);
            ArchivoAgendaSelect = new ArchivoAgendaSelect(cityAppContext);
            ArchivoAgendaDelete = new ArchivoAgendaDelete(cityAppContext);
            ArchivosAgendaDelete = new ArchivosAgendaDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertArchivoAgenda(ArchivoAgenda archivoAgenda)
        {
            return ArchivoAgendaInsert.InsertArchivoAgenda(archivoAgenda);
        }

        //select
        public Response<IEnumerable<ArchivoAgenda>> SelectArchivosAgendaIdAgenda(int idAgenda)
        {
            return ArchivosAgendaSelect.SelectArchivosAgendaIdAgenda(idAgenda);
        }
        public Response<ArchivoAgenda> SelectArchivoAgendaIdArchivoAgenda(int idArchivoAgenda)
        {
            return ArchivoAgendaSelect.SelectArchivoAgendaIdArchivoAgenda(idArchivoAgenda);
        }
        public Response<ArchivoAgenda> SelectArchivoAgendaIdAgendaPrincipal(int idAgenda)
        {
            return ArchivoAgendaSelect.SelectArchivoAgendaIdAgendaPrincipal(idAgenda);
        }
        public Response<ArchivoAgenda> SelectArchivoAgendaIdAgendaFirst(int idAgenda)
        {
            return ArchivoAgendaSelect.SelectArchivoAgendaIdAgendaFirst(idAgenda);
        }

        //delete
        public Response<object> DeleteArchivoAgenda(ArchivoAgenda archivoAgenda)
        {
            return ArchivoAgendaDelete.DeleteArchivoAgenda(archivoAgenda);
        }
        public Response<object> DeleteArchivosAgenda(IEnumerable<ArchivoAgenda> archivosAgenda)
        {
            return ArchivosAgendaDelete.DeleteArchivosAgenda(archivosAgenda);
        }
    }
}
