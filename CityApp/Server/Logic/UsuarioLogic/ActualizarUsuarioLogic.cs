using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.UsuarioLogic
{
    public class ActualizarUsuarioLogic
    {
        private UsuarioQuerys UsuarioQuerys;
        private EstatusCuentaQuerys EstatusCuentaQuerys;

        private Usuario Usuario;

        public ActualizarUsuarioLogic(CityAppContext cityAppContext, Usuario usuario)
        {
            UsuarioQuerys = new UsuarioQuerys(cityAppContext);
            EstatusCuentaQuerys = new EstatusCuentaQuerys(cityAppContext);

            Usuario = usuario;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            response = UsuarioQuerys.UpdateUsuario(Usuario);
            if(response.Status.Exito == 1)
            {
                Response<EstatusCuenta> responseEstatus = new Response<EstatusCuenta>();
                responseEstatus = EstatusCuentaQuerys.SelectEstatusCuentaIdCuenta(Usuario.IdCuenta);
                response.Status = responseEstatus.Status;
                if(response.Status.Exito == 1)
                {
                    if(Usuario.Nombre != "NA" && Usuario.Apellidos != "NA" && Usuario.Direccion != "NA" && Usuario.Telefono != "NA")
                    {
                        responseEstatus.Data.PerfilCompleto = true;
                        response = EstatusCuentaQuerys.UpdateEstatusCuenta(responseEstatus.Data);
                    }
                }
            }

            return response;
        }
    }
}
