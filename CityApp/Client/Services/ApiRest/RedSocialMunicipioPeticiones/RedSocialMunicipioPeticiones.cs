using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.RedSocialMunicipioPeticiones
{
    public class RedSocialMunicipioPeticiones
    {
        private CrearRedSocialMunicipio CrearRedSocialMunicipio;
        private EliminarRedSocialMunicipio EliminarRedSocialMunicipio;

        public RedSocialMunicipioPeticiones(HttpClient cliente)
        {
            CrearRedSocialMunicipio = new CrearRedSocialMunicipio(cliente);
            EliminarRedSocialMunicipio = new EliminarRedSocialMunicipio(cliente);
        }

        public async Task<Response<int>> agregarRedSocialMunicipioPeticion(string token, RedSocialMunicipio agregarRedSocialMunicipio)
        {
            Response<int> response = await CrearRedSocialMunicipio.CrearRedSocialMunicipioAsync(token, agregarRedSocialMunicipio);
            return response;
        }

        public async Task<Response<object>> eliminarRedSocialMunicipio(string token, int idRedSocialMunicipio)
        {
            Response<object> response = await EliminarRedSocialMunicipio.EliminarRedSocialMunicipioAsync(token, idRedSocialMunicipio);
            return response;
        }
    }
}
