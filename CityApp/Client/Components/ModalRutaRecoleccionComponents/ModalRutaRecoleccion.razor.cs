using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ModalRutaRecoleccionLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalRutaRecoleccionComponents
{
    public partial class ModalRutaRecoleccion
    {
        [Parameter] public int idRutaRecoleccion { get; set; } = 0;
        [Parameter] public Sesion Sesion { get; set; } = new Sesion();
        [Parameter] public EventCallback OpenCloseModalAlertaRuta { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private List<AlertaRuta> AlertaRutas = new List<AlertaRuta>();
        private FiltroAlertaRuta FiltroAlertaRuta = new FiltroAlertaRuta();

        private List<TipoAlertaRuta> TiposAlertaRuta = new List<TipoAlertaRuta>();
        private List<StatusAlertaRuta> StatusAlertasRuta = new List<StatusAlertaRuta>();

        private RutaRecoleccion RutaRecoleccion = null;


        private int idTipoAlertaRuta = 0;
        private int idStatusAlertaRuta = 0;
        private string errorIdTipoAlertaRuta = "";
        private string errorIdStatusAlertaRuta = "";

        private string alerta = "";
        private bool banderaCargaInfo = false;
        private bool banderaLoader = false;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {

                FiltroAlertaRuta.MaximoElementos = 10;
                FiltroAlertaRuta.Pagina = 1;
                ConsultarRutaRecoleccion();
                ConsultarTiposAlertaRuta();
                ConsultarStatusAlertasRuta();
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
        private async void ConsultarRutaRecoleccion()
        {
            SelectRutaRecoleccion selectRutaRecoleccion = new SelectRutaRecoleccion(Cliente);
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();
            response = await selectRutaRecoleccion.Select(Sesion.TokenAcceso, idRutaRecoleccion);
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

        private async void ConsultarTiposAlertaRuta()
        {
            Response<List<TipoAlertaRuta>> response = new Response<List<TipoAlertaRuta>>();
            SelectTiposAlertaRutaLogic selectTiposAlertaRutaLogic = new SelectTiposAlertaRutaLogic(Cliente);
            response = await selectTiposAlertaRutaLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposAlertaRuta = response.Data;
            }
            StateHasChanged();
        }

        private async void ConsultarStatusAlertasRuta()
        {
            StatusAlertasRuta = new List<StatusAlertaRuta>();
            Response<List<StatusAlertaRuta>> response = new Response<List<StatusAlertaRuta>>();
            SelectStatusAlertaRutaLogic selectStatusAlertaRutaLogic = new SelectStatusAlertaRutaLogic(Cliente);
            response = await selectStatusAlertaRutaLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                StatusAlertasRuta = response.Data;
            }
            StateHasChanged();
        }

        private void SelectIdTipoAlertaRuta(ChangeEventArgs args)
        {
            idTipoAlertaRuta = int.Parse(args.Value.ToString());
            if (idTipoAlertaRuta > 0)
            {
                FiltroAlertaRuta.IdTipoAlertaRuta = idTipoAlertaRuta;
                errorIdTipoAlertaRuta = "";
            }
            else
            {
                FiltroAlertaRuta.IdTipoAlertaRuta = 0;
                errorIdTipoAlertaRuta = "campoRequerido";
            }
            ConsultarRutaRecoleccion();
            StateHasChanged();
        }

        private void SelectIdStatusAlertaRuta(ChangeEventArgs args)
        {
            idStatusAlertaRuta = int.Parse(args.Value.ToString());
            if (idStatusAlertaRuta > 0)
            {
                FiltroAlertaRuta.IdStatusAlertaRuta = idStatusAlertaRuta;
                errorIdStatusAlertaRuta = "";
            }
            else
            {
                FiltroAlertaRuta.IdStatusAlertaRuta = 0;
                errorIdStatusAlertaRuta = "campoRequerido";
            }
            ConsultarRutaRecoleccion();
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            idTipoAlertaRuta = 0;
            idStatusAlertaRuta = 0;
            AlertaRutas = new List<AlertaRuta>();
            FiltroAlertaRuta = new FiltroAlertaRuta();
            FiltroAlertaRuta.Pagina = 1;
            FiltroAlertaRuta.MaximoElementos = 10;
            ConsultarRutaRecoleccion();
            StateHasChanged();
        }
    }
}
