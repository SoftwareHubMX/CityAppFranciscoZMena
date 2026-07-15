using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoRedSocialQuerys.Select
{
    public class TiposRedesSocialesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoRedSocial> SelectCityApp = new SelectCityApp<TipoRedSocial>();

        public TiposRedesSocialesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoRedSocial>> SelectTiposRedesSociales()
        {
            Response<IEnumerable<TipoRedSocial>> response = new Response<IEnumerable<TipoRedSocial>>();

            try
            {
                response.Data = CityAppContext.TiposRedesSociales;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
