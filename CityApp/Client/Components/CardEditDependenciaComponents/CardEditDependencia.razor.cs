using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditDependenciaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditDependenciaComponents
{
    public partial  class CardEditDependencia
    {
        [Parameter] public int idDependencia { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Dependencia Dependencia = new Dependencia();

        private string dependencia = "";
        private string errorDependencia = "";
       

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarDependencia();
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

        private async void ConsultarDependencia()
        {
            Response<Dependencia> response = new Response<Dependencia>();
            SelectDependenciaLogic selectDependenciaLogic = new SelectDependenciaLogic(Cliente);
            response = await selectDependenciaLogic.Select(Sesion.TokenAcceso, idDependencia);
            if (response.Status.Exito == 1)
            {
                Dependencia = response.Data;
                dependencia = Dependencia.NombreDependencia;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
        private void TxtDependenia(ChangeEventArgs args)
        {
            dependencia = args.Value.ToString();
            if (dependencia != "")
            {
                errorDependencia = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(dependencia))
                {
                    errorDependencia = "";
                    Dependencia.NombreDependencia = dependencia;
                }
                else
                {
                    errorDependencia = "NoCaracteresEspeciales";
                    dependencia = "";
                }
            }
            StateHasChanged();
        }

        private async void ActualizarDependencia()
        {
            Response<object> response = new Response<object>();
            UpdateDependenciaLogic updateDependenciaLogic = new UpdateDependenciaLogic(Cliente);
            response = await updateDependenciaLogic.Updata(Sesion.TokenAcceso, Dependencia);
            if (response.Status.Exito == 1)
            {
                NavigationManager.NavigateTo("/TramitesServicios/Dependencias");
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
