using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys.Select
{
    public class TipoTramiteSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoTramite> SelectCityApp = new SelectCityApp<TipoTramite>();

        public TipoTramiteSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoTramite> SelectTipoTramite(int idTipoTramite)
        {
            Response<TipoTramite> response = new Response<TipoTramite>();

            try
            {
                response.Data = CityAppContext.TiposTramites.Where(d => d.IdTipoTramite == idTipoTramite).First();

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
