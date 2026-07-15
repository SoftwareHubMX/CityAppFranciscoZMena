using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones
{
    public class BolsaTrabajoPeticiones
    {
        private CrearBolsaTrabajo CrearBolsaTrabajo;
        private EliminarBolsaTrabajo EliminarBolsaTrabajo;
        private ActualizarBolsaTrabajo ActualizarBolsaTrabajo;
        private ConsultarBolsaTrabajo ConsultarBolsaTrabajo;
        private ConsultarFiltroBolsaTrabajo ConsultarFiltroBolsaTrabajo;

        public BolsaTrabajoPeticiones(HttpClient Cliente)
        {
            CrearBolsaTrabajo = new CrearBolsaTrabajo(Cliente);
            EliminarBolsaTrabajo = new EliminarBolsaTrabajo(Cliente);
            ActualizarBolsaTrabajo = new ActualizarBolsaTrabajo(Cliente);
            ConsultarBolsaTrabajo = new ConsultarBolsaTrabajo(Cliente);
            ConsultarFiltroBolsaTrabajo = new ConsultarFiltroBolsaTrabajo(Cliente);
        }

        public async Task<Response<object>> crearBolsaTrabajo(string token, BolsaTrabajo bolsaTrabajo)
        {
            Response<object> response = await CrearBolsaTrabajo.CrearBolsaTrabajoAsync(token, bolsaTrabajo);
            return response;
        }
        public async Task<Response<object>> eliminarBolsaTrabajo(string token, int idBolsaTrabajo)
        {
            Response<object> response = await EliminarBolsaTrabajo.EliminarBolsaTrabajoAsync(token, idBolsaTrabajo);
            return response;
        }
        public async Task<Response<object>> actualizarBolsaTrabajo(string token, BolsaTrabajo bolsaTrabajo)
        {
            Response<object> response = await ActualizarBolsaTrabajo.ActualizarBolsaTrabajoAsync(token, bolsaTrabajo);
            return response;
        }
        public async Task<Response<BolsaTrabajo>> consultarBolsaTrabajo(string token, int idBolsaTrabajo)
        {
            Response<BolsaTrabajo> response = await ConsultarBolsaTrabajo.ConsultarBolsaTrabajoAsync(token, idBolsaTrabajo);
            return response;
        }
        public async Task<Response<List<BolsaTrabajo>>> consultarFiltroBolsaTrabajo(string token, FiltroBolsaTrabajo filtroBolsaTrabajo)
        {
            Response<List<BolsaTrabajo>> response = await ConsultarFiltroBolsaTrabajo.ConsultarFiltroBolsaTrabajoAsync(token, filtroBolsaTrabajo);
            return response;
        }
    }
}
