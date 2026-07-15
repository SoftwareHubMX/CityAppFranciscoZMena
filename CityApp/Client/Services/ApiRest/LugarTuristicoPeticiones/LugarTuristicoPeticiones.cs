using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones
{
    public class LugarTuristicoPeticiones
    {
        private CrearLugarTuristicoPeticion CrearLugarTuristicoPeticion;
        private ConsultarLugarTuristico ConsultarLugarTuristico;
        private ConsultarLugaresTuristicosFiltos ConsultarLugaresTuristicosFiltos;
        private EditarLugarTuristico EditarLugarTuristico;
        private EliminarLugarTuristico EliminarLugarTuristico;

        public LugarTuristicoPeticiones(HttpClient cliente)
        {
            CrearLugarTuristicoPeticion = new CrearLugarTuristicoPeticion(cliente);
            ConsultarLugarTuristico = new ConsultarLugarTuristico(cliente);
            ConsultarLugaresTuristicosFiltos = new ConsultarLugaresTuristicosFiltos(cliente);
            EditarLugarTuristico = new EditarLugarTuristico(cliente);
            EliminarLugarTuristico = new EliminarLugarTuristico(cliente);
        }

        public async Task<Response<int>> crearLugarTuristicoPeticion(string token, CrearLugarTuristico crearLugarTuristico)
        {
            Response<int> response = await CrearLugarTuristicoPeticion.CrearLugarTuristicoAsync(token, crearLugarTuristico);
            return response;
        }

        public async Task<Response<LugarTuristico>> consultarLugarTuristico(int idLugaresTuristicos)
        {
            Response<LugarTuristico> response = await ConsultarLugarTuristico.ConsultarLugareTuristicoAsync(idLugaresTuristicos);
            return response;
        }

        public async Task<Response<List<LugarTuristico>>> consultarLugaresTuristicosFiltos(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            Response<List<LugarTuristico>> response = await ConsultarLugaresTuristicosFiltos.ConsultarLugaresTuristicosFiltosAsync(filtroLugaresTuristicos);
            return response;
        }

        public async Task<Response<object>> editarLugarTuristico(string token, LugarTuristico lugarTuristico)
        {
            Response<object> response = await EditarLugarTuristico.EditarLugarTuristicoAsync(token, lugarTuristico);
            return response;
        }

        public async Task<Response<object>> eliminarLugarTuristico(string token, int idLugarTuristico)
        {
            Response<object> response = await EliminarLugarTuristico.EliminarLugarTuristicoAsync(token, idLugarTuristico);
            return response;
        }
    }
}
