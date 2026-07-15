using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Select
{
    public class SolicitantesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Solicitante> SelectCityApp = new SelectCityApp<Solicitante>();

        public SolicitantesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Solicitante>> SelectSolicitantes()
        {
            Response<IEnumerable<Solicitante>> response = new Response<IEnumerable<Solicitante>>();

            try
            {
                response.Data = CityAppContext.Solicitantes;

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
