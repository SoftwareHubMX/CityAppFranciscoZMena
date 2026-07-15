using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarComunicacionLogic
    {
        private NoticiaQuerys NoticiaQuerys;
        private AgendaQuerys AgendaQuerys;

        private FechasDashBoard FechasDashBoard;

        public ConsultarComunicacionLogic(CityAppContext cityAppContext, FechasDashBoard fechasDashBoard)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContext);
            AgendaQuerys = new AgendaQuerys(cityAppContext);

            FechasDashBoard = new FechasDashBoard()
            {
                TipoFecha = fechasDashBoard.TipoFecha,
                Year = fechasDashBoard.Year,
                Mes = fechasDashBoard.Mes,
            };
        }

        public Response<List<ChartData>> Consultar()
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            response.Data = new List<ChartData>();

            Response<int> responseTotalNoticias = new Response<int>();
            responseTotalNoticias = NoticiaQuerys.SelectNoticiasFechasDashBoard(FechasDashBoard);
            if(responseTotalNoticias.Status.Exito == 1)
            {
                ChartData dataComunicacion = new ChartData()
                {
                    Label = "Noticias",
                    Data = new List<double>(),
                };
                dataComunicacion.Data.Add(responseTotalNoticias.Data);
                response.Data.Add(dataComunicacion);
            }
            else
            {
                ChartData dataComunicacion = new ChartData()
                {
                    Label = "Noticias",
                    Data = new List<double>(),
                };
                dataComunicacion.Data.Add(0);
                response.Data.Add(dataComunicacion);
            }
            Response<int> responseTotalAgendas = new Response<int>();
            responseTotalAgendas = AgendaQuerys.SelectAgendasFechasDashBoard(FechasDashBoard);
            if (responseTotalAgendas.Status.Exito == 1)
            {
                ChartData dataComunicacion = new ChartData()
                {
                    Label = "Eventos",
                    Data = new List<double>(),
                };
                dataComunicacion.Data.Add(responseTotalAgendas.Data);
                response.Data.Add(dataComunicacion);
            }
            else
            {
                ChartData dataComunicacion = new ChartData()
                {
                    Label = "Eventos",
                    Data = new List<double>(),
                };
                dataComunicacion.Data.Add(0);
                response.Data.Add(dataComunicacion);
            }

            response.Status.Exito = (response.Data.Count > 0) ? 1 : 2;
            response.Status.Mensaje = (response.Data.Count > 0) ? "OK" : "No hay datos";

            return response;
        }
    }
}
