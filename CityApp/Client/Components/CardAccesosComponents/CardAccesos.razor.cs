using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardAccesosLogic;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardAccesosComponents
{
    public partial class CardAccesos
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private string btn_registro = "Registro";
        private string btn_login = "Iniciar sesión";
        private bool banderaBotones = true;

        //private int acctionCards = 0;

        private CrearCuenta cuenta = new CrearCuenta();
        private Sesion sesion = new Sesion();
        private LoginData loginData = new LoginData();

        private string alerta = "";

        private string registroUsusario = "";
        private string registroPassword = "";
        private string confirmacionPassword = "";
        private string correo = "";
        private string registroUsusariError = "";
        private string registroPasswordError = "";
        private string confirmacionPasswordError = "";
        private string correoError = "";

        private string usuario = "";
        private string password = "";
        private string usuarioError = "";
        private string passwordError = "";

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                archivoIdioma = await LocalStorage.GetItemAsync<string>("Language");

                if (archivoIdioma != null)
                {
                    ViewString.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(archivoIdioma));
                }
                else
                {
                    archivoIdioma = "es-MX";
                    ViewString.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(archivoIdioma));
                    await LocalStorage.SetItemAsync<string>("Language", archivoIdioma);
                }
                StateHasChanged();
            }
        }

        private void TxtUsuarioRegistro(ChangeEventArgs args)
        {
            registroUsusario = args.Value.ToString();
            if (registroUsusario != "")
            {
                registroUsusariError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(registroUsusario))
                {
                    if (Validaciones.ValidarMinimoCarcteres(3, registroUsusario))
                    {
                        if (Validaciones.ValiddarMaximoCaracteres(13, registroUsusario))
                        {
                            registroUsusariError = "";
                            cuenta.Usuario = registroUsusario;
                        }
                        else
                        {
                            registroUsusariError = "UsuarioMaximoCAracteres";
                            cuenta.Usuario = "";
                        }
                    }
                    else
                    {
                        registroUsusariError = "UsuarioMinimoCAracteres";
                    }
                }
                else
                {
                    registroUsusariError = "NoCaracteresEspeciales";
                    registroUsusario = "";
                }
            }
            else
            {
                registroUsusariError = "IngreseUsuario";
            }
            StateHasChanged();
        }

        private void TxtCorreoRegistro(ChangeEventArgs args)
        {
            correo = args.Value.ToString().ToLower();
            if (correo != "")
            {
                correoError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(correo))
                {
                    if (Validaciones.ValidarCorreo(correo))
                    {
                        correoError = "";
                        cuenta.Correo = correo;
                    }
                    else
                    {
                        correoError = "CorreoValido";
                        cuenta.Correo = "";
                    }
                }
                else
                {
                    correoError = "NoCaracteresEspeciales";
                    correo = "";
                }
            }
            else
            {
                correoError = "IngreseCorreo";
            }
            StateHasChanged();
        }

        private void TxtPasswordRegistro(ChangeEventArgs args)
        {
            registroPassword = args.Value.ToString();
            if (registroPassword != "")
            {
                registroPasswordError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(registroPassword))
                {
                    if (Validaciones.ValidarContraseña(registroPassword))
                    {
                        registroPasswordError = "";
                        if (confirmacionPassword != "")
                        {
                            if(Validaciones.ValidarContraseñas(registroPassword, confirmacionPassword))
                            {
                                confirmacionPasswordError = "ConfirmePass";
                                cuenta.Password = registroPassword;
                            }
                            else
                            {
                                confirmacionPasswordError = "PassNoCoinsiden";
                            }
                        }
                    }
                    else
                    {
                        registroPasswordError = "FormatoPass";
                    }
                }
                else
                {
                    registroPasswordError = "NoCaracteresEspeciales";
                    registroPassword = "";
                }
            }
            else
            {
                registroPasswordError = "IngresePass";
            }
            StateHasChanged();
        }

        private void TxtPasswordConfirmacionRegistro(ChangeEventArgs args)
        {
            confirmacionPassword = args.Value.ToString();
            if (confirmacionPassword != "")
            {
                confirmacionPasswordError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(confirmacionPassword))
                {
                    if (Validaciones.ValidarContraseñas(registroPassword, confirmacionPassword))
                    {

                        confirmacionPasswordError = "";
                        cuenta.Password = registroPassword;
                    }
                    else
                    {
                        confirmacionPasswordError = "PassNoCoinsiden";

                    }
                }
                else
                {
                    confirmacionPasswordError = "NoCaracteresEspeciales";
                    confirmacionPassword = "";
                }
            }
            else
            {
                confirmacionPasswordError = "ConfirmePass";
            }
            StateHasChanged();
        }

        private async void Registrar()
        {
            alerta = "";
            StateHasChanged();
            if (banderaBotones)
            {
                banderaBotones = false;
                btn_registro = "carga";
                if (cuenta.Usuario != "" && cuenta.Usuario != "NA")
                {
                    if (cuenta.Correo != "" && cuenta.Correo != "NA")
                    {
                        if (cuenta.Password != "" && cuenta.Password != "NA")
                        {
                            InsertCuenta insertCuenta = new InsertCuenta(Cliente);
                            Response<object> response = new Response<object>();
                            response = await insertCuenta.Insert(cuenta);
                            if (response.Status.Exito == 1)
                            {
                                banderaBotones = true;
                                loginData.Usuario = registroUsusario;
                                loginData.Password = registroPassword;
                                LogIn();
                            }
                            else
                            {
                                alerta = response.Status.Mensaje;
                            }
                        }
                        else
                        {
                            registroPasswordError = "CampoRequerido";
                        }
                    }
                    else
                    {
                        correoError = "CampoRequerido";
                    }
                }
                else
                {
                    registroUsusariError = "CampoRequerido";
                }
                banderaBotones = true;
                btn_registro = "Registro";
            }
            else
            {
                alerta = "ProcesoEjecucion";
            }
            StateHasChanged();
        }


        private void TxtUsuario(ChangeEventArgs args)
        {
            usuario = args.Value.ToString();
            if (usuario != "")
            {
                usuarioError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(usuario))
                {
                    if (Validaciones.ValidarMinimoCarcteres(3, usuario))
                    {
                        if (Validaciones.ValiddarMaximoCaracteres(13, usuario))
                        {
                            usuarioError = "";
                            loginData.Usuario = usuario;
                        }
                        else
                        {
                            if (Validaciones.ValidarCorreo(usuario))
                            {
                                usuarioError = "";
                                loginData.Usuario = usuario;
                            }
                            else
                            {
                                usuarioError = "UsuarioMaximoCAracteresCorreo";
                                loginData.Usuario = "";
                            }
                        }
                    }
                    else
                    {
                        usuarioError = "UsuarioMinimoCAracteres";
                    }
                }
                else
                {
                    usuarioError = "NoCaracteresEspeciales";
                    usuario = "";
                }
            }
            else
            {
                usuarioError = "NombreUsuarioCorreo";
            }
            StateHasChanged();
        }

        private void TxtPassword(ChangeEventArgs args)
        {
            password = args.Value.ToString();
            if (password != "")
            {
                passwordError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(password))
                {
                    if (Validaciones.ValidarContraseña(password))
                    {

                        passwordError = "";
                        loginData.Password = password;
                    }
                    else
                    {
                        passwordError = "FormatoPass";
                    }
                }
                else
                {
                    passwordError = "NoCaracteresEspeciales";
                    password = "";
                }
            }
            else
            {
                passwordError = "IngresePass";
            }
        }

        private async void LogIn()
        {
            alerta = "";
            StateHasChanged();
            if (banderaBotones)
            {
                banderaBotones = false;
                btn_login = "carga";
                if (loginData.Usuario != "" && loginData.Usuario != "NA")
                {
                    if (loginData.Password != "" && loginData.Password != "NA")
                    {
                        SelectSesion selectSesion = new SelectSesion(Cliente);
                        Response<Sesion> response = new Response<Sesion>();
                        response = await selectSesion.Select(loginData);
                        if (response.Status.Exito == 1)
                        {
                            await LocalStorage.SetItemAsync<Sesion>("sesion", response.Data);
                            if(response.Data.IdRol != 2 && response.Data.IdRol != 7)
                            {
                                NavigationManager.NavigateTo("/DashBoard", true);
                            }
                            else
                            {
                                NavigationManager.NavigateTo("/Upps", true);
                            }
                        }
                        else
                        {
                            alerta = response.Status.Mensaje;
                        }
                    }
                    else
                    {
                        passwordError = "CampoRequerido";
                    }
                }
                else
                {
                    usuarioError = "CampoRequerido";
                }
                banderaBotones = true;
                btn_login = "Iniciar";
                StateHasChanged();
            }
            else
            {
                alerta = "ProcesoEjecucion";
            }
            StateHasChanged();
        }

        private void back()
        {
            NavigationManager.NavigateTo("/", true);
        }

        private void irRestaurarContraseña()
        {
            NavigationManager.NavigateTo("/RestaurarPassword/EnvioCorreo");
        }

        //Diseño
        private string section1 = "selected";
        private string section2 = "";
        private string carrusel1 = "";
        private string carrusel2 = "no_view";

        private void CambioSection(int posicion)
        {
            if (posicion == 0)
            {
                section1 = "selected";
                section2 = "";
                carrusel1 = "";
                carrusel2 = "no_view";
            }
            else if(posicion == 1)
            {
                section1 = "";
                section2 = "selected";
                carrusel1 = "no_view";
                carrusel2 = "";
            }
            StateHasChanged();
        }
    }
}
