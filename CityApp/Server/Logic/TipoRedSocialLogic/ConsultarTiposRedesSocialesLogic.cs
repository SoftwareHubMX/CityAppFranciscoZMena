using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoRedSocialQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoRedSocialLogic
{
    public class ConsultarTiposRedesSocialesLogic
    {
        private TipoRedSocialQuerys TipoRedSocialQuerys;

        public ConsultarTiposRedesSocialesLogic(CityAppContext cityAppContext)
        {
            TipoRedSocialQuerys = new TipoRedSocialQuerys(cityAppContext);
        }

        public Response<List<TipoRedSocial>> Consultar()
        {
            Response<List<TipoRedSocial>> response = new Response<List<TipoRedSocial>>();
            Response<IEnumerable<TipoRedSocial>> responseTipoRedSocial = new Response<IEnumerable<TipoRedSocial>>();
            responseTipoRedSocial = TipoRedSocialQuerys.SelectTiposRedesSociales();
            response.Status = responseTipoRedSocial.Status;
            if(response.Status.Exito == 1)
            {
                response.Data = new List<TipoRedSocial>();
                response.Data = responseTipoRedSocial.Data.ToList();
            }
            return response;
        }
    }
}
