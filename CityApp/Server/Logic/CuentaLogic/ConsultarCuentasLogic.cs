using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class ConsultarCuentasLogic
    {
        private CuentaQuerys CuentaQuerys;
        

        public ConsultarCuentasLogic(CityAppContext cityAppContex)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContex);
        }

        public Response<List<Cuenta>> Consultar()
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();

            Response<IEnumerable<Cuenta>> responseCuentas = CuentaQuerys.SelectCuentas();
            response.Status = responseCuentas.Status;
            if(response.Status.Exito== 1)
            {
                response.Data = responseCuentas.Data.ToList();
            }
            return response;
        }
    }
}
