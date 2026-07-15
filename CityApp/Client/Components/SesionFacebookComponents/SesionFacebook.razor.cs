using Blazored.SessionStorage;
using CityApp.Client.MVComponents.SesionFacebookMVComponents;
using CityApp.Shared.Models.FacebookModels.LoginResponse;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Components.SesionFacebookComponents
{
    public partial class SesionFacebook
    {
        [Parameter] public EventCallback ActualizacionSesionStorage { get; set; }
        [Inject] private ISyncSessionStorageService SessionStorage { get; set; }
        [Inject] IJSRuntime jsRuntime { get; set; }

        private static MVSesionFacebook MVSesionFacebook = new MVSesionFacebook();
        private string tokenFB = "";

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            MVSesionFacebook.metodoAlQueSeSuscrive += EjecucionStaticDinamic;

            await jsRuntime.InvokeVoidAsync("fbAsyncInit");
        }

        private async Task obtencionDatosFB()
        {
            await jsRuntime.InvokeAsync<object>("fbLogin");
        }

        private async void EjecucionStaticDinamic(object sender, string data)
        {
            tokenFB = data;
            GuardadoSesionStorage();
        }

        private async void GuardadoSesionStorage()
        {
            SessionStorage.SetItem<string>("tokenFacebook", tokenFB);
            ActualizacionSesionStorage.InvokeAsync();
        }

        [JSInvokable("FbLoginProcessCallback")]
        public static void FbLoginProcessCallback(LoginResponse loginResponse)
        {
            MVSesionFacebook.ejecutar(loginResponse.authResponse.accessToken);
        }
    }
}
