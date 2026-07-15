using CityApp.Server.Servicios.Autenticacion;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SesionLogic
{
    public class ConsultarSesionLogic
    {
        private CuentaQuerys CuentaQuerys;
        private ContadorAccesoQuerys ContadorAccesoQuerys;
        private TokenContadorAccesosQuerys TokenContadorAccesosQuerys;
        private ContactoQuerys ContactoQuerys;
        private TokenLoginQuerys TokenLoginQuerys;

        private ServicioAutenticacion ServicioAutenticacion;
        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private LoginData LoginData;
        private Cuenta Cuenta = new Cuenta();

        public ConsultarSesionLogic(CityAppContext cityAppContext, LoginData loginData)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            ContadorAccesoQuerys = new ContadorAccesoQuerys(cityAppContext);
            TokenContadorAccesosQuerys = new TokenContadorAccesosQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);
            TokenLoginQuerys = new TokenLoginQuerys(cityAppContext);

            ServicioAutenticacion = new ServicioAutenticacion(cityAppContext);

            LoginData = loginData;
        }

        public Response<Sesion> Consultar()
        {
            Response<Sesion> response = new Response<Sesion>();

            Response<object> responseValidacion = ValidarUsuarioCorreo();
            response.Status = responseValidacion.Status;
            if (response.Status.Exito == 1)
            {
                Response<object> responseEliminarSesiones = EliminarSesiones();
                response.Status = responseEliminarSesiones.Status;
                if (response.Status.Exito == 1)
                {
                    responseValidacion = ValidarContadorAcceso();
                    response.Status = responseValidacion.Status;
                    if (response.Status.Exito == 1)
                    {
                        Response<Cuenta> responseCuenta = CuentaQuerys.SelectCuentaIdCuentaPassword(Cuenta.IdCuenta, LoginData.Password);
                        response.Status = responseCuenta.Status;
                        if (response.Status.Exito == 1)
                        {
                            responseCuenta.Data.ContadorAcceso = Cuenta.ContadorAcceso;
                            Cuenta = responseCuenta.Data;
                            Response<Contacto> responseContacto = ContactoQuerys.SelectContactoIdCenta(Cuenta.IdCuenta);
                            if (responseContacto.Status.Exito == 1)
                            {
                                Cuenta.Contacto = responseContacto.Data;
                            }
                            Response<string> responseServicioAutenticacion = ServicioAutenticacion.GenerarToken(LoginData);
                            response.Status = responseServicioAutenticacion.Status;
                            if (response.Status.Exito == 1)
                            {
                                Response<object> responseTokenLogin = TokenLoginQuerys.InsertTokenLogin(new TokenLogin()
                                {
                                    Token = responseServicioAutenticacion.Data,
                                    MantenerSesion = LoginData.MantenerSesion,
                                    IdTipoTokenLogin = LoginData.IdTipoTokenLogin,
                                    IdCuenta = Cuenta.IdCuenta,
                                });
                                response.Status = responseTokenLogin.Status;
                                if (response.Status.Exito == 1)
                                {
                                    Cuenta.ContadorAcceso.Intento = 0;
                                    Response<object> responseContadorAcceso = ContadorAccesoQuerys.UpdateContadorAcceso(Cuenta.ContadorAcceso);
                                    response.Status = responseContadorAcceso.Status;
                                    if (response.Status.Exito == 1)
                                    {
                                        response.Data = new Sesion()
                                        {
                                            IdCuenta = Cuenta.IdCuenta,
                                            NombreUsuario = Cuenta.NombreUsuario,
                                            Correo = Cuenta.Contacto.Correo,
                                            TokenAcceso = responseServicioAutenticacion.Data,
                                            CorreoVerificado = Cuenta.EstatusCuenta.CorreoVerificado,
                                            PerfilCompleto = Cuenta.EstatusCuenta.PerfilCompleto,
                                            IdRol = Cuenta.Rol.IdRol,
                                            EstatusActivo = Cuenta.EstatusActivo,
                                        };
                                    }
                                }
                            }
                        }
                        else if (response.Status.Exito == 2)
                        {
                            Cuenta.ContadorAcceso.Intento = Cuenta.ContadorAcceso.Intento + 1;
                            Response<object> responseContadorAcceso = ContadorAccesoQuerys.UpdateContadorAcceso(Cuenta.ContadorAcceso);
                            response.Status = responseContadorAcceso.Status;
                            if (response.Status.Exito == 1)
                            {
                                response.Status.Exito = 2;
                                response.Status.Mensaje = "La contraseña esta erronea";
                            }
                        }
                    }
                }
            }

            return response;
        }

        private Response<object> ValidarUsuarioCorreo()
        {
            Response<object> response = new Response<object>();

            Response<int> responseIdCuenta = CuentaQuerys.SelectIdCuentaNombreUsuario(LoginData.Usuario);
            response.Status = responseIdCuenta.Status;
            if (response.Status.Exito == 1)
            {
                Cuenta.IdCuenta = responseIdCuenta.Data;
            }
            else if (response.Status.Exito == 2)
            {
                responseIdCuenta = CuentaQuerys.SelectIdCuentaCorreo(LoginData.Usuario);
                response.Status = responseIdCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    Cuenta.IdCuenta = responseIdCuenta.Data;
                }
                else if (response.Status.Exito == 2)
                {
                    response.Status.Mensaje = "El nombre de usuario o el correo no se encuentran registrados";
                }
            }

            return response;
        }

        private Response<object> EliminarSesiones()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<TokenLogin>> responseTokensLogin = TokenLoginQuerys.SelectTokensLoginMantenerSesionIdCuenta(false, Cuenta.IdCuenta);
            response.Status = responseTokensLogin.Status;
            if (response.Status.Exito == 1)
            {
                if (responseTokensLogin.Data.Count() > 0)
                {
                    response = TokenLoginQuerys.DeleteTokensLogin(responseTokensLogin.Data);
                }
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> ValidarContadorAcceso()
        {
            Response<object> response = new Response<object>();

            Response<ContadorAcceso> responseContadorAcceso = ContadorAccesoQuerys.SelectContadorAccesoIdCuenta(Cuenta.IdCuenta);
            response.Status = responseContadorAcceso.Status;
            if (response.Status.Exito == 1)
            {
                if (responseContadorAcceso.Data.Intento <= 5)
                {
                    Cuenta.ContadorAcceso = responseContadorAcceso.Data;
                }
                else
                {
                    response = GenerarTokenContador();
                    if (response.Status.Exito == 1)
                    {
                        response.Status.Exito = 2;
                        response.Status.Mensaje = "Se excedio el limite de intentos, revise su correo";
                    }
                }
            }

            return response;
        }

        private Response<object> GenerarTokenContador()
        {
            Response<object> response = new Response<object>();

            Response<string> responseToken = new Response<string>();
            string token = "";
            do
            {
                GeneradorTokens generadorTokens = GeneradorTokens.Instancia();
                token = generadorTokens.GetToken(40);
                responseToken = TokenContadorAccesosQuerys.SelectTokenToken(token);
            } while (responseToken.Status.Exito == 1);

            response.Status = responseToken.Status;
            if (response.Status.Exito == 2)
            {
                Response<TokenContadorAccesos> responseTokenContadorAccesos = TokenContadorAccesosQuerys.SelectTokenContadorAccesosIdCuenta(Cuenta.IdCuenta);
                response.Status = responseTokenContadorAccesos.Status;
                if (response.Status.Exito == 1)
                {
                    responseTokenContadorAccesos.Data.Token = token;
                    Cuenta.TokenContadorAccesos = responseTokenContadorAccesos.Data;
                    response = TokenContadorAccesosQuerys.UpdateTokenContadorAccesos(responseTokenContadorAccesos.Data);
                }
                else if (response.Status.Exito == 2)
                {
                    Cuenta.TokenContadorAccesos = new TokenContadorAccesos()
                    {
                        Token = token,
                        IdCuenta = Cuenta.IdCuenta,
                    };
                    response = TokenContadorAccesosQuerys.InsertTokenContadorAccesos(Cuenta.TokenContadorAccesos);
                }

                if (response.Status.Exito == 1)
                {
                    response = EnviarMail();
                }
            }

            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            Response<string> responseCorreo = ContactoQuerys.SelectCorreoIdCuenta(Cuenta.IdCuenta);
            response.Status = responseCorreo.Status;
            if (response.Status.Exito == 1)
            {
                string data = CorreoLimiteContadorAccesos.GetCorreo(Cuenta.TokenContadorAccesos.Token);
                response = ServicioEnviarCorreo.Enviar(responseCorreo.Data, data);
            }
            return response;
        }
    }
}
