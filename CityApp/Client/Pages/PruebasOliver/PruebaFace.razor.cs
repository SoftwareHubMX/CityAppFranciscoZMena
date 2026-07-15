using CityApp.Shared.Models.FacebookModels;
using CityApp.Shared.Models.FacebookModels.LoginResponse;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Pages.PruebasOliver
{
    public partial class PruebaFace
    {
        [Inject] IJSRuntime jsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            await jsRuntime.InvokeVoidAsync("fbAsyncInit");

        }

        public async Task FbLoginProcess()
        {
            await jsRuntime.InvokeAsync<object>("fbLogin");
        }

        static string token = "";

        //[JSInvokable("FbLoginProcessCallback")]
        //public static void FbLoginProcessCallback(LoginResponse loginResponse)
        //{
        //    token = loginResponse.authResponse.accessToken;
        //}

        private async Task prueba()
        {
            //Peticion<string> peticion = new Peticion<string>();
            //string url = "Cuenta/prueba";
            //peticion.Data = token;
            //var responsePeticion = await HttpClient.PostAsJsonAsync<Peticion<string>>(url, peticion);
            //if (responsePeticion.IsSuccessStatusCode)
            //{
            //    Response<PerfilFacebook> response = responsePeticion.Content.ReadFromJsonAsync<Response<PerfilFacebook>>().Result;
            //    if (response.Status.Exito == 1)
            //    {
            //        token = response.Data.name;
            //    }

            //}
        }
    }
}
