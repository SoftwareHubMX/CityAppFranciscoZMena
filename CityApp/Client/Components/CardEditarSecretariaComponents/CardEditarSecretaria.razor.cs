using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarSecretariaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarSecretariaComponents
{
    public partial class CardEditarSecretaria
    {
        [Parameter] public int idSecretaria { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Secretaria Secretaria = new Secretaria();
        

        private string secretaria = "";
        private string errorSecretaria = "";
 
        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarSecretaria();
            }
            StateHasChanged();
        }

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

        private async void ConsultarSecretaria()
        {
            Response<Secretaria> response = new Response<Secretaria>();
            SelectSecretariaLogic selectSecretariaLogic = new SelectSecretariaLogic(Cliente);
            response = await selectSecretariaLogic.Select(Sesion.TokenAcceso, idSecretaria);
            if (response.Status.Exito == 1)
            {
                Secretaria = response.Data;
                secretaria = Secretaria.NombreSecretaria;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void TxtSecretaria(ChangeEventArgs args)
        {
            secretaria = args.Value.ToString();
            if (secretaria != "")
            {
                errorSecretaria = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(secretaria))
                {
                    errorSecretaria = "";
                    Secretaria.NombreSecretaria = secretaria;
                }
                else
                {
                    errorSecretaria = "NoCaracteresEspeciales";
                    secretaria = "";
                }
            }
            StateHasChanged();
        }

        private async void ActualizarSecretaria()
        {
            Response<object> response = new Response<object>();
            UpdateSecretariaLogic updateSecretariaLogic = new UpdateSecretariaLogic(Cliente);
            response = await updateSecretariaLogic.Updata(Sesion.TokenAcceso, Secretaria);
            if (response.Status.Exito == 1)
            {
                NavigationManager.NavigateTo("/TramitesServicios/Secretarias");
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        
        
    }
}
