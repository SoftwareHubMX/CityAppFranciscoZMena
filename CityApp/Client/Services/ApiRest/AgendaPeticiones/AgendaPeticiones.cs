using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.AgendaPeticiones
{
    public class AgendaPeticiones
    {
        private CrearAgenda CrearAgenda;
        private ConsultarAgendas ConsultarAgendas;
        private ConsultarAgenda ConsultarAgenda;
        private EditarAgenda EditarAgenda;
        private EliminarAgenda EliminarAgenda;
        //private PublicarAgendaFacebook PublicarAgendaFacebook;

        public AgendaPeticiones(HttpClient cliente)
        {
            CrearAgenda = new CrearAgenda(cliente);
            ConsultarAgendas = new ConsultarAgendas(cliente);
            ConsultarAgenda = new ConsultarAgenda(cliente);
            EditarAgenda = new EditarAgenda(cliente);
            EliminarAgenda = new EliminarAgenda(cliente);
            //PublicarAgendaFacebook = new PublicarAgendaFacebook(cliente);
        }

        public async Task<Response<int>> crearAgenda(string toke, Agenda agenda)
        {
            Response<int> response = await CrearAgenda.CrearAgendaAsync(toke, agenda);
            return response;
        }

        public async Task<Response<List<Agenda>>> consultarAgendas(FiltroAgenda filtroAgendas)
        {
            Response<List<Agenda>> response = await ConsultarAgendas.ConsultarAgendasAsync(filtroAgendas);
            return response;
        }

        public async Task<Response<Agenda>> consultarAgenda(int idAgenda)
        {
            Response<Agenda> response = await ConsultarAgenda.ConsultarAgendaAsync(idAgenda);
            return response;
        }

        public async Task<Response<object>> editarAgenda(string toke, Agenda agenda)
        {
            Response<object> response = await EditarAgenda.EditarAgendaAsync(toke, agenda);
            return response;
        }

        public async Task<Response<object>> eliminarAgenda(string toke, int idAgenda)
        {
            Response<object> response = await EliminarAgenda.EliminarAgendaAsync(toke, idAgenda);
            return response;
        }

        //public async Task<Response<string>> publicarAgendaFacebook(string token, string tokenFacebook, int idAgenda)
        //{
        //    Response<string> response = await PublicarAgendaFacebook.PublicarAgendaFacebookAsync(token, tokenFacebook, idAgenda);
        //    return response;
        //}
    }
}
