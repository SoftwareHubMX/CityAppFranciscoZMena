using CityApp.Client.Services.ApiRest.RedSocialMunicipioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewContactoMunicipioLogic
{
    public class InsertRedSocialMunicipio
    {
        private RedSocialMunicipioPeticiones RedSocialMunicipioPeticiones;

        public InsertRedSocialMunicipio(HttpClient cliente)
        {
            RedSocialMunicipioPeticiones = new RedSocialMunicipioPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, RedSocialMunicipio redSocialMunicipio)
        {
            Response<int> response = await RedSocialMunicipioPeticiones.agregarRedSocialMunicipioPeticion(token, redSocialMunicipio);
            return response;
        }
    }
}
