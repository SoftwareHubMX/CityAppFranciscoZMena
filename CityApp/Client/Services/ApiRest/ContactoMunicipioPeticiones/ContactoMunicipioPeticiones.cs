using CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones
{
    public class ContactoMunicipioPeticiones
    {
        private CrearContactoMunicipio CrearContactoMunicipio;
        private ConsultarContactoMunicipio ConsultarContactoMunicipio;
        private ConsultarContactoMunicipioApp ConsultarContactoMunicipioApp;
        private ActualizarContactoMunicipio ActualizarContactoMunicipio;

        public ContactoMunicipioPeticiones(HttpClient cliente)
        {
            CrearContactoMunicipio = new CrearContactoMunicipio(cliente);
            ConsultarContactoMunicipio = new ConsultarContactoMunicipio(cliente);
            ConsultarContactoMunicipioApp = new ConsultarContactoMunicipioApp(cliente);
            ActualizarContactoMunicipio = new ActualizarContactoMunicipio(cliente);
        }

        public async Task<Response<int>> crearContactoMunicipio(string token, ContactoMunicipio ContactoMunicipio)
        {
            Response<int> response = await CrearContactoMunicipio.CrearContactoMunicipioAsync(token, ContactoMunicipio);
            return response;
        }

        public async Task<Response<ContactoMunicipio>> consultarContactoMunicipio(string token, int idContactoMunicipio)
        {
            Response<ContactoMunicipio> response = await ConsultarContactoMunicipio.ConsultarContactoMunicipioAsync(token, idContactoMunicipio);
            return response;
        }

        public async Task<Response<ContactoMunicipio>> consultarContactoMunicipios()
        {
            Response<ContactoMunicipio> response = await ConsultarContactoMunicipioApp.ConsultarContactoMunicipioAppAsync();
            return response;
        }

        public async Task<Response<object>> actualizarContactoMunicipio(string token, ContactoMunicipio ContactoMunicipio)
        {
            Response<object> response = await ActualizarContactoMunicipio.ActualizarContactoMunicipioAsync(token, ContactoMunicipio);
            return response;
        }
    }
}
