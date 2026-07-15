using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class CrearCuentaChoferLogic
    {
        private CuentaQuerys CuentaQuerys;

        private Cuenta Cuenta;

        public CrearCuentaChoferLogic(CityAppContext cityAppContext, CrearCuenta crearCuenta)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);

            Cuenta = new Cuenta()
            {
                NombreUsuario = crearCuenta.Usuario,
                Password = crearCuenta.Password,
                IdRol = 7,
                Usuario = new Usuario(),
                Contacto = new Contacto(),
                ContadorAcceso = new ContadorAcceso(),
                EstatusCuenta = new EstatusCuenta(),
                TokenActualizarPassword = new TokenActualizarPassword(),
                TokenContadorAccesos = new TokenContadorAccesos(),
            };
        }

        public Response<object> Crear()
        {
            Response<object> response = new Response<object>();

            response = ValidarNombreUsuario();
            if (response.Status.Exito == 1)
            {
                response = CuentaQuerys.InsertCuenta(Cuenta);
            }
            return response;
        }
        private Response<object> ValidarNombreUsuario()
        {
            Response<object> response = new Response<object>();

            Response<string> responseNombreUsuario = CuentaQuerys.SelectNombreUsuarioNombreUsuario(Cuenta.NombreUsuario);
            response.Status = responseNombreUsuario.Status;

            if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }
            else if (response.Status.Exito == 1)
            {
                response.Status.Exito = 2;
                response.Status.Mensaje = "El nombre de usuario ya se encuentra en uso";
            }

            return response;
        }
    }
}
