using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys.Select
{
    public class TokenVerificacionCorreoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TokenVerificacionCorreo> SelectCityApp = new SelectCityApp<TokenVerificacionCorreo>();

        public TokenVerificacionCorreoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TokenVerificacionCorreo> SelectTokenVerificacionCorreo(string token)
        {
            Response<TokenVerificacionCorreo> response = new Response<TokenVerificacionCorreo>();

            try
            {
                response.Data = CityAppContext.TokensVerificacionCorreo.Where(d => d.Token == token).First();

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
