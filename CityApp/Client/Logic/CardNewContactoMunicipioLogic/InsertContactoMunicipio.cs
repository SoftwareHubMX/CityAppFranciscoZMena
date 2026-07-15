using CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewContactoMunicipioLogic
{
    public class InsertContactoMunicipio
    {
        private ContactoMunicipioPeticiones ContactoMunicipioPeticiones;

        public InsertContactoMunicipio(HttpClient cliente)
        {
            ContactoMunicipioPeticiones = new ContactoMunicipioPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, ContactoMunicipio contactoMunicipio)
        {
            Response<int> response = await ContactoMunicipioPeticiones.crearContactoMunicipio(token, contactoMunicipio);
            return response;
        }
    }
}
