using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PagoLogic
{
    public class EliminarPagoLogic
    {
        private PagoQuerys PagoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private Pago Pago;

        public EliminarPagoLogic(CityAppContext cityAppContext, int idPago)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);

            Pago = new Pago()
            {
                IdPago = idPago,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Pago> responseNotica = PagoQuerys.SelectPagoIdPago(Pago.IdPago);
            response.Status = responseNotica.Status;
            if (response.Status.Exito == 1)
            {
                Pago = responseNotica.Data;
                response = PagoQuerys.DeletePago(responseNotica.Data);
            }

            return response;
        }
    }
}
