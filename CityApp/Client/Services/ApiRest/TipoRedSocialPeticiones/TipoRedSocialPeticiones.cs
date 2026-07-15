using CityApp.Client.Services.ApiRest.TipoRedSocialPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoRedSocialPeticiones
{
    public class TipoRedSocialPeticiones
    {
        private ConsultarTiposRedesSociales ConsultarTiposRedesSociales;

        public TipoRedSocialPeticiones(HttpClient cliente)
        {
            ConsultarTiposRedesSociales = new ConsultarTiposRedesSociales(cliente);
        }

        public async Task<Response<List<TipoRedSocial>>> consultarTiposRedesSociales()
        {
            Response<List<TipoRedSocial>> response = await ConsultarTiposRedesSociales.ConsultarTiposRedesSocialesAsync();
            return response;
        }
    }
}
