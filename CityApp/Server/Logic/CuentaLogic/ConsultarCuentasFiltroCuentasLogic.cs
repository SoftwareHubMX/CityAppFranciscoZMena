using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class ConsultarCuentasFiltroCuentasLogic
    {
        private CuentaQuerys CuentaQuerys;
        private UsuarioQuerys UsuarioQuerys;
        private ContactoQuerys ContactoQuerys;
        private RolQuerys RolQuerys;

        private FiltroCuentas FiltroCuentas;

        public ConsultarCuentasFiltroCuentasLogic(CityAppContext cityAppContext, FiltroCuentas filtroCuentas)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            UsuarioQuerys = new UsuarioQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);
            RolQuerys = new RolQuerys(cityAppContext);

            FiltroCuentas = filtroCuentas;
        }

        public Response<List<Cuenta>> Consultar()
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();

            Response<IEnumerable<Cuenta>> responseCuenta = CuentaQuerys.SelectCuentasFiltroCuentas(FiltroCuentas);
            response.Status = responseCuenta.Status;
            if (response.Status.Exito == 1)
            {
                
                response.Data = responseCuenta.Data.ToList();
                response.Info = responseCuenta.Info;
            }
            return response;
        }
    }
}