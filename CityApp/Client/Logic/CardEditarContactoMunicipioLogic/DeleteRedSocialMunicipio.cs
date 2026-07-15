using CityApp.Client.Services.ApiRest.RedSocialMunicipioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarContactoMunicipioLogic
{
    public class DeleteRedSocialMunicipio
    {
        private RedSocialMunicipioPeticiones RedSocialMunicipioPeticiones;

        public DeleteRedSocialMunicipio(HttpClient cliente)
        {
            RedSocialMunicipioPeticiones = new RedSocialMunicipioPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idRedSocialMunicipio)
        {
            Response<object> response = await RedSocialMunicipioPeticiones.eliminarRedSocialMunicipio(token, idRedSocialMunicipio);
            return response;
        }
    }
}
