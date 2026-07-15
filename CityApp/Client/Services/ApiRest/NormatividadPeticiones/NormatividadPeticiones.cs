using CityApp.Client.Services.ApiRest.ArchivoAgendaPeticiones;
using CityApp.Client.Services.ApiRest.NormatividadPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class NormatividadPeticiones
    {
        private CrearNormatividad CrearNormatividad;
        private ConsultarNormatividad ConsultarNormatividad;
        private ConsultarNormatividades ConsultarNormatividades;
        private ActualizarNormatividad ActualizarNormatividad;
        private EliminarNormatividad EliminarNormatividad;
        private AgregarArchivoNormatividad AgregarArchivoNormatividad;
        private DescargarArchivoNormatividad DescargarArchivoNormatividad;
        private EliminarArchivoNormatividad EliminarArchivoNormatividad;

        public NormatividadPeticiones(HttpClient cliente)
        {
            CrearNormatividad = new CrearNormatividad(cliente);
            ConsultarNormatividad = new ConsultarNormatividad(cliente);
            ConsultarNormatividades = new ConsultarNormatividades(cliente);
            ActualizarNormatividad = new ActualizarNormatividad(cliente);
            EliminarNormatividad = new EliminarNormatividad(cliente);
            AgregarArchivoNormatividad = new AgregarArchivoNormatividad(cliente);
            DescargarArchivoNormatividad = new DescargarArchivoNormatividad(cliente);
            EliminarArchivoNormatividad = new EliminarArchivoNormatividad(cliente);
        }

        public async Task<Response<object>> crearNormatividad(string token, Normatividad Normatividad)
        {
            Response<object> response = await CrearNormatividad.CrearNormatividadAsync(token, Normatividad);
            return response;
        }

        public async Task<Response<Normatividad>> consultarNormatividad(string token, int idNormatividad)
        {
            Response<Normatividad> response = await ConsultarNormatividad.ConsultarNormatividadAsync(token, idNormatividad);
            return response;
        }

        public async Task<Response<List<Normatividad>>> consultarNormatividads(string token)
        {
            Response<List<Normatividad>> response = await ConsultarNormatividades.ConsultarNormatividadesAsync(token);
            return response;
        }

        public async Task<Response<object>> actualizarNormatividad(string token, Normatividad Normatividad)
        {
            Response<object> response = await ActualizarNormatividad.ActualizarNormatividadAsync(token, Normatividad);
            return response;
        }

        public async Task<Response<object>> eliminarNormatividad(string token, int idNormatividad)
        {
            Response<object> response = await EliminarNormatividad.EliminarNormatividadAsync(token, idNormatividad);
            return response;
        }

        public async Task<Response<string>> agregarArchivoNormatividad(MultipartFormDataContent content, string token)
        {
            Response<string> response = await AgregarArchivoNormatividad.AgregarArchivoNormatividadAsync(content, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoNormatividad(string archivo)
        {
            Response<byte[]> response = await DescargarArchivoNormatividad.DescargarArchivoNormatividadAsync(archivo);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoNormatividad(string token, string archivo)
        {
            Response<object> response = await EliminarArchivoNormatividad.EliminarArchivoNormatividadAsync(token, archivo);
            return response;
        }
    }
}
