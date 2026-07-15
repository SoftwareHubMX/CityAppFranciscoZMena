using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.PatrullaPeticiones
{
    public class PatrullaPeticiones
    {
        private CrearPatrulla CrearPatrulla;
        private ConsultarPatrulla ConsultarPatrulla;
        private ConsultarPatrullas ConsultarPatrullas;
        private ActualizarPatrulla ActualizarPatrulla;
        private EliminarPatrulla EliminarPatrulla;

        public PatrullaPeticiones(HttpClient cliente)
        {
            CrearPatrulla = new CrearPatrulla(cliente);
            ConsultarPatrulla = new ConsultarPatrulla(cliente);
            ConsultarPatrullas = new ConsultarPatrullas(cliente);
            ActualizarPatrulla = new ActualizarPatrulla(cliente);
            EliminarPatrulla = new EliminarPatrulla(cliente);
        }

        public async Task<Response<object>> crearPatrulla(string token, Patrulla patrulla)
        {
            Response<object> response = await CrearPatrulla.CrearPatrullaAsync(token, patrulla);
            return response;
        }

        public async Task<Response<Patrulla>> consultarPatrulla(string token, int idPatrulla)
        {
            Response<Patrulla> response = await ConsultarPatrulla.ConsultarPatrullaAsync(token, idPatrulla);
            return response;
        }

        public async Task<Response<List<Patrulla>>> consultarPatrullas(string token, FiltroPatrullas filtroPatrullas)
        {
            Response<List<Patrulla>> response = await ConsultarPatrullas.ConsultarPatrullasAsync(token, filtroPatrullas);
            return response;
        }

        public async Task<Response<object>> actualizarPatrulla(string token, Patrulla patrulla)
        {
            Response<object> response = await ActualizarPatrulla.ActualizarPatrullaAsync(token, patrulla);
            return response;
        }

        public async Task<Response<object>> eliminarPatrulla(string token, int idPatrulla)
        {
            Response<object> response = await EliminarPatrulla.EliminarPatrullaAsync(token, idPatrulla);
            return response;
        }
    }
}
