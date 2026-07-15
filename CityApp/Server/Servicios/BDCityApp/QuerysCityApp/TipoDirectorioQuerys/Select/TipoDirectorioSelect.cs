using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoDirectorioQuerys.Select
{
    public class TipoDirectorioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoDirectorio> SelectCityApp = new SelectCityApp<TipoDirectorio>();

        public TipoDirectorioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoDirectorio> SelectTipoDirectorio(int idTipoDirectorio)
        {
            Response<TipoDirectorio> response = new Response<TipoDirectorio>();

            try
            {
                response.Data = CityAppContext.TiposDirectorio.Where(d => d.IdTipoDirectorio == idTipoDirectorio).First();

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
