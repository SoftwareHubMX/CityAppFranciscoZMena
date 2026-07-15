using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Select
{
    public class RedSocialMunicipioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<RedSocialMunicipio> SelectCityApp = new SelectCityApp<RedSocialMunicipio>();

        public RedSocialMunicipioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<RedSocialMunicipio> SelectLastRedSocialMunicipio(int idTipoRedSocial, int idContactoMunicipio, string ruta)
        {
            Response<RedSocialMunicipio> response = new Response<RedSocialMunicipio>();

            try
            {
                response.Data = CityAppContext.RedesSocialesMunicipio.Where(d =>
                d.Ruta == ruta
                && d.IdTipoRedSocial == idTipoRedSocial 
                && d.IdContactoMunicipio == idContactoMunicipio).FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<RedSocialMunicipio> SelectRedSocialMunicipioIdRedSocialMunicipio(int IdRedSocialMunicipio)
        {
            Response<RedSocialMunicipio> response = new Response<RedSocialMunicipio>();

            try
            {
                response.Data = CityAppContext.RedesSocialesMunicipio.Where(d =>
                d.IdRedSocialMunicipio == IdRedSocialMunicipio).FirstOrDefault();

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
