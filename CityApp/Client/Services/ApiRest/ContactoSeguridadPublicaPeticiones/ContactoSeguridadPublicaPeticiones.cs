using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones
{
    public class ContactoSeguridadPublicaPeticiones
    {
        private CrearContactoSeguridadPublica CrearContactoSeguridadPublica;
        private ConsultarContactoSeguridadPublica ConsultarContactoSeguridadPublica;
        private ConsultarContactosSeguridadPublica ConsultarContactosSeguridadPublica;
        private ActualizarContactoSeguridadPublica ActualizarContactoSeguridadPublica;
        private EliminarContactoSeguridadPublica EliminarContactoSeguridadPublica;

        public ContactoSeguridadPublicaPeticiones(HttpClient cliente)
        {
            CrearContactoSeguridadPublica = new CrearContactoSeguridadPublica(cliente);
            ConsultarContactoSeguridadPublica = new ConsultarContactoSeguridadPublica(cliente);
            ConsultarContactosSeguridadPublica = new ConsultarContactosSeguridadPublica(cliente);
            ActualizarContactoSeguridadPublica = new ActualizarContactoSeguridadPublica(cliente);
            EliminarContactoSeguridadPublica = new EliminarContactoSeguridadPublica(cliente);
        }

        public async Task<Response<object>> crearContactoSeguridadPublica(string token, ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            Response<object> response = await CrearContactoSeguridadPublica.CrearContactoSeguridadPublicaAsync(token, ContactoSeguridadPublica);
            return response;
        }

        public async Task<Response<ContactoSeguridadPublica>> consultarContactoSeguridadPublica(string token, int idContactoSeguridadPublica)
        {
            Response<ContactoSeguridadPublica> response = await ConsultarContactoSeguridadPublica.ConsultarContactoSeguridadPublicaAsync(token, idContactoSeguridadPublica);
            return response;
        }

        public async Task<Response<List<ContactoSeguridadPublica>>> consultarContactoSeguridadPublicas(string token)
        {
            Response<List<ContactoSeguridadPublica>> response = await ConsultarContactosSeguridadPublica.ConsultarContactosSeguridadPublicaAsync(token);
            return response;
        }

        public async Task<Response<object>> actualizarContactoSeguridadPublica(string token, ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            Response<object> response = await ActualizarContactoSeguridadPublica.ActualizarContactoSeguridadPublicaAsync(token, ContactoSeguridadPublica);
            return response;
        }

        public async Task<Response<object>> eliminarContactoSeguridadPublica(string token, int idContactoSeguridadPublica)
        {
            Response<object> response = await EliminarContactoSeguridadPublica.EliminarContactoSeguridadPublicaAsync(token, idContactoSeguridadPublica);
            return response;
        }
    }
}
