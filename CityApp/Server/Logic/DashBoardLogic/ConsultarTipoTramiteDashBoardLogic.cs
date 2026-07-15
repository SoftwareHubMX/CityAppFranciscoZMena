using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarTipoTramiteDashBoardLogic
    {
        private TipoTramiteQuerys TipoTramiteQuerys;
        private TramiteQuerys TramiteQuerys;
        private FechasDashBoard FechasDashBoard;


        public ConsultarTipoTramiteDashBoardLogic(CityAppContext cityAppContext, FechasDashBoard fechasDashBoard)
        {
            TipoTramiteQuerys = new TipoTramiteQuerys(cityAppContext);
            TramiteQuerys = new TramiteQuerys(cityAppContext);
            FechasDashBoard = fechasDashBoard;
        }

        public Response<List<ChartData>> Consultar()
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();


            Response<IEnumerable<TipoTramite>> responseTipoTramite = TipoTramiteQuerys.SelectTiposTramites();
            response.Status = responseTipoTramite.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<ChartData>();
                foreach (var Tipo in responseTipoTramite.Data)
                {
                    ChartData data = new ChartData()
                    {
                        Label = Tipo.NombreTramite,
                        Data = new List<double>()
                    };
                    Response<IEnumerable<Tramite>> responseTramite = new Response<IEnumerable<Tramite>>();
                    responseTramite = TramiteQuerys.SelectTramiteTiposTramites(Tipo.IdTipoTramite, FechasDashBoard);
                    response.Status = responseTramite.Status;
                    if (response.Status.Exito == 1)
                    {
                        data.Data.Add(responseTramite.Data.ToList().Count);
                    }
                    else
                    {
                        data.Data.Add(0);
                    }
                    response.Data.Add(data);
                }
            }

            response.Status.Exito = (response.Data.Count > 0) ? 1 : 0;
            response.Status.Mensaje = (response.Data.Count > 0) ? "OK" : "Error al generar el DataSet";

            return response;
        }
    }
}
