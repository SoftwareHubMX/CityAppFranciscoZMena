using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys.Select
{
    public class TokenContadorAccesosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TokenContadorAccesos> SelectCityApp = new SelectCityApp<TokenContadorAccesos>();

        public TokenContadorAccesosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TokenContadorAccesos> SelectTokenContadorAccesosIdCuenta(int idCuenta)
        {
            Response<TokenContadorAccesos> response = new Response<TokenContadorAccesos>();

            try
            {
                response.Data = CityAppContext.TokensContadorAcceso.Where(d => d.IdCuenta == idCuenta).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<TokenContadorAccesos> SelectTokenContadorAccesosToken(string token)
        {
            Response<TokenContadorAccesos> response = new Response<TokenContadorAccesos>();

            try
            {
                response.Data = CityAppContext.TokensContadorAcceso.Where(d => d.Token == token).First();

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
