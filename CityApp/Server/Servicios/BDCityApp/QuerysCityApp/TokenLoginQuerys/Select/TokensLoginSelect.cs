using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Select
{
    public class TokensLoginSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TokenLogin> SelectCityApp = new SelectCityApp<TokenLogin>();

        public TokensLoginSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TokenLogin>> SelectTokensLoginMantenerSesionIdCuenta(bool mantenerSesion, int idCuenta)
        {
            Response<IEnumerable<TokenLogin>> response = new Response<IEnumerable<TokenLogin>>();

            try
            {
                response.Data = CityAppContext.TokensLogin.Where(d => (d.MantenerSesion == mantenerSesion && d.IdCuenta == idCuenta));

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<TokenLogin>> SelectTokensLoginIdCuenta(int idCuenta)
        {
            Response<IEnumerable<TokenLogin>> response = new Response<IEnumerable<TokenLogin>>();

            try
            {
                response.Data = CityAppContext.TokensLogin.Where(d => d.IdCuenta == idCuenta);
                
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
