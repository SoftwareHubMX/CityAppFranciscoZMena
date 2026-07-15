using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Shared.PageNoFound
{
    public partial class PageNoFound
    {
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;
        IJSObjectReference lib;

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
                modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/PageNoFoundJs/PageNoFound.js");
                await modulo.InvokeVoidAsync("AnimacionOops");
                StateHasChanged();
            }
        }
    }
}
