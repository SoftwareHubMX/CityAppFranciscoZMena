using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Insert
{
    public class RedSocialMunicipioInsert
    {
        private InsertCityApp<RedSocialMunicipio> InsertCityApp;

        public RedSocialMunicipioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<RedSocialMunicipio>(cityAppContext);
        }

        public Response<object> InsertRedSocialMunicipio(RedSocialMunicipio RedSocialMunicipio)
        {
            return InsertCityApp.Save(RedSocialMunicipio);
        }
    }
}
