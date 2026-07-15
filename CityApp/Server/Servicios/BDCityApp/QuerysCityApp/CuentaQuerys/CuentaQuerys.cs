using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys
{
    public class CuentaQuerys
    {
        private CuentaInsert CuentaInsert;
        private IdCuentaSelect IdCuentaSelect;
        private NombreUsuarioSelect NombreUsuarioSelect;
        private CuentaSelect CuentaSelect;
        private IdRolSelect IdRolSelect;
        private IdsCuentaSelect IdsCuentaSelect;
        private CuentaUpdate CuentaUpdate;
        private CuentasSelect CuentasSelect;   
        

        public CuentaQuerys(CityAppContext cityAppContext)
        {
            CuentaInsert = new CuentaInsert(cityAppContext);
            IdCuentaSelect = new IdCuentaSelect(cityAppContext);
            NombreUsuarioSelect = new NombreUsuarioSelect(cityAppContext);
            CuentaSelect = new CuentaSelect(cityAppContext);
            IdRolSelect = new IdRolSelect(cityAppContext);
            IdsCuentaSelect = new IdsCuentaSelect(cityAppContext);
            CuentaUpdate = new CuentaUpdate(cityAppContext);
            CuentasSelect = new CuentasSelect(cityAppContext);  
        }

        //insert
        public Response<object> InsertCuenta(Cuenta cuenta)
        {
            return CuentaInsert.InsertCuenta(cuenta);
        }

        //select
        public Response<int> SelectIdCuentaNombreUsuario(string nombreUsuario)
        {
            return IdCuentaSelect.SelectIdCuentaNombreUsuario(nombreUsuario);
        }
        public Response<int> SelectIdCuentaCorreo(string correo)
        {
            return IdCuentaSelect.SelectIdCuentaCorreo(correo);
        }
        public Response<string> SelectNombreUsuarioIdCuenta(int idCuenta)
        {
            return NombreUsuarioSelect.SelectNombreUsuarioIdCuenta(idCuenta);
        }
        public Response<string> SelectNombreUsuarioNombreUsuario(string nombreUsuario)
        {
            return NombreUsuarioSelect.SelectNombreUsuarioNombreUsuario(nombreUsuario);
        }
        public Response<Cuenta> SelectCuentaIdCuenta(int idCuenta)
        {
            return CuentaSelect.SelectCuentaIdCuenta(idCuenta);
        }
        public Response<IEnumerable<Cuenta>> SelectCuentas()
        {
            return CuentasSelect.SelectCuentas();
        }
        public Response<Cuenta> SelectCuentaCorreo(string correo)
        {
            return CuentaSelect.SelectCuentaCorreo(correo);
        }
        public Response<Cuenta> SelectCuentaIdCuentaPassword(int idCuenta, string password)
        {
            return CuentaSelect.SelectCuentaIdCuentaPassword(idCuenta, password);
        }
        public Response<int> SelectIdRolIdCuenta(int idCuenta)
        {
            return IdRolSelect.SelectIdRolIdCuenta(idCuenta);
        }
        public Response<IEnumerable<int>> SelectIdsCuentaIdRol(int idRol)
        {
            return IdsCuentaSelect.SelectIdsCuentaIdRol(idRol);
        }
        public Response<IEnumerable<int>> SelectIdsCuentaIdReporteCiudadano(int idReporteCiudadano)
        {
            return IdsCuentaSelect.SelectIdsCuentaIdReporteCiudadano(idReporteCiudadano);
        }


        public Response<IEnumerable<Cuenta>> SelectCuentasFiltroCuentas(FiltroCuentas filtroCuentas)
        {
            return CuentasSelect.SelectCuentasFiltroCuentas(filtroCuentas);
        }

        //update
        public Response<object> UpdateCuenta(Cuenta cuenta)
        {
            return CuentaUpdate.UpdateCuenta(cuenta);
        }
    }
}
