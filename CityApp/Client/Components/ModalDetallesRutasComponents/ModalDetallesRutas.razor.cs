using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ModalDetallesColoniasRutaLogic;
using CityApp.Client.Logic.ModalRutaRecoleccionLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalDetallesRutasComponents
{
    public partial class ModalDetallesRutas
    {
        [Parameter] public int idRutaRecoleccion { get; set; } = 0;
        [Parameter] public Sesion Sesion { get; set; } = new Sesion();
        [Parameter] public EventCallback OpenCloseModal2 { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private RutaRecoleccion RutaRecoleccion = null;

        private string alerta = "";
        private bool banderaCargaInfo = false;
        

        protected override async Task OnInitializedAsync()
        {
            ConsultarRutaColonias();
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

        private async void ConsultarRutaColonias()
        {
            SelectColoniasRutaRecoleccionLogic selectColoniasRutaRecoleccionLogic = new SelectColoniasRutaRecoleccionLogic(Cliente);
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();
            response = await selectColoniasRutaRecoleccionLogic.SelectAll(Sesion.TokenAcceso, idRutaRecoleccion);
            if (response.Status.Exito == 1)
            {
                RutaRecoleccion = new RutaRecoleccion();
                RutaRecoleccion = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaCargaInfo = true;
            StateHasChanged();
        }
    }
}
