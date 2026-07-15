using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DirectorioPeticiones
{
    public class DirectorioPeticiones
    {
        private CrearDirectorio CrearDirectorio;
        private EliminarDirectorio EliminarDirectorio;
        private EditarDirectorio EditarDirectorio;
        private ConsultarDirectorio ConsultarDirectorio;
        private ConsultarDirectorios ConsultarDirectorios;

        public DirectorioPeticiones(HttpClient cliente)
        {
           CrearDirectorio = new CrearDirectorio(cliente);
           EliminarDirectorio = new EliminarDirectorio(cliente);
           EditarDirectorio = new EditarDirectorio(cliente);
           ConsultarDirectorio = new ConsultarDirectorio(cliente);
           ConsultarDirectorios = new ConsultarDirectorios(cliente);
        }

        public async Task<Response<int>> crearDirectorio(string token, Directorio directorio)
        {
            Response<int> response = await CrearDirectorio.CrearDirectorioAsync(token, directorio);
            return response;
        }
        public async Task<Response<object>> eliminarDirectorio(string token, int idDirectorio)
        {
            Response<object> response = await EliminarDirectorio.EliminarDirectorioAsync(token, idDirectorio);
            return response;
        }

        public async Task<Response<object>> editarDirectorio(string token, Directorio directorio)
        {
            Response<object> response = await EditarDirectorio.EditarDirectorioAsync(token, directorio);
            return response;
        }
        public async Task<Response<Directorio>> consultarDirectorio(int idDirectorio)
        {
            Response<Directorio> response = await ConsultarDirectorio.ConsultarDirectorioAsync(idDirectorio);
            return response;
        }
        public async Task<Response<List<Directorio>>> consultarDirectorios(string token, FiltroDirectorio filtroDirectorio)
        {
            Response<List<Directorio>> response = await ConsultarDirectorios.ConsultarDirectoriosAsync(token, filtroDirectorio);
            return response;
        }


    }
}
