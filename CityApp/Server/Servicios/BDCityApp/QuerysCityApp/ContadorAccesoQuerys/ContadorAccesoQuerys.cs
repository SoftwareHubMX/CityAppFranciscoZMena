using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys
{
    public class ContadorAccesoQuerys
    {
        private ContadorAccesoInsert ContadorAccesoInsert;
        private ContadorAccesoSelect ContadorAccesoSelect;
        private ContadorAccesoUpdate ContadorAccesoUpdate;

        public ContadorAccesoQuerys(CityAppContext cityAppContext)
        {
            ContadorAccesoInsert = new ContadorAccesoInsert(cityAppContext);
            ContadorAccesoSelect = new ContadorAccesoSelect(cityAppContext);
            ContadorAccesoUpdate = new ContadorAccesoUpdate(cityAppContext);
        }

        //insert
        public Response<object> InsertContadorAcceso(ContadorAcceso contadorAcceso)
        {
            return ContadorAccesoInsert.InsertContadorAcceso(contadorAcceso);
        }

        //select
        public Response<ContadorAcceso> SelectContadorAccesoIdCuenta(int idCuenta)
        {
            return ContadorAccesoSelect.SelectContadorAccesoIdCuenta(idCuenta);
        }

        //update
        public Response<object> UpdateContadorAcceso(ContadorAcceso contadorAcceso)
        {
            return ContadorAccesoUpdate.UpdateContadorAcceso(contadorAcceso);
        }
    }
}
