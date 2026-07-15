using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardContactoMunicipioLogic;
using CityApp.Client.Logic.TablaContactoSeguridadPublicaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardContactoMunicipioComponents
{
    public partial class CardContactoMunicipio
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Sesion Sesion = new Sesion();

        private ContactoMunicipio ContactoMunicipio = new ContactoMunicipio();
        private bool banderaLoader = false;

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarContactoMunicipio();
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

        private async void ConsultarContactoMunicipio()
        {
            banderaLoader = false;
            ContactoMunicipio = new ContactoMunicipio();
            StateHasChanged();
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();
            SelectContactoMunicipio selectContactoMunicipio = new SelectContactoMunicipio(Cliente);
            response = await selectContactoMunicipio.SelectAll();
            if (response.Status.Exito == 1)
            {
                ContactoMunicipio = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }

        private void IrNuevoContacto()
        {
            NavigationManager.NavigateTo("/ContactoMunicipio/Nuevo");
        }

        private void IrEditarContactoMunicipio(int idContactoSeguridadPublica)
        {
            NavigationManager.NavigateTo("/ContactoMunicipio/Editar/" + idContactoSeguridadPublica);
        }

        //private async void EliminarContactoSeguridadPublica(int idContactoSeguridadPublica)
        //{
        //    Response<object> response = new Response<object>();
        //    DeleteContactoSeguridadPublica deleteContactoSeguridadPublica = new DeleteContactoSeguridadPublica(Cliente);
        //    response = await deleteContactoSeguridadPublica.Delete(Sesion.TokenAcceso, idContactoSeguridadPublica);
        //    if (response.Status.Exito == 1)
        //    {
        //        ConsultarContactoSeguridadPublicas();
        //    }
        //    else
        //    {
        //        alerta = response.Status.Mensaje;
        //    }
        //    StateHasChanged();
        //}
    }
}
