using CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DiaRutaPeticiones
{
    public class DiaRutaPeticiones
    {
        private CrearDiaRuta CrearDiaRuta;
        private ActualizarDiaRuta ActualizarDiaRuta;
        private ConsultarDiasRuta ConsultarDiasRuta;
        private EliminarDiaRuta EliminarDiaRuta;

        public DiaRutaPeticiones(HttpClient cliente)
        {
            CrearDiaRuta = new CrearDiaRuta(cliente);
            ActualizarDiaRuta = new ActualizarDiaRuta(cliente);
            ConsultarDiasRuta =  new ConsultarDiasRuta(cliente);
            EliminarDiaRuta =  new EliminarDiaRuta(cliente);    
        }

        public async Task<Response<object>> crearDiaRuta(string token, DiaRuta diaRuta)
        {
            Response<object> response = await CrearDiaRuta.CrearDiaRutaAsync(token, diaRuta);
            return response;
        }
        public async Task<Response<object>> actualizarDiaRuta(string token, DiaRuta diaRuta)
        {
            Response<object> response = await ActualizarDiaRuta.ActualizarDiaRutaAsync(token, diaRuta);
            return response;
        }

        public async Task<Response<List<DiaRuta>>> consultarDiasRuta(int idRutaRecoleccion)
        {
            Response<List<DiaRuta>> response = await ConsultarDiasRuta.ConsultarDiasRutaAsync(idRutaRecoleccion);
            return response;
        }
        public async Task<Response<object>> eliminarDiaRuta(string token, DiaRuta diaRuta)
        {
            Response<object> response = await EliminarDiaRuta.EliminarDiaRutaIdAsync(token, diaRuta);
            return response;
        }
    }
}
