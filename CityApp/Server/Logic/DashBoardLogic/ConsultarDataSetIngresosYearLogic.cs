using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarDataSetIngresosYearLogic
    {
        private PagoQuerys PagoQuerys;

        private FechasDashBoard FechasDashBoard;

        public ConsultarDataSetIngresosYearLogic(CityAppContext cityAppContext, FechasDashBoard fechasDashBoard)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);

            FechasDashBoard = new FechasDashBoard()
            {
                TipoFecha = fechasDashBoard.TipoFecha,
                Year = fechasDashBoard.Year,
                Year2 = fechasDashBoard.Year2,
                Mes = fechasDashBoard.Mes
            };
        }

        public Response<List<ChartData>> Consultar()
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            response.Data = new List<ChartData>();
            for(int i = FechasDashBoard.Year; i <= FechasDashBoard.Year2; i++)
            {
                ChartData chartAux = new ChartData()
                {
                    Label = i.ToString(),
                };
                chartAux.Data = new List<double>();
                for (int j = 0; j < 12; j++)
                {
                    double totalMes = 0;
                    Response<IEnumerable<Pago>> responsePagos = new Response<IEnumerable<Pago>>();
                    responsePagos = PagoQuerys.SelectPagosFechasDashBoard(i, (j + 1));
                    if(responsePagos.Status.Exito == 1)
                    {
                        List<Pago> PagosMes = responsePagos.Data.ToList();
                        foreach(var pago in PagosMes)
                        {
                            totalMes += pago.Total;
                        }
                    }
                    chartAux.Data.Add(totalMes);
                }
                response.Data.Add(chartAux);
            }

            response.Status.Exito = (response.Data.Count > 0) ? 1 : 0;
            response.Status.Mensaje = (response.Data.Count > 0) ? "OK" : "Error al generar el DataSet";

            return response;
        }
    }
}
