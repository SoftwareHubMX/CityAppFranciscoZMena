using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoDirectorioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoDirectorioLogic
{
    public class ConsultarTiposDirectorioLogic
    {
        private TipoDirectorioQuerys TipoDirectorioQuerys;

        public ConsultarTiposDirectorioLogic(CityAppContext cityAppContext)
        {
            TipoDirectorioQuerys = new TipoDirectorioQuerys(cityAppContext);
        }

        public Response<List<TipoDirectorio>> Consultar()
        {
            Response<List<TipoDirectorio>> response = new Response<List<TipoDirectorio>>();

            Response<IEnumerable<TipoDirectorio>> responseTipoDirectorio = TipoDirectorioQuerys.SelectTiposDirectorio();
            response.Status = responseTipoDirectorio.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<TipoDirectorio>();
                response.Data = responseTipoDirectorio.Data.ToList();
            }

            return response;
        }
    }
}
