using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaCitasLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaCitasVeterinariaComponents
{
    public partial class TablaCitaVeterinaria
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Sesion Sesion = new Sesion();

        private List<TipoCita> TiposCita = new List<TipoCita>();
        private List<Cita> Citas = new List<Cita>();
        private FiltroCitas FiltroCitas = new FiltroCitas();

        private bool banderaLoader = false;

        private string alerta = "";

        private int idTipoCita = 0;
        private string idTipoCitaError = "";

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
                ConsultarTiposCita();
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
        private async void ConsultarTiposCita()
        {
            Response<List<TipoCita>> response = new Response<List<TipoCita>>();
            SelectTipoCitasLogic selectTipoCitasLogic = new SelectTipoCitasLogic(Cliente);
            response = await selectTipoCitasLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposCita = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void ConsultarCitas()
        {
            //FiltroCitas.IdTipoCita = 7;
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

        private void TxtIdTipoCita(ChangeEventArgs args)
        {
            idTipoCita = int.Parse(args.Value.ToString());
            if (idTipoCita != 0)
            {
                idTipoCitaError = "";
                FiltroCitas.IdTipoCita = idTipoCita;
            }
            else
            {
                FiltroCitas.IdTipoCita = idTipoCita;
            }
            ConsultarCitas();
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            idTipoCita = 0;

            Citas = new List<Cita>();
            FiltroCitas = new FiltroCitas();
            FiltroCitas.Pagina = 1;
            FiltroCitas.MaximoElementos = 20;
            ConsultarCitas();
            StateHasChanged();
        }
    }
}
