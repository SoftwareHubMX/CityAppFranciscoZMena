using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.SecretariaPeticiones
{
    public class SecretariaPeticiones
    {        
        private CrearSecretaria CrearSecretaria;
        private EliminarSecretaria EliminarSecretaria;
        private ActualizarSecretaria ActualizarSecretaria;
        private ConsultarSecretaria ConsultarSecretaria;
        private ConsultarSecretariasFiltro ConsultarSecretariasFiltro;
        private ConsultarSecretarias ConsultarSecretarias;

        
        public SecretariaPeticiones(HttpClient cliente)
        {
            CrearSecretaria = new CrearSecretaria(cliente);
            EliminarSecretaria = new EliminarSecretaria(cliente);
            ActualizarSecretaria = new ActualizarSecretaria(cliente);
            ConsultarSecretaria = new ConsultarSecretaria(cliente);
            ConsultarSecretariasFiltro = new ConsultarSecretariasFiltro(cliente);
            ConsultarSecretarias = new ConsultarSecretarias(cliente);

        }

        public async Task<Response<object>> crearSecretaria(string toke, Secretaria secretaria)
        {
            Response<object> response = await CrearSecretaria.CrearSecretariaAsync(toke, secretaria);
            return response;
        }
        public async Task<Response<object>> eliminarSecretaria(string toke, int idSecretaria)
        {
            Response<object> response = await EliminarSecretaria.EliminarSecretariaAsync(toke, idSecretaria);
            return response;
        }
        public async Task<Response<object>> actualizarSecretaria(string token, Secretaria secretaria)
        {
            Response<object> response = await ActualizarSecretaria.ActualizarSecretariaAsync(token, secretaria);
            return response;
        }
        public async Task<Response<Secretaria>> consultarSecretaria(string token, int idSecretaria)
        {
            Response<Secretaria> response = await ConsultarSecretaria.ConsultarSecretariaAsync(token, idSecretaria);
            return response;
        }
        public async Task<Response<List<Secretaria>>> consultarSecretariasFiltro(string token, FiltroSecretaria filtroSecretaria)
        {
            Response<List<Secretaria>> response = await ConsultarSecretariasFiltro.ConsultarSecretariasFiltroAsync (token, filtroSecretaria);
            return response;
        }

        public async Task<Response<List<Secretaria>>> consultarSecretarias()
        {
            Response<List<Secretaria>> response = await ConsultarSecretarias.ConsultarSecretariasAsync();
            return response;
        }

    }
}
