using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoRedSocialQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoRedSocialQuerys
{
    public class TipoRedSocialQuerys
    {
        private TiposRedesSocialesSelect TiposRedesSocialesSelect;
        private TipoRedSocialSelect TipoRedSocialSelect;

        public TipoRedSocialQuerys(CityAppContext cityAppContext)
        {
            TiposRedesSocialesSelect = new TiposRedesSocialesSelect(cityAppContext);
            TipoRedSocialSelect = new TipoRedSocialSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoRedSocial>> SelectTiposRedesSociales()
        {
            return TiposRedesSocialesSelect.SelectTiposRedesSociales();
        }

        public Response<TipoRedSocial> SelectTipoRedSocial(int idTipoRedSocial)
        {
            return TipoRedSocialSelect.SelectTipoRedSocial(idTipoRedSocial);
        }
    }
}
