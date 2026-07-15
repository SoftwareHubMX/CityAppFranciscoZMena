using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.HistoricoPredioLogic
{
    public class CrearHistoricoPredioLogic
    {
        private HistoricoPredioQuerys HistoricoPredioQuerys;

        private HistoricoPredio HistoricoPredio = new HistoricoPredio();

        public CrearHistoricoPredioLogic(CityAppContext cityAppContext, HistoricoPredio historicoPredio, int idCuenta)
        {
            HistoricoPredioQuerys = new HistoricoPredioQuerys(cityAppContext);

            HistoricoPredio = historicoPredio;
            HistoricoPredio.IdCuenta = idCuenta;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsert = new Response<object>();
            responseInsert = HistoricoPredioQuerys.InsertHistoricoPredio(HistoricoPredio);
            response.Status = responseInsert.Status;
            if(response.Status.Exito == 1)
            {
                response = HistoricoPredioQuerys.SelectUltimoIdHistoricoPredioTexto(HistoricoPredio.NotaActualizacion, HistoricoPredio.FechaHistorico);
            }

            return response;
        }
    }
}
