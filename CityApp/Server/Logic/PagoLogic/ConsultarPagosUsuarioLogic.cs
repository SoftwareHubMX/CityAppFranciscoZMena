using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PagoLogic
{
    public class ConsultarPagosUsuarioLogic
    {
        private PagoQuerys PagoQuerys;

        private FiltroPagos FiltroPagos;

        public ConsultarPagosUsuarioLogic(CityAppContext cityAppContext, FiltroPagos filtroPagos, int idCuenta)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);

            FiltroPagos = filtroPagos;
            FiltroPagos.IdCuenta = idCuenta;
        }

        public Response<List<Pago>> Consultar()
        {
            Response<List<Pago>> response = new Response<List<Pago>>();

            Response<IEnumerable<Pago>> responsePagos = PagoQuerys.SelectPagosFiltroPagos(FiltroPagos);
            response.Status = responsePagos.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responsePagos.Data.ToList();
            }

            return response;
        }
    }
}
