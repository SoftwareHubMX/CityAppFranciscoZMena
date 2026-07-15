using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaNormatividadLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaNormatividadComponents
{
    public partial class TablaNormatividad
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Sesion Sesion = new Sesion();

        private List<Normatividad> Normatividades = new List<Normatividad>();
        private bool banderaLoader = false;

        private string alerta = "";
        private string archivoSelected = "";
        private bool modal = false;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarNormatividads();
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

        private async void ConsultarNormatividads()
        {
            banderaLoader = false;
            Normatividades = new List<Normatividad>();
            StateHasChanged();
            Response<List<Normatividad>> response = new Response<List<Normatividad>>();
            SelectNormatividades selectNormatividades = new SelectNormatividades(Cliente);
            response = await selectNormatividades.SelectAll(Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                Normatividades = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }

        private void IrNuevaNormatividad()
        {
            NavigationManager.NavigateTo("/SeguridadPublica/Normatividades/Nueva");
        }

        private void IrEditarNormatividad(int idNormatividad)
        {
            NavigationManager.NavigateTo("/SeguridadPublica/Normatividades/Editar/" + idNormatividad);
        }

        private async void EliminarNormatividad(int idNormatividad)
        {
            Response<object> response = new Response<object>();
            DeleteNormatividad deleteNormatividad = new DeleteNormatividad(Cliente);
            response = await deleteNormatividad.Delete(Sesion.TokenAcceso, idNormatividad);
            if (response.Status.Exito == 1)
            {
                ConsultarNormatividads();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void OpenModalFream(string arch)
        {
            archivoSelected = arch;
            OpenCloseModal();
        }

        private void OpenCloseModal()
        {
            if (modal)
            {
                modal = false;
                archivoSelected = "";
            }
            else
            {
                modal = true;
            }
            StateHasChanged();
        }
    }
}
