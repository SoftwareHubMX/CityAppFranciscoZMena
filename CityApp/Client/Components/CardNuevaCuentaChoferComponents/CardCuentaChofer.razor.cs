using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardAccesosLogic;
using CityApp.Client.Logic.CardCuentaChoferLogic;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNuevaCuentaChoferComponents
{
    public partial class CardCuentaChofer
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private CrearCuenta cuenta = new CrearCuenta();
        private LoginData loginData = new LoginData();

        private string alerta = "";
        private string btn_registro = "Registro";
        private string btn_login = "Iniciar sesión";
        private bool banderaBotones = true;

        private int IdRol = 7;

        private string registroUsusario = "";
        private string registroPassword = "";
        private string confirmacionPassword = "";
        private string registroUsusarioError = "";
        private string registroPasswordError = "";
        private string confirmacionPasswordError = "";

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
                registroUsusarioError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(registroUsusario))
                {
                    if (Validaciones.ValidarMinimoCarcteres(3, registroUsusario))
                    {
                        if (Validaciones.ValiddarMaximoCaracteres(13, registroUsusario))
                        {
                            registroUsusarioError = "";
                            cuenta.Usuario = registroUsusario;
                        }
                        else
                        {
                            registroUsusarioError = "UsuarioMaximoCAracteres";
                            cuenta.Usuario = "";
                        }
                    }
                    else
                    {
                        registroUsusarioError = "UsuarioMinimoCAracteres";
                    }
                }
                else
                {
                    registroUsusarioError = "NoCaracteresEspeciales";
                    registroUsusario = "";
                }
            }
            else
            {
                registroUsusarioError = "IngreseUsuario";
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
                            if (Validaciones.ValidarContraseñas(registroPassword, confirmacionPassword))
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
                    if (cuenta.Password != "" && cuenta.Password != "NA")
                    {
                        InserCuentaChofer inserCuentaChofer = new InserCuentaChofer(Cliente);
                        Response<object> response = new Response<object>();
                        response = await inserCuentaChofer.Insert(cuenta);
                        if (response.Status.Exito == 1)
                        {
                            alerta = "Inserción exitosa";
                            NavigationManager.NavigateTo("/RutasRecolecciones");
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
                    registroUsusarioError = "CampoRequerido";
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

    }
}
