using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AgendaLogic
{
    public class CrearAgendaLogic
    {
        private AgendaQuerys AgendaQuerys;

        private Agenda Agenda;

        public CrearAgendaLogic(CityAppContext cityAppContext, Agenda agenda)
        {
            AgendaQuerys = new AgendaQuerys(cityAppContext);

            Agenda = agenda;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseAgenda = AgendaQuerys.InsertAgenda(Agenda);
            response.Status = responseAgenda.Status;
            if (response.Status.Exito == 1)
            {
                response = AgendaQuerys.SelectUltimoIdAgendaTexto(Agenda.Texto);
            }

            return response;
        }
    }
}
