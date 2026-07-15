using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys
{
    public class PagoQuerys
    {
        private PagoInsert PagoInsert;
        private PagosSelect PagosSelect;
        private LastPagoSelect LastPagoSelect;
        private PagoUpdate PagoUpdate;
        private PagoDelete PagoDelete;

        public PagoQuerys(CityAppContext cityAppContext)
        {
            PagoInsert = new PagoInsert(cityAppContext);
            PagosSelect = new PagosSelect(cityAppContext);
            LastPagoSelect = new LastPagoSelect(cityAppContext);
            PagoUpdate = new PagoUpdate(cityAppContext);
            PagoDelete = new PagoDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertPago(Pago pago)
        {
            return PagoInsert.InsertPago(pago);
        }

        //select
        public Response<IEnumerable<Pago>> SelectPagosFiltroPagos(FiltroPagos filtroPagos)
        {
            return PagosSelect.SelectPagosFiltroPagos(filtroPagos);
        }

        public Response<Pago> SelectPagoIdPago(int idPago)
        {
            return PagosSelect.SelectPagoIdPago(idPago);
        }

        public Response<Pago> SelectLastPago(int idCuente, DateTime fecha)
        {
            return LastPagoSelect.SelectLastPago(idCuente, fecha);
        }

        public Response<IEnumerable<Pago>> SelectPagosFechasDashBoard(int Year, int mes)
        {
            return PagosSelect.SelectPagosFechasDashBoard(Year, mes);
        }

        public Response<IEnumerable<Pago>> SelectPagos()
        {
            return PagosSelect.SelectPagos();
        }

        //Update
        public Response<object> UpdatePago(Pago pago)
        {
            return PagoUpdate.UpdatePago(pago);
        }

        //Delete
        public Response<object> DeletePago(Pago pago)
        {
            return PagoDelete.DeletePago(pago);
        }
    }
}
