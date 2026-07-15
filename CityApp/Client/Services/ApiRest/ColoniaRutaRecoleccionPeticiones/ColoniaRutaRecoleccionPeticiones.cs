using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones
{
    public class ColoniaRutaRecoleccionPeticiones
    {
        private CrearColoniaRutaRecoleccion CrearColoniaRutaRecoleccion;
        private EliminarColoniaRutaRecoleccion EliminarColoniaRutaRecoleccion;
        private ConsultarColoniasRutaRecoleccion ConsultarColoniasRutaRecoleccion;

        public ColoniaRutaRecoleccionPeticiones(HttpClient cliente)
        {
            CrearColoniaRutaRecoleccion = new CrearColoniaRutaRecoleccion(cliente);
            EliminarColoniaRutaRecoleccion = new EliminarColoniaRutaRecoleccion(cliente);
            ConsultarColoniasRutaRecoleccion = new ConsultarColoniasRutaRecoleccion(cliente);
        }

        public async Task<Response<object>> crearColoniaRutaRecoleccion(string token, ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            Response<object> response = await CrearColoniaRutaRecoleccion.CrearColoniaRutaRecoleccionAsync(token, coloniaRutaRecoleccion);
            return response;
        }
        public async Task<Response<object>> eliminarColoniaRutaRecoleccion(string token, ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            Response<object> response = await EliminarColoniaRutaRecoleccion.EliminarColoniaRutaRecoleccionAsync(token, coloniaRutaRecoleccion);
            return response;
        }
        public async Task<Response<List<ColoniaRutaRecoleccion>>> consultarColoniasRutaRecoleccion(string token, int idRutaRecoleccion)
        {
            Response<List<ColoniaRutaRecoleccion>> response = await ConsultarColoniasRutaRecoleccion.ConsultarColoniasRutaRecoleccionAsync(token, idRutaRecoleccion);
            return response;
        }
    }
}
