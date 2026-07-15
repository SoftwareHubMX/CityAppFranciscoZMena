using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Delete
{
    public class RedSocialMunicipioDelete
    {
        private DeleteCityApp<RedSocialMunicipio> DeleteCityApp;

        public RedSocialMunicipioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<RedSocialMunicipio>(cityAppContext);
        }

        public Response<object> DeleteRedSocialMunicipio(RedSocialMunicipio RedSocialMunicipio)
        {
            return DeleteCityApp.Save(RedSocialMunicipio);
        }
    }
}
