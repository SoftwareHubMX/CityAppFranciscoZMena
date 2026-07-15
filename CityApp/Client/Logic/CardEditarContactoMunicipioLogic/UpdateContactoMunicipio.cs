using CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarContactoMunicipioLogic
{
    public class UpdateContactoMunicipio
    {
        private ContactoMunicipioPeticiones ContactoMunicipioPeticiones;

        public UpdateContactoMunicipio(HttpClient cliente)
        {
            ContactoMunicipioPeticiones = new ContactoMunicipioPeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, ContactoMunicipio contactoMunicipio)
        {
            Response<object> response = await ContactoMunicipioPeticiones.actualizarContactoMunicipio(token, contactoMunicipio);
            return response;
        }
    }
}
