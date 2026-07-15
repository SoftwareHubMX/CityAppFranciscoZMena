using CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones
{
    public class RutaRecoleccionPeticiones
    {
        private CrearRutaRecoleccion CrearRutaRecoleccion;
        private EliminarRutaRecoleccion EliminarRutaRecoleccion;
        private ActualizarRutaRecoleccion ActualizarRutaRecoleccion;
        private ConsultarRutaRecoleccion ConsultarRutaRecoleccion;
        private ConsultarFiltroRutaRecoleccion ConsultarFiltroRutaRecoleccion;

        public RutaRecoleccionPeticiones(HttpClient cliente)
        {
            CrearRutaRecoleccion = new CrearRutaRecoleccion(cliente);
            EliminarRutaRecoleccion = new EliminarRutaRecoleccion(cliente);
            ActualizarRutaRecoleccion = new ActualizarRutaRecoleccion(cliente);
            ConsultarRutaRecoleccion = new ConsultarRutaRecoleccion(cliente);
            ConsultarFiltroRutaRecoleccion = new ConsultarFiltroRutaRecoleccion(cliente);
        }

        public async Task<Response<int>> crearRutaRecoleccion(string token, RutaRecoleccion rutaRecoleccion)
        {
            Response<int> response = await CrearRutaRecoleccion.CrearRutaRecoleccionAsync(token, rutaRecoleccion);
            return response;
        }
        public async Task<Response<object>> eliminarRutaRecoleccion(string token, int idRutaRecoleccion)
        {
            Response<object> response = await EliminarRutaRecoleccion.EliminarRutaRecoleccionAsync(token, idRutaRecoleccion);
            return response;
        }
        public async Task<Response<object>> actualizarRutaRecoleccion(string token, RutaRecoleccion rutaRecoleccion)
        {
            Response<object> response = await ActualizarRutaRecoleccion.ActualizarRutaRecoleccionAsync(token, rutaRecoleccion);
            return response;
        }
        public async Task<Response<RutaRecoleccion>> consultarRutaRecoleccion(string token, int idRutaRecoleccion)
        {
            Response<RutaRecoleccion> response = await ConsultarRutaRecoleccion.ConsultarRutaRecoleccionAsync(token, idRutaRecoleccion);
            return response;
        }
        public async Task<Response<List<RutaRecoleccion>>> consultarFiltroRutaRecoleccion(string token, FiltroRutaRecoleccion filtroRutaRecoleccion)
        {
            Response<List<RutaRecoleccion>> response = await ConsultarFiltroRutaRecoleccion.ConsultarFiltroRutaRecoleccionAsync(token, filtroRutaRecoleccion);
            return response;
        }
    }
}
