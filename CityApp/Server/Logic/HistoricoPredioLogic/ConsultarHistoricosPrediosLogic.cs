using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.HistoricoPredioLogic
{
    public class ConsultarHistoricosPrediosLogic
    {
        private HistoricoPredioQuerys HistoricoPredioQuerys;
        private ArchivoHistoricoPredioQuerys ArchivoHistoricoPredioQuerys;
        private CuentaQuerys CuentaQuerys;

        private FiltroHistoricoPredio FiltroHistoricoPredio = new FiltroHistoricoPredio();

        public ConsultarHistoricosPrediosLogic(CityAppContext cityAppContext, FiltroHistoricoPredio filtroHistoricoPredio)
        {
            HistoricoPredioQuerys = new HistoricoPredioQuerys(cityAppContext);
            ArchivoHistoricoPredioQuerys = new ArchivoHistoricoPredioQuerys(cityAppContext);
            CuentaQuerys = new CuentaQuerys(cityAppContext);

            FiltroHistoricoPredio = filtroHistoricoPredio;
        }

        public Response<List<HistoricoPredio>> Consultar()
        {
            Response<List<HistoricoPredio>> response = new Response<List<HistoricoPredio>>();

            Response<IEnumerable<HistoricoPredio>> responseList = new Response<IEnumerable<HistoricoPredio>>();
            responseList = HistoricoPredioQuerys.SelectHistoricoPrediosFiltroHistoricoPredios(FiltroHistoricoPredio);
            response.Status = responseList.Status;
            if(response.Status.Exito == 1)
            {
                response.Data = new List<HistoricoPredio>();
                response.Data = responseList.Data.ToList();
                response.Info = responseList.Info;
                for (int i = 0; i < response.Data.Count; i++)
                {
                    Response<ArchivoHistoricoPredio> responseArchivo = new Response<ArchivoHistoricoPredio>();
                    responseArchivo = ArchivoHistoricoPredioQuerys.SelectArchivoHistoricoPredioIdHistoricoPredioFirst(response.Data[i].IdHistoricoPredio);
                    if(responseArchivo.Status.Exito == 1)
                    {
                        response.Data[i].ArchivoHistoricoPredio = new ArchivoHistoricoPredio();
                        response.Data[i].ArchivoHistoricoPredio = responseArchivo.Data;
                        response.Data[i].ArchivoHistoricoPredio.HistoricoPredio = null;
                    }

                    Response<Cuenta> responseCuenta = new Response<Cuenta>();
                    responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(response.Data[i].IdCuenta);
                    if(responseCuenta.Status.Exito == 1)
                    {
                        response.Data[i].Cuenta = new Cuenta();
                        response.Data[i].Cuenta = responseCuenta.Data;
                    }
                }
            }

            return response;
        }
    }
}
