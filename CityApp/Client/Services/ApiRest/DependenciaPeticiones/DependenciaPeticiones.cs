using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class DependenciaPeticiones
    {
        private CrearDependencia CrearDependencia;
        private EliminarDependencia EliminarDependencia;
        private ActualizarDependencia ActualizarDependencia;
        private ConsultarDependencia ConsultarDependencia;
        private ConsultarDependenciasFiltro ConsultarDependenciasFiltro;
        private ConsultarDependencias ConsultarDependencias;
       

        public DependenciaPeticiones(HttpClient cliente)
        {
            CrearDependencia = new CrearDependencia(cliente);
            EliminarDependencia = new EliminarDependencia(cliente);
            ActualizarDependencia = new ActualizarDependencia(cliente);
            ConsultarDependencia = new ConsultarDependencia(cliente);
            ConsultarDependenciasFiltro = new ConsultarDependenciasFiltro(cliente);
            ConsultarDependencias = new ConsultarDependencias(cliente);
           
                
        }

        public async Task<Response<object>> crearDependencia(string token, Dependencia dependencia)
        {
            Response<object> response = await CrearDependencia.CrearDependenciaAsync(token, dependencia);
            return response;
        }
        public async Task<Response<object>> eliminarDependencia(string token, int IdDependencia)
        {
            Response<object> response = await EliminarDependencia.EliminarDependenciaAsync(token, IdDependencia);
            return response;
        }
        public async Task<Response<object>> actualizarDependencia(string token, Dependencia dependencia)
        {
            Response<object> response = await ActualizarDependencia.ActualizarDependenciaAsync(token, dependencia);
            return response;
        }
        public async Task<Response<Dependencia>> consultarDependencia(string token, int idDependencia)
        {
            Response<Dependencia> response = await ConsultarDependencia.ConsultarDependenciaAsync(token, idDependencia);
            return response; 
        }
        public async Task<Response<List<Dependencia>>> consultarDependenciasFiltro(string token, FiltroDependencia filtroDependencia)
        {
            Response<List<Dependencia>> response = await ConsultarDependenciasFiltro.ConsultarDependenciasFiltroAsync(token, filtroDependencia);
            return response;
        }
        public async Task<Response<List<Dependencia>>> consultarDependencias(int idSecretaria)
        {
            Response<List<Dependencia>> response = await ConsultarDependencias.ConsultarDependenciasAsync(idSecretaria);
            return response;
        }

    }
}
