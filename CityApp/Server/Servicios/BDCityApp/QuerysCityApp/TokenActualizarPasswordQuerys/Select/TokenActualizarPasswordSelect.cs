using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Select
{
    public class TokenActualizarPasswordSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TokenActualizarPassword> SelectCityApp = new SelectCityApp<TokenActualizarPassword>();

        public TokenActualizarPasswordSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TokenActualizarPassword> SelectTokenActualizarPasswordToken(string token)
        {
            Response<TokenActualizarPassword> response = new Response<TokenActualizarPassword>();

            try
            {
                response.Data = CityAppContext.TokensActualizarPassword.Where(d => d.Token == token).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<TokenActualizarPassword> SelectTokenActualizarPasswordIdCuenta(int idCuenta)
        {
            Response<TokenActualizarPassword> response = new Response<TokenActualizarPassword>();

            try
            {
                response.Data = CityAppContext.TokensActualizarPassword.Where(d => d.IdCuenta == idCuenta).First();

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
