using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaBolsaTrabajoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.TablaHistoricoBolsaTrabajoComponents
{
    public partial class TablaHistoricoBolsaTrabajo
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //[Inject] IDialogService Dialog { get; set; }
        //[CascadingParameter] MudDialogInstance MudDialog { get; set; }
        //void Submit() => MudDialog.Close(DialogResult.Ok(true));
        //void Cancel() => MudDialog.Cancel();

        private Sesion Sesion = new Sesion();
        private List<BolsaTrabajo> BolsaTrabajosInactiva = new List<BolsaTrabajo>();
        private FiltroBolsaTrabajo FiltroBolsaTrabajo = new FiltroBolsaTrabajo();

        private bool banderaLoader = false;

        private string alerta = "";
        private bool estatusBolsa = false;


        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;



        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                
                FiltroBolsaTrabajo.MaximoElementos = 10;
                FiltroBolsaTrabajo.Pagina = 1;
                ConsultarBolsaTrabajoInactivas();
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

        private async void ConsultarBolsaTrabajoInactivas()
        {
            
            banderaLoader = false;
            paginas = new List<int>();
            BolsaTrabajosInactiva = new List<BolsaTrabajo>();
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();
            SelectFiltroBolsaTrabajo selectFiltroBolsaTrabajo = new SelectFiltroBolsaTrabajo(Cliente);
            response = await selectFiltroBolsaTrabajo.SelectAll(Sesion.TokenAcceso, FiltroBolsaTrabajo);
            if (response.Status.Exito == 1)
            {
                foreach (var bolsa in response.Data)
                {
                    if (bolsa.EstatuaBolsa == estatusBolsa)
                    {
                        BolsaTrabajosInactiva.Add(bolsa);
                    }
                }
                //BolsaTrabajosInactiva = response.Data.Where(bolsa => !bolsa.EstatuaBolsa).ToList();
                //BolsaTrabajosInactiva = response.Data;
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }
        private async void CambiarPaginaActual(int page)
        {
            BolsaTrabajosInactiva = new List<BolsaTrabajo>();
            paginaActual = page;
            FiltroBolsaTrabajo.Pagina = paginaActual;
            StateHasChanged();
            ConsultarBolsaTrabajoInactivas();
        }
    }
}
