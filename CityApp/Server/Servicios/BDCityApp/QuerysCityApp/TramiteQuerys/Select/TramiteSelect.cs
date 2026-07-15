using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Select
{
    public class TramiteSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Tramite> SelectCityApp = new SelectCityApp<Tramite>();

        public TramiteSelect (CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<Tramite> SelectTramiteIdTramite(int idTramite)
        {
            Response<Tramite> response = new Response<Tramite>();

            try
            {
                response.Data = CityAppContext.Tramites.Where(d =>d.IdTramite == idTramite).First();
                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }

        public Response<Tramite> SelectTramiteIdTipoTramite(int idTipoTramite)
        {
            Response<Tramite> response = new Response<Tramite>();

            try
            {
                response.Data = CityAppContext.Tramites.Where(d => d.IdTipoTramite == idTipoTramite).FirstOrDefault();
                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch(Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }
    }
}
