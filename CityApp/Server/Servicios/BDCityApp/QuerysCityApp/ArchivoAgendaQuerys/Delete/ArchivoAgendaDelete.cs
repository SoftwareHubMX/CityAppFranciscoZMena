using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Delete
{
    public class ArchivoAgendaDelete
    {
        private DeleteCityApp<ArchivoAgenda> DeleteCityApp;

        public ArchivoAgendaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoAgenda>(cityAppContext);
        }

        public Response<object> DeleteArchivoAgenda(ArchivoAgenda archivoAgenda)
        {
            return DeleteCityApp.Save(archivoAgenda);
        }
    }
}
