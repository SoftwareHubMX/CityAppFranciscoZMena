using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Delete
{
    public class AgendaDelete
    {
        private DeleteCityApp<Agenda> DeleteCityApp;

        public AgendaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Agenda>(cityAppContext);
        }

        public Response<object> DeleteAgenda(Agenda agenda)
        {
            return DeleteCityApp.Save(agenda);
        }
    }
}
