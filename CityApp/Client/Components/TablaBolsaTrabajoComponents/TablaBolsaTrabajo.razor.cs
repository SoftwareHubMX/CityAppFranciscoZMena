using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditBolsaTrabajoLogic;
using CityApp.Client.Logic.TablaBolsaTrabajoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.TablaBolsaTrabajoComponents
{
    public partial class TablaBolsaTrabajo
    {
        [Parameter] public EventCallback<BolsaTrabajo> OnEstadoCambiado { get; set; }

        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        [Inject] IDialogService Dialog { get; set; }

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        private string archivoIdioma = "";

        private Sesion Sesion = new Sesion();
        private List<BolsaTrabajo> BolsaTrabajos = new List<BolsaTrabajo>();
        private FiltroBolsaTrabajo FiltroBolsaTrabajo = new FiltroBolsaTrabajo();

        private bool banderaLoader = false;

        private string alerta = "";

        private bool estatusBolsa = true;
        

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
                ConsultarBolsaTrabajo();
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

        private async void ConsultarBolsaTrabajo()
        {

            banderaLoader = false;
            paginas = new List<int>();
            BolsaTrabajos = new List<BolsaTrabajo>();
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();
            SelectFiltroBolsaTrabajo selectFiltroBolsaTrabajo = new SelectFiltroBolsaTrabajo(Cliente);
            response = await selectFiltroBolsaTrabajo.SelectAll(Sesion.TokenAcceso, FiltroBolsaTrabajo);
            if (response.Status.Exito == 1)
            {
                foreach (var bolsa in response.Data)
                {
                    if (bolsa.EstatuaBolsa == estatusBolsa)
                    {
                        BolsaTrabajos.Add(bolsa);
                    }
                }
                //BolsaTrabajos = response.Data.Where(bolsa => bolsa.EstatuaBolsa).ToList();
                //BolsaTrabajos = response.Data;
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
            BolsaTrabajos = new List<BolsaTrabajo>();
            paginaActual = page;
            FiltroBolsaTrabajo.Pagina = paginaActual;
            StateHasChanged();
            ConsultarBolsaTrabajo();
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
        private void IrNuevaBolsaTrabajos()
        {
            NavigationManager.NavigateTo("/BolsaTrabajos/BolsasTrabajos/Nueva");
        }
        private void IrHistoricoBolsaTrabajos()
        {
            NavigationManager.NavigateTo("/BolsaTrabajos/BolsasTrabajos/Historico");
        }

        private void IrEditarBolsaTrabajos(int idBolsaTrabajo)
        {
            NavigationManager.NavigateTo("/BolsaTrabajos/BolsasTrabajos/Editar/" + idBolsaTrabajo);
        }
        //private void IrDetallesBolsaTrabajos(int idBolsaTrabajo)
        //{
        //    NavigationManager.NavigateTo("/BolsaTrabajos/BolsasTrabajos/Detalle/" + idBolsaTrabajo);
        //}
        DialogOptions closeButton = new DialogOptions() { CloseButton = true };
        private void OpenDialog(DialogOptions options)
        {
            _ = Dialog.Show<TablaBolsaTrabajoComponents.TablaBolsaTrabajo>("Detalle", options);
        }

        

        private async void EliminarBolsaTrabajos(int idBolsaTrabajo)
        {
            Response<object> response = new Response<object>();
            DeleteBolsaTrabajoLogic deleteBolsaTrabajoLogic = new DeleteBolsaTrabajoLogic(Cliente);
            response = await deleteBolsaTrabajoLogic.Delete(Sesion.TokenAcceso, idBolsaTrabajo);
            if (response.Status.Exito == 1)
            {
                ConsultarBolsaTrabajo();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async Task CambiarStatusBolsa(BolsaTrabajo bolsaTrabajo)
        {
            bolsaTrabajo.EstatuaBolsa = !(bolsaTrabajo.EstatuaBolsa);
            Response<object> response = new Response<object>();
            UpdateBolsaTrabajoLogic updateBolsaTrabajoLogic = new UpdateBolsaTrabajoLogic(Cliente);
            response = await updateBolsaTrabajoLogic.Update(Sesion.TokenAcceso, bolsaTrabajo);
            if (response.Status.Exito == 1)
            {
                ConsultarBolsaTrabajo();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

    }
}
