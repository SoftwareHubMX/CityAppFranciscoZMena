using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Select
{
    public class SecretariaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Secretaria> SelectCityApp = new SelectCityApp<Secretaria>();

        public SecretariaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Secretaria> SelectSecretariaIdSecretaria(int idSecretaria)
        {
            Response<Secretaria> response = new Response<Secretaria>();

            try
            {
                response.Data = CityAppContext.Secretarias.Where(d => d.IdSecretaria == idSecretaria).First();

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
