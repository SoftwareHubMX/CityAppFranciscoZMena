using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardRestaurarPassLogic;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Components.CardRestaurarPassComponents
{
    public partial class CardRestaurarPass
    {
        [Parameter] public string Token { get; set; } = "";
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;
        IJSObjectReference lib;

        private Validaciones Validaciones = new Validaciones();

        private RecuperacionPassword recuperacionPassword = new RecuperacionPassword();

        private string btn_enviar = "Enviar";
        private string alerta = "";

        private string password = "";
        private string passwordError = "";
        private string confirmacionPassword = "";
        private string confirmacionPasswordError = "";
        private string passwordValido = "";

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
                lib = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "https://cdnjs.cloudflare.com/ajax/libs/bodymovin/5.7.13/lottie.min.js");
                modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/CardRestaurarPassJs/CardRestaurarPass.js");
                await modulo.InvokeVoidAsync("AnimacionPassword");
                StateHasChanged();
            }
        }

        private void TxtRegistro(ChangeEventArgs args)
        {
            password = args.Value.ToString();
            if (password != "")
            {
                passwordError = "";
                passwordValido = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(password))
                {
                    if (Validaciones.ValidarContraseña(password))
                    {
                        passwordError = "";
                        if (confirmacionPassword != "")
                        {
                            if (Validaciones.ValidarContraseñas(password, confirmacionPassword))
                            {
                                confirmacionPasswordError = "ConfirmePass";
                                passwordValido = password;
                            }
                            else
                            {
                                confirmacionPasswordError = "PassNoCoinsiden";
                            }
                        }
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
            StateHasChanged();
        }

        private void TxtPasswordConfirmacion(ChangeEventArgs args)
        {
            confirmacionPassword = args.Value.ToString();
            if (confirmacionPassword != "")
            {
                confirmacionPasswordError = "";
                passwordValido = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(confirmacionPassword))
                {
                    if (Validaciones.ValidarContraseñas(password, confirmacionPassword))
                    {
                        confirmacionPasswordError = "";
                        passwordValido = password;
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

        private async void Enviar()
        {
            alerta = "";
            StateHasChanged();
            if (btn_enviar != "carga")
            {
                btn_enviar = "carga";
                StateHasChanged();
                if (passwordValido != "")
                {
                    recuperacionPassword = new RecuperacionPassword()
                    {
                        Token = Token,
                        Password = password,
                        CerrarSesiones = true
                    };
                    Response<object> response = new Response<object>();
                    UpdataPassword updataPassword = new UpdataPassword(Cliente);
                    response = await updataPassword.Updata(recuperacionPassword);
                    if (response.Status.Exito == 1)
                    {
                        NavigationManager.NavigateTo("/Acceso", true);
                    }
                    else
                    {
                        alerta = response.Status.Mensaje;
                    }
                }
            }
            else
            {
                alerta = "ProcesoEjecucion";
            }
            StateHasChanged();
        }
    }
}
