using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNewSecretariaLogic;
using CityApp.Client.Logic.CardNuevaNoticiaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNuevaSecretariaComponents
{
    public partial class CardNuevaSecretaria
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Secretaria Secretaria = new Secretaria();
        private List<Secretaria> Secretarias = new List<Secretaria>();

        private string alerta = "";

        private string nombreDependencia = "";
        private string nombreSecretaria = "";
        private string errorNombreSecretaria = "";
        private string errorNombreDependencia = "";

        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {
            ConsultarSecretarias();
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
                Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
                StateHasChanged();
            }
        }

        private async void ConsultarSecretarias()
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();
            SelectSecretariasLogic selectSecretariasLogic = new SelectSecretariasLogic(Cliente);
            response = await selectSecretariasLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                Secretarias = response.Data;
            }
            StateHasChanged();
        }

        private void TxtNombreSecretaria(ChangeEventArgs args)
        {
            nombreSecretaria = args.Value.ToString();
            if (nombreSecretaria != "")
            {
                errorNombreSecretaria = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(nombreSecretaria))
                {
                    errorNombreSecretaria = "";
                    Secretaria.NombreSecretaria = nombreSecretaria;
                }
                else
                {
                    errorNombreSecretaria = "NoCaracteresEspeciales";
                    nombreSecretaria = "";
                }
            }
            StateHasChanged();
        }

        private async void AgregarSecretaria()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();

                Response<object> response = new Response<object>();
                InsertSecretariaLogic insertSecretariaLogic = new InsertSecretariaLogic(Cliente);
                response = await insertSecretariaLogic.Insert(Sesion.TokenAcceso, Secretaria);
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
            else
            {
                alerta = "Actual mente hay un proceso en ejecución, espere a que termine.";
            }
            StateHasChanged();

        }
  
    }
}
