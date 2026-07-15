using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ColoniaPeticiones
{
    public class ColoniaPeticiones
    { 
        private CrearColonia CrearColonia;
        private EliminarColonia EliminarColonia;
        private ActualizarColonia ActualizarColonia;
        private ConsultarColonia ConsultarColonia;
        private ConsultarColonias ConsultarColonias;

        public ColoniaPeticiones(HttpClient cliente)
        {
            CrearColonia = new CrearColonia(cliente);
            EliminarColonia = new EliminarColonia(cliente);
            ActualizarColonia = new ActualizarColonia(cliente);
            ConsultarColonia = new ConsultarColonia(cliente);
            ConsultarColonias = new ConsultarColonias(cliente);
        }

        public async Task<Response<object>> crearColonia(string token, Colonia colonia)
        {
            Response<object> response = await CrearColonia.CrearColoniaAsync(token, colonia);
            return response;
        }
        public async Task<Response<object>> eliminarColonia(string token, int  idColonia)
        {
            Response<object> response = await EliminarColonia.EliminarColoniaAsync(token, idColonia);
            return response;
        }
        public async Task<Response<object>> actualizarColonia(string token, Colonia colonia)
        {
            Response<object> response = await ActualizarColonia.ActualizarColoniaAsync(token, colonia);
            return response;
        }
        public async Task<Response<Colonia>> consultarColonia(string token, int idColonia)
        {
            Response<Colonia> response = await ConsultarColonia.ConsultarColoniaAsync(token, idColonia);
            return response;
        }
        public async Task<Response<List<Colonia>>> consultarColonias()
        {
            Response<List<Colonia>> response = await ConsultarColonias.ConsultarColoniasAsync();
            return response;
        }
    }
}
