using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class CrearCuentaLogic
    {
        private CuentaQuerys CuentaQuerys;
        private ContactoQuerys ContactoQuerys;
        private TokenVerificacionCorreoQuerys TokenVerificacionCorreoQuerys;

        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private Cuenta Cuenta;

        public CrearCuentaLogic(CityAppContext cityAppContext, CrearCuenta crearCuenta)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);
            TokenVerificacionCorreoQuerys = new TokenVerificacionCorreoQuerys(cityAppContext);

            Cuenta = new Cuenta()
            {
                NombreUsuario = crearCuenta.Usuario,
                Password = crearCuenta.Password,
                IdRol = 2,
                Usuario = new Usuario(),
                Contacto = new Contacto()
                {
                    Correo = crearCuenta.Correo
                },
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
                response = ValidarCorreo();
                if (response.Status.Exito == 1)
                {
                    response = GenerarTokenCorreo();
                    if (response.Status.Exito == 1)
                    {
                        response = CuentaQuerys.InsertCuenta(Cuenta);
                        if (response.Status.Exito == 1)
                        {
                            response = EnviarMail();
                        }
                    }
                }
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

        private Response<object> ValidarCorreo()
        {
            Response<object> response = new Response<object>();

            Response<string> responseCorreo = ContactoQuerys.SelectCorreoCorreo(Cuenta.Contacto.Correo);
            response.Status = responseCorreo.Status;

            if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }
            else if (response.Status.Exito == 1)
            {
                response.Status.Exito = 2;
                response.Status.Mensaje = "El correo ya se encuentra registrado";
            }

            return response;
        }

        private Response<object> GenerarTokenCorreo()
        {
            Response<object> response = new Response<object>();

            Response<string> responseToken = new Response<string>();
            string token = "";
            do
            {
                GeneradorTokens generadorTokens = GeneradorTokens.Instancia();
                token = generadorTokens.GetToken(40);
                responseToken = TokenVerificacionCorreoQuerys.SelectTokenToken(token);
            } while (responseToken.Status.Exito == 1);

            response.Status = responseToken.Status;
            if (response.Status.Exito == 2)
            {
                Cuenta.TokenVerificacionCorreo = new TokenVerificacionCorreo()
                {
                    Token = token,
                };
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            string data = CorreoVerificarCorreo.GetCorreo(Cuenta.TokenVerificacionCorreo.Token);
            response = ServicioEnviarCorreo.Enviar(Cuenta.Contacto.Correo, data);
            return response;
        }
    }
}
