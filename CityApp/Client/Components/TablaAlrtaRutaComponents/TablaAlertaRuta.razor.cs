using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ModalRutaRecoleccionLogic;
using CityApp.Client.Logic.TablaAlertaRutaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaAlrtaRutaComponents
{
    public partial  class TablaAlertaRuta
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }

        private string archivoIdioma = "";
        private List<AlertaRuta> AlertasRuta = new List<AlertaRuta>();
        private List<StatusAlertaRuta> StatusAlertasRutas = new List<StatusAlertaRuta>();
        private Sesion Sesion = new Sesion();

        private string alerta = "";

        private int idAlertaRuta = 0;
        private int idStatusAlertaRuta = 0;
        private FiltroAlertaRuta FiltroAlertaRuta = new FiltroAlertaRuta();


        private List<int> paginas = new List<int>();
        private int paginaActual = 1;


        private bool banderaLoader = true;
        private bool banderamodal = false;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarStatusAlertasRutas();
                banderaLoader = true;
                StateHasChanged();
                ConsultarAlertaRuta();
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

        private async void ConsultarAlertaRuta()
        {
            paginas = new List<int>();
            AlertasRuta = new List<AlertaRuta>();
            StateHasChanged();
            Response<List<AlertaRuta>> response = new Response<List<AlertaRuta>>();
            SelectAlertasRutaLogic selectAlertas = new SelectAlertasRutaLogic(Cliente);
            response = await selectAlertas.SelectAll(Sesion.TokenAcceso, FiltroAlertaRuta);
            if (response.Status.Exito == 1)
            {
                AlertasRuta = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
                banderaLoader = false;
            }
            banderaLoader = false;
            StateHasChanged();
        }

        private async void ConsultarStatusAlertasRutas()
        {
            Response<List<StatusAlertaRuta>> response = new Response<List<StatusAlertaRuta>>();
            SelectStatusAlertaRutaLogic selectStatusAlertaRutaLogic = new SelectStatusAlertaRutaLogic(Cliente);
            response = await selectStatusAlertaRutaLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                StatusAlertasRutas = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void CambiarStatusAlertaRutaSelect(int idStatus)
        {
            idStatusAlertaRuta = idStatus;
            AlertasRuta = new List<AlertaRuta>();
            StateHasChanged();
            ConsultarAlertaRuta();
            StateHasChanged();
        }

        private async void ActualizacionVistaStatusAlertaRuta(AlertaRuta AlertaRuta)
        {
            for (int i = 0; i < AlertasRuta.Count; i++)
            {
                if (AlertasRuta[i].IdAlertaRuta == AlertaRuta.IdAlertaRuta)
                {
                    AlertasRuta[i] = AlertaRuta;
                }
            }
            List<AlertaRuta> AlertasRutaAux = AlertasRuta;
            AlertasRuta = new List<AlertaRuta>();
            StateHasChanged();
            await Task.Delay(100);
            AlertasRuta = AlertasRutaAux;
            StateHasChanged();
        }
    }
}
