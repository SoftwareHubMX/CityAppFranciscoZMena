using CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardContactoMunicipioLogic
{
    public class SelectContactoMunicipio
    {
        private ContactoMunicipioPeticiones ContactoMunicipioPeticiones;

        public SelectContactoMunicipio(HttpClient cliente)
        {
            ContactoMunicipioPeticiones = new ContactoMunicipioPeticiones(cliente);
        }

        public async Task<Response<ContactoMunicipio>> SelectAll()
        {
            Response<ContactoMunicipio> response = await ContactoMunicipioPeticiones.consultarContactoMunicipios();
            return response;
        }
    }
}
