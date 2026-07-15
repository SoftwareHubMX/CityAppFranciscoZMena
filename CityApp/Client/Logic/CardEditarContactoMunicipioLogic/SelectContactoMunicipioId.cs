using CityApp.Client.Services.ApiRest.ContactoMunicipioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarContactoMunicipioLogic
{
    public class SelectContactoMunicipioId
    {
        private ContactoMunicipioPeticiones ContactoMunicipioPeticiones;

        public SelectContactoMunicipioId(HttpClient cliente)
        {
            ContactoMunicipioPeticiones = new ContactoMunicipioPeticiones(cliente);
        }

        public async Task<Response<ContactoMunicipio>> Select(string token, int idContactoMunicipio)
        {
            Response<ContactoMunicipio> response = await ContactoMunicipioPeticiones.consultarContactoMunicipio(token, idContactoMunicipio);
            return response;
        }
    }
}
