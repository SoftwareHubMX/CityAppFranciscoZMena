using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Update
{
    public class RedSocialMunicipioUpdate
    {
        private UpdateCityApp<RedSocialMunicipio> UpdateCityApp;

        public RedSocialMunicipioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<RedSocialMunicipio>(cityAppContext);
        }

        public Response<object> UpdateRedSocialMunicipio(RedSocialMunicipio RedSocialMunicipio)
        {
            return UpdateCityApp.Save(RedSocialMunicipio);
        }
    }
}
