using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AgendaLogic
{
    public class EditarAgendaLogic
    {
        private AgendaQuerys AgendaQuerys;

        private Agenda Agenda;

        public EditarAgendaLogic(CityAppContext cityAppContext, Agenda agenda)
        {
            AgendaQuerys = new AgendaQuerys(cityAppContext);

            Agenda = agenda;
        }

        public Response<object> Editar()
        {
            Response<object> response = new Response<object>();

            response = AgendaQuerys.UpdateAgenda(Agenda);

            return response;
        }
    }
}
