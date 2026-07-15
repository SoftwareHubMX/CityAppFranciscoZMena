using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoLugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarTipoLugarTuristicoDashBoardLogic
    {
        private TipoLugarTuristicoQuerys TipoLugarTuristicoQuerys;
        private LugarTuristicoQuerys LugarTuristicoQuerys;
        private FechasDashBoard FechasDashBoard;
        

        public ConsultarTipoLugarTuristicoDashBoardLogic(CityAppContext cityAppContext, FechasDashBoard fechasDashBoard)
        {
            TipoLugarTuristicoQuerys = new TipoLugarTuristicoQuerys(cityAppContext);
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContext);
            FechasDashBoard = fechasDashBoard;
        }

        public Response<List<ChartData>> Consultar()
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();


            Response<IEnumerable<TipoLugarTuristico>> responseTipoLugar = TipoLugarTuristicoQuerys.SelectTiposLugarTuristico();
            response.Status = responseTipoLugar.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<ChartData>();
                foreach (var Tipo in responseTipoLugar.Data)
                {
                    ChartData data = new ChartData()
                    {
                        Label = Tipo.Tipo,
                        Data = new List<double>()
                    };
                    Response<IEnumerable<LugarTuristico>> responseLugar = new Response<IEnumerable<LugarTuristico>>();
                    responseLugar = LugarTuristicoQuerys.SelectLugarTuristicoTiposLugarTuristico(Tipo.IdTipoLugarTuristico, FechasDashBoard);
                    response.Status = responseLugar.Status;
                    if (response.Status.Exito == 1)
                    {
                        data.Data.Add(responseLugar.Data.ToList().Count);
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
