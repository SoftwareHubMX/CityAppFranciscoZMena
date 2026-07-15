using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoRedSocialQuerys.Select
{
    public class TipoRedSocialSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoRedSocial> SelectCityApp = new SelectCityApp<TipoRedSocial>();

        public TipoRedSocialSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoRedSocial> SelectTipoRedSocial(int idTipoRedSocial)
        {
            Response<TipoRedSocial> response = new Response<TipoRedSocial>();

            try
            {
                response.Data = CityAppContext.TiposRedesSociales.Where(d => d.IdTipoRedSocial == idTipoRedSocial).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
