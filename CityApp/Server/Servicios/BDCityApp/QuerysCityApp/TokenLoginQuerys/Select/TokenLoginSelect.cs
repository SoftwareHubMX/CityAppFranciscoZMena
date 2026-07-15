using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Select
{
    public class TokenLoginSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TokenLogin> SelectCityApp = new SelectCityApp<TokenLogin>();

        public TokenLoginSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TokenLogin> SelectTokenLoginToken(string token)
        {
            Response<TokenLogin> response = new Response<TokenLogin>();

            try
            {
                response.Data = CityAppContext.TokensLogin.Where(d => d.Token == token).First();

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
