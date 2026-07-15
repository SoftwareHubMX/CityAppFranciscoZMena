using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardResetInicioSesionLogic;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Components.CardResetInicioSesionComponents
{
    public partial class CardResetInicioSesion
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

        private string alerta = "";
        private bool bamderaTokenBasio = false;

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
                modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/CardResetInicioSesionJs/CardResetInicioSesion.js");
                await modulo.InvokeVoidAsync("AnimacionReset");
                StateHasChanged();
            }
            else
            {
                if (!bamderaTokenBasio)
                {
                    if(Token != "")
                    {
                        bamderaTokenBasio = true;
                        Enviar();
                    }
                }
            }
        }

        private async void Enviar()
        {
            alerta = "";
            StateHasChanged();
            Response<object> response = new Response<object>();
            ResetAccesos resetAccesos = new ResetAccesos(Cliente);
            response = await resetAccesos.Reset(Token);
            if (response.Status.Exito == 1)
            {
                NavigationManager.NavigateTo("/Acceso", true);
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
