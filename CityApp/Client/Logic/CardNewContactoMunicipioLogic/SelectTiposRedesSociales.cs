using CityApp.Client.Services.ApiRest.TipoRedSocialPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewContactoMunicipioLogic
{
    public class SelectTiposRedesSociales
    {
        private TipoRedSocialPeticiones TipoRedSocialPeticiones;

        public SelectTiposRedesSociales(HttpClient cliente)
        {
            TipoRedSocialPeticiones = new TipoRedSocialPeticiones(cliente);
        }

        public async Task<Response<List<TipoRedSocial>>> SelectAll()
        {
            Response<List<TipoRedSocial>> response = await TipoRedSocialPeticiones.consultarTiposRedesSociales();
            return response;
        }
    }
}
