using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEnvioCorreoRestaurarPassLogic;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Components.CardEnvioCorreoRestaurarPassComponents
{
    public partial class CardEnvioCorreoRestaurarPass
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;
        IJSObjectReference lib;

        private Validaciones Validaciones = new Validaciones();

        private string btn_enviar = "Enviar";
        private string alerta = "";

        private string correo = "";
        private string correoError = "";
        private string correoValido = "";

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
                modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/CardEnvioCorreoRestaurarPassJs/CardEnvioCorreoRestaurarPass.js");
                await modulo.InvokeVoidAsync("AnimacionEnvioMail");
                StateHasChanged();
            }
        }

        private void TxtCorreo(ChangeEventArgs args)
        {
            correo = args.Value.ToString();
            if (correo != "")
            {
                correoError = "";
                correoValido = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(correo))
                {
                    if (Validaciones.ValidarCorreo(correo))
                    {
                        correoError = "";
                        correoValido = correo;
                    }
                    else
                    {
                        correoError = "CorreoValido";
                        correoValido = "";
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

        private async void Enviar()
        {
            alerta = "";
            StateHasChanged();
            if (btn_enviar != "carga")
            {
                btn_enviar = "carga";
                StateHasChanged();
                if (correoValido != "")
                {
                    Response<object> response = new Response<object>();
                    SendMail sendMail = new SendMail(Cliente);
                    response = await sendMail.Send(correoValido);
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
