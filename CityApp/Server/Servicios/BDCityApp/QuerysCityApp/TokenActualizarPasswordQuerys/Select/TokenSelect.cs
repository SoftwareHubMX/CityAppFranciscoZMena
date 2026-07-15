using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Select
{
    public class TokenSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<string> SelectCityApp = new SelectCityApp<string>();

        public TokenSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<string> SelectTokenToken(string token)
        {
            Response<string> response = new Response<string>();

            try
            {
                response.Data = CityAppContext.TokensActualizarPassword.Where(d => d.Token == token).First().Token;

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
