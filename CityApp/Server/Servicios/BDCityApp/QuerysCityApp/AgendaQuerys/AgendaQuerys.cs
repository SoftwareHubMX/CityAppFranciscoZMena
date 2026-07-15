using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Update;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys
{
    public class AgendaQuerys
    {
        private AgendaInsert AgendaInsert;
        private AgendaSelect AgendaSelect;
        private AgendasSelect AgendasSelect;
        private IdAgendaSelect IdAgendaSelect;
        private AgendaUpdate AgendaUpdate;
        private AgendaDelete AgendaDelete;

        public AgendaQuerys(CityAppContext cityAppContext)
        {
            AgendaInsert = new AgendaInsert(cityAppContext);
            AgendaSelect = new AgendaSelect(cityAppContext);
            AgendasSelect = new AgendasSelect(cityAppContext);
            IdAgendaSelect = new IdAgendaSelect(cityAppContext);
            AgendaUpdate = new AgendaUpdate(cityAppContext);
            AgendaDelete = new AgendaDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertAgenda(Agenda Agenda)
        {
            return AgendaInsert.InsertAgenda(Agenda);
        }

        //select
        public Response<Agenda> SelectAgendaIdAgenda(int idAgenda)
        {
            return AgendaSelect.SelectAgendaIdAgenda(idAgenda);
        }
        public Response<IEnumerable<Agenda>> SelectAgendasFiltroAgendas(FiltroAgenda filtroAgendas)
        {
            return AgendasSelect.SelectAgendasFiltroAgendas(filtroAgendas);
        }
        public Response<int> SelectUltimoIdAgendaTexto(string texto)
        {
            return IdAgendaSelect.SelectUltimoIdAgendaTexto(texto);
        }

        public Response<int> SelectAgendasFechasDashBoard(FechasDashBoard fechasDashBoard)
        {
            return AgendasSelect.SelectAgendasFechasDashBoard(fechasDashBoard);
        }

        //update
        public Response<object> UpdateAgenda(Agenda Agenda)
        {
            return AgendaUpdate.UpdateAgenda(Agenda);
        }

        //delete
        public Response<object> DeleteAgenda(Agenda Agenda)
        {
            return AgendaDelete.DeleteAgenda(Agenda);
        }
    }
}
