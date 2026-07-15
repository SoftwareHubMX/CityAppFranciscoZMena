using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.PostulacionPeticiones
{
    public class PostulacionPeticiones
    {
        private CrearPostulacion CrearPostulacion;
        private ConsultarFiltroPostulaciones ConsultarFiltroPostulaciones;
        

        public PostulacionPeticiones(HttpClient Cliente)
        {
            CrearPostulacion = new CrearPostulacion(Cliente);
            ConsultarFiltroPostulaciones = new ConsultarFiltroPostulaciones(Cliente);
            
        }

        public async Task<Response<object>> crearPostulacion(string token, Postulacion postulacion)
        {
            Response<object> response = await CrearPostulacion.CrearPostulacionAsync(token, postulacion);
            return response;
        }

        public async Task<Response<List<Postulacion>>> consultarFiltroPostulaciones(string token, FiltroPostulacion filtroPostulacion)
        {
            Response<List<Postulacion>> response = await ConsultarFiltroPostulaciones.ConsultarFiltroPostulacionesAsync(token, filtroPostulacion);
            return response;
        }
    }
}
