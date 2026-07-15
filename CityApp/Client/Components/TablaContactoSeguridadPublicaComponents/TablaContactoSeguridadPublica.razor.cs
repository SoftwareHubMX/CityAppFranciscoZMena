using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaContactoSeguridadPublicaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaContactoSeguridadPublicaComponents
{
    public partial class TablaContactoSeguridadPublica
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Sesion Sesion = new Sesion();

        private List<ContactoSeguridadPublica> ContactosSeguridadPublica = new List<ContactoSeguridadPublica>();
        private bool banderaLoader = false;

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarContactoSeguridadPublicas();
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

        private async void ConsultarContactoSeguridadPublicas()
        {
            banderaLoader = false;
            ContactosSeguridadPublica = new List<ContactoSeguridadPublica>();
            StateHasChanged();
            Response<List<ContactoSeguridadPublica>> response = new Response<List<ContactoSeguridadPublica>>();
            SelectContactosSeguridadPublica selectContactosSeguridadPublica = new SelectContactosSeguridadPublica(Cliente);
            response = await selectContactosSeguridadPublica.SelectAll(Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                ContactosSeguridadPublica = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }

        private void IrNuevaContactoSeguridadPublica()
        {
            NavigationManager.NavigateTo("/SeguridadPublica/ContactosSeguridadPublica/Nuevo");
        }

        private void IrEditarContactoSeguridadPublica(int idContactoSeguridadPublica)
        {
            NavigationManager.NavigateTo("/SeguridadPublica/ContactosSeguridadPublica/Editar/" + idContactoSeguridadPublica);
        }

        private async void EliminarContactoSeguridadPublica(int idContactoSeguridadPublica)
        {
            Response<object> response = new Response<object>();
            DeleteContactoSeguridadPublica deleteContactoSeguridadPublica = new DeleteContactoSeguridadPublica(Cliente);
            response = await deleteContactoSeguridadPublica.Delete(Sesion.TokenAcceso, idContactoSeguridadPublica);
            if (response.Status.Exito == 1)
            {
                ConsultarContactoSeguridadPublicas();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
