using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class ActualizarNombreUsuarioLogic
    {
        private CuentaQuerys CuentaQuerys;

        private string NombreUsuario;
        private int IdCuenta;
        public ActualizarNombreUsuarioLogic(CityAppContext cityAppContext, string nombreUsuario, int idCuenta)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);

            NombreUsuario = nombreUsuario;
            IdCuenta = idCuenta;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            response = ValidarNombreUsuario();
            if (response.Status.Exito == 1)
            {
                Response<Cuenta> responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(IdCuenta);
                response.Status = responseCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    responseCuenta.Data.NombreUsuario = NombreUsuario;
                    response = CuentaQuerys.UpdateCuenta(responseCuenta.Data);
                }
            }

            return response;
        }

        private Response<object> ValidarNombreUsuario()
        {
            Response<object> response = new Response<object>();

            Response<string> responseNombreUsuario = CuentaQuerys.SelectNombreUsuarioNombreUsuario(NombreUsuario);
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
