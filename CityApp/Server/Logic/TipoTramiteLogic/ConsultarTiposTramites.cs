using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoTramiteLogic
{
    public class ConsultarTiposTramites
    {
        private TipoTramiteQuerys TipoTramiteQuerys;

        public ConsultarTiposTramites(CityAppContext cityAppContext)
        {
            TipoTramiteQuerys = new TipoTramiteQuerys(cityAppContext);
        }

        public Response<List<TipoTramite>> Consultar()
        {
            Response<List<TipoTramite>> response = new Response<List<TipoTramite>>();

            Response<IEnumerable<TipoTramite>> responseTipoTramite= TipoTramiteQuerys.SelectTiposTramites();
            response.Status = responseTipoTramite.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<TipoTramite>();
                response.Data = responseTipoTramite.Data.ToList();
            }

            return response;
        }
    }
}
