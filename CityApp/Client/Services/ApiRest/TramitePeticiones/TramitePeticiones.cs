using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TramitePeticiones
{
    public class TramitePeticiones
    {
        private CrearTramite CrearTramite;
        private EliminarTramite EliminarTramite;
        private ActualizarTramite ActualizarTramite;
        private ConsultarTramite ConsultarTramite;  
        private ConsultarTramitesFiltro ConsultarTramitesFiltro;    

        public TramitePeticiones(HttpClient Cliente)
        {
            CrearTramite = new CrearTramite(Cliente);
            EliminarTramite = new EliminarTramite(Cliente);
            ActualizarTramite = new ActualizarTramite(Cliente); 
            ConsultarTramite = new ConsultarTramite(Cliente);
            ConsultarTramitesFiltro = new ConsultarTramitesFiltro(Cliente);
        }

        public async Task<Response<object>> crearTramite(string token, Tramite tramite)
        {
            Response<object> response = await CrearTramite.CrearTramiteAsync(token, tramite);
            return response;
        }
        public async Task<Response<object>> eliminarTramite(string token, int idTramite)
        {
            Response<object> response = await EliminarTramite.EliminarTramiteAsync(token, idTramite);
            return response;
        }
        public async Task<Response<object>> actualizarTramite(string token, Tramite tramite)
        {
            Response<object> response = await ActualizarTramite.ActualizarTramiteAsync(token, tramite);
            return response;
        }
        public async Task<Response<Tramite>> consultarTramite(string token, int idTramite)
        {
            Response<Tramite> response = await ConsultarTramite.ConsultarTramiteAsync(token, idTramite);
            return response;
        }
        public async Task<Response<List<Tramite>>> consultarTramitesFiltro(string token, FiltroTramite filtroTramite)
        {
            Response<List<Tramite>> response = await ConsultarTramitesFiltro.ConsultarTramitesFiltroAsync(token, filtroTramite);
            return response;
        }
    }
}
