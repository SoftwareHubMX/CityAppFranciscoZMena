using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys.Select
{
    public class TiposTramitesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoTramite> SelectCityApp = new SelectCityApp<TipoTramite>();

        public TiposTramitesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoTramite>> SelectTiposTramites()
        {
            Response<IEnumerable<TipoTramite>> response = new Response<IEnumerable<TipoTramite>>();

            try
            {
                response.Data = CityAppContext.TiposTramites;

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
