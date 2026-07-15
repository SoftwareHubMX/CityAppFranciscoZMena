using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaCitasLogic;
using CityApp.Client.Logic.TablaPostulacionLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaCitasComponents
{
    public partial class TablaCitas
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Sesion Sesion = new Sesion();

        private List<Cita> Citas = new List<Cita>();
        private FiltroCitas FiltroCitas = new FiltroCitas();

        private bool banderaLoader = false;

        private string alerta = "";

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;



        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroCitas.MaximoElementos = 10;
                FiltroCitas.Pagina = 1;
                ConsultarCitas();
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

        private async void ConsultarCitas()
        {
            FiltroCitas.IdTipoCita = 7;
            banderaLoader = false;
            paginas = new List<int>();
            Citas = new List<Cita>();
            Response<List<Cita>> response = new Response<List<Cita>>();
            SelectFiltroCitasLogic selectFiltroCitasLogic = new SelectFiltroCitasLogic(Cliente);
            response = await selectFiltroCitasLogic.SelectAll(Sesion.TokenAcceso, FiltroCitas);
            if (response.Status.Exito == 1)
            {
                Citas = response.Data;
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
            Citas = new List<Cita>();
            paginaActual = page;
            FiltroCitas.Pagina = paginaActual;
            StateHasChanged();
            ConsultarCitas();
        }

        //private void limpiarFiltro()
        //{
        //    nombreSecretaria = "";

        //    Secretarias = new List<Secretaria>();
        //    FiltroSecretaria = new FiltroSecretaria();
        //    FiltroSecretaria.Pagina = 1;
        //    FiltroSecretaria.MaximoElementos = 20;
        //    ConsultarSecretarias();
        //    StateHasChanged();
        //}
    }
}
