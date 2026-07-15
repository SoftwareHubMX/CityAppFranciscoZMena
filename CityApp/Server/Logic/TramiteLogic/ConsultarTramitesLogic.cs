using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TramiteLogic
{
    public class ConsultarTramitesLogic
    {
        private TramiteQuerys TramiteQuerys;
        private List<Tramite> Tramite;
        private int IdDependencia = 0;


        public ConsultarTramitesLogic(CityAppContext cityAppContex, int idDependencia)
        {
            TramiteQuerys = new TramiteQuerys(cityAppContex);
            IdDependencia = idDependencia;
        }


        public Response<List<Tramite>> Consultar()
        {
            Response<List<Tramite>> response = new Response<List<Tramite>>();

            Response<IEnumerable<Tramite>> responseTramite = TramiteQuerys.SelectTramites(IdDependencia);
            response.Status = responseTramite.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Tramite>();
                response.Data = responseTramite.Data.ToList();
            }

            return response;
        }
    }
}
