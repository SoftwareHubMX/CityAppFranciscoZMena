using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoDirectorioQuerys.Select
{
    public class TiposDirectorioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoDirectorio> SelectCityApp = new SelectCityApp<TipoDirectorio>();

        public TiposDirectorioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoDirectorio>> SelectTiposDirectorio()
        {
            Response<IEnumerable<TipoDirectorio>> response = new Response<IEnumerable<TipoDirectorio>>();

            try
            {
                response.Data = CityAppContext.TiposDirectorio;

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
