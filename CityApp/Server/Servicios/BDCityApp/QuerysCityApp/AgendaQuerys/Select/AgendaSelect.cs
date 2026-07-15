using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Select
{
    public class AgendaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Agenda> SelectCityApp = new SelectCityApp<Agenda>();

        public AgendaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Agenda> SelectAgendaIdAgenda(int idAgenda)
        {
            Response<Agenda> response = new Response<Agenda>();

            try
            {
                response.Data = CityAppContext.Agendas.Where(d => d.IdAgenda == idAgenda).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
