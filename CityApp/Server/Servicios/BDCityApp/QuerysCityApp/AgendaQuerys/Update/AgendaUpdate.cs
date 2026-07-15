using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Update
{
    public class AgendaUpdate
    {
        private UpdateCityApp<Agenda> UpdateCityApp;

        public AgendaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Agenda>(cityAppContext);
        }

        public Response<object> UpdateAgenda(Agenda agenda)
        {
            return UpdateCityApp.Save(agenda);
        }
    }
}
