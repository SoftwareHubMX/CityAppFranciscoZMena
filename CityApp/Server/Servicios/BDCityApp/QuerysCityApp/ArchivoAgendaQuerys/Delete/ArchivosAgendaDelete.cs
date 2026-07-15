using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Delete
{
    public class ArchivosAgendaDelete
    {
        private DeleteCityApp<ArchivoAgenda> DeleteCityApp;

        public ArchivosAgendaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoAgenda>(cityAppContext);
        }

        public Response<object> DeleteArchivosAgenda(IEnumerable<ArchivoAgenda> archivosAgenda)
        {
            return DeleteCityApp.SaveMultiple(archivosAgenda);
        }
    }
}
