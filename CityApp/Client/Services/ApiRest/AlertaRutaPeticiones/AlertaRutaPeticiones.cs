using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.AlertaRutaPeticiones
{
    public class AlertaRutaPeticiones
    {
        private CrearAlertaRuta CrearAlertaRuta;
        private ActualizarAlertaRuta ActualizarAlertaRuta;
        private ConsultarFiltroAlertaRuta ConsultarFiltroAlertaRuta;
        private ActualizarStatusAlertaRutaAdmin ActualizarStatusAlertaRutaAdmin;

        public AlertaRutaPeticiones(HttpClient cliente)
        {
            CrearAlertaRuta = new CrearAlertaRuta(cliente);
            ActualizarAlertaRuta = new ActualizarAlertaRuta(cliente);
            ConsultarFiltroAlertaRuta = new ConsultarFiltroAlertaRuta(cliente);
            ActualizarStatusAlertaRutaAdmin = new ActualizarStatusAlertaRutaAdmin(cliente);
        }

        public async Task<Response<object>> crearAlertaRuta(string token, AlertaRuta alertaRuta)
        {
            Response<object> response = await CrearAlertaRuta.CrearAlertaRutaAsync(token, alertaRuta);
            return response;
        }
        public async Task<Response<object>> actualizarAlertaRuta(string token, AlertaRuta alertaRuta)
        {
            Response<object> response = await ActualizarAlertaRuta.ActualizarAlertaRutaAsync(token, alertaRuta);
            return response;
        }
        public async Task<Response<List<AlertaRuta>>> consultarFiltroAlertaRuta(string token, FiltroAlertaRuta filtroAlertaRuta)
        {
            Response<List<AlertaRuta>> response = await ConsultarFiltroAlertaRuta.ConsultarFiltroAlertaRutaAsync(token, filtroAlertaRuta);
            return response;
        }
        public async Task<Response<object>> actualizarStatusAlertaRuta(string token, int idAlertaRuta, int idStatusAlertaRuta)
        {
            Response<object> response = await ActualizarStatusAlertaRutaAdmin.ActualizarStatusAlertaRutaAsync(token, idAlertaRuta, idStatusAlertaRuta);
            return response;
        }
    }
}
