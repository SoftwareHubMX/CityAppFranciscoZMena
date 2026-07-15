using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PagoLogic
{
    public class ConsultarPagosAdministradorLogic
    {
        private PagoQuerys PagoQuerys;

        private FiltroPagos FiltroPagos;

        public ConsultarPagosAdministradorLogic(CityAppContext cityAppContext, FiltroPagos filtroPagos)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);

            FiltroPagos = filtroPagos;
        }

        public Response<List<Pago>> Consultar()
        {
            Response<List<Pago>> response = new Response<List<Pago>>();

            Response<IEnumerable<Pago>> responsePagos = PagoQuerys.SelectPagosFiltroPagos(FiltroPagos);
            response.Status = responsePagos.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responsePagos.Data.ToList();
                response.Info = responsePagos.Info;
            }

            return response;
        }
    }
}
