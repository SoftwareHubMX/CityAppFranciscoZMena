using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Select
{
    public class SolicitanteSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Solicitante> SelectCityApp = new SelectCityApp<Solicitante>();

        public SolicitanteSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Solicitante> SelectSolicitanteIdSolicitante(int idSolicitante)
        {
            Response<Solicitante> response = new Response<Solicitante>();

            try
            {
                response.Data = CityAppContext.Solicitantes.Where(d => d.IdSolicitante == idSolicitante).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Solicitante> SelectLastIdSolicitante()
        {
            Response<Solicitante> response = new Response<Solicitante>();

            try
            {
                response.Data = CityAppContext.Solicitantes.OrderBy(d => d.IdSolicitante).LastOrDefault();

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
