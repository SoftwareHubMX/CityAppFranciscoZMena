using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AgendaLogic
{
    public class ConsultarAgendaLogic
    {
        private AgendaQuerys AgendaQuerys;
        private ArchivoAgendaQuerys ArchivoAgendaQuerys;

        private int IdAgenda;
        private Agenda Agenda;

        public ConsultarAgendaLogic(CityAppContext cityAppContetx, int idAgenda)
        {
            AgendaQuerys = new AgendaQuerys(cityAppContetx);
            ArchivoAgendaQuerys = new ArchivoAgendaQuerys(cityAppContetx);

            IdAgenda = idAgenda;
        }

        public Response<Agenda> Consultar()
        {
            Response<Agenda> response = new Response<Agenda>();

            response = AgendaQuerys.SelectAgendaIdAgenda(IdAgenda);
            if (response.Status.Exito == 1)
            {
                Agenda = response.Data;
                Response<object> responseCargarListas = CargarArchivos();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = Agenda;
                }
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoAgenda>> responseArchivoAgenda = ArchivoAgendaQuerys.SelectArchivosAgendaIdAgenda(IdAgenda);
            response.Status = responseArchivoAgenda.Status;
            if (response.Status.Exito == 1)
            {
                Agenda.ArchivosAgenda = responseArchivoAgenda.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
