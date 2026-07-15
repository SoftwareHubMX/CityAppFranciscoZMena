using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Insert
{
    public class AgendaInsert
    {
        private InsertCityApp<Agenda> InsertCityApp;

        public AgendaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Agenda>(cityAppContext);
        }

        public Response<object> InsertAgenda(Agenda agenda)
        {
            return InsertCityApp.Save(agenda);
        }
    }
}
