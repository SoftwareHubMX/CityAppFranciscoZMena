using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaAlertaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaAlertaComponents
{
    public partial class TablaAlerta
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        private List<Alerta> Alertas = new List<Alerta>();
        private List<EstatusAlerta> EstatusAlertas = new List<EstatusAlerta>();
        private Sesion Sesion = new Sesion();

        private string alerta = "";

        private int idAlerta = 0;
        private int idEstatusAlerta = 0;


        private List<int> paginas = new List<int>();
        private int paginaActual = 1;


        private bool banderaLoader = true;
        private bool banderamodal = false;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarEstatusAlertas();
                banderaLoader = true;
                StateHasChanged();
                ConsultarAlerta();
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

        private async void ConsultarAlerta()
        {
            paginas = new List<int>();
            Alertas = new List<Alerta>();
            StateHasChanged();
            Response<List<Alerta>> response = new Response<List<Alerta>>();
            SelectAlertas selectAlertas = new SelectAlertas(Cliente);
            response = await selectAlertas.SelectAll(Sesion.TokenAcceso, idEstatusAlerta);
            if (response.Status.Exito == 1)
            {
                Alertas = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
                banderaLoader = false;
            }
            banderaLoader = false;
            StateHasChanged();
        }

        private async void ConsultarEstatusAlertas()
        {
            Response<List<EstatusAlerta>> response = new Response<List<EstatusAlerta>>();
            SelectEstausAlertas selectEstausAlertas = new SelectEstausAlertas(Cliente);
            response = await selectEstausAlertas.SelectAll();
            if (response.Status.Exito == 1)
            {
                EstatusAlertas = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void CambiarEstatusSelect(int idestatus)
        {
            idEstatusAlerta = idestatus;
            Alertas = new List<Alerta>();
            StateHasChanged();
            ConsultarAlerta();
            StateHasChanged();
        }

        private async void ActualizacionVistaEstatus(Alerta Alerta)
        {
            for (int i = 0; i < Alertas.Count; i++)
            {
                if (Alertas[i].IdAlerta == Alerta.IdAlerta)
                {
                    Alertas[i] = Alerta;
                }
            }
            List<Alerta> AlertasAux = Alertas;
            Alertas = new List<Alerta>();
            StateHasChanged();
            await Task.Delay(100);
            Alertas = AlertasAux;
            StateHasChanged();
        }
    }
}
