using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaSecretariaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaSecretariaComponents
{
    public partial class TablaSecretaria
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        
        private Sesion Sesion = new Sesion();

        private List<Secretaria> Secretarias = new List<Secretaria>();
        private FiltroSecretaria FiltroSecretaria = new FiltroSecretaria();

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
                FiltroSecretaria.MaximoElementos = 10;
                FiltroSecretaria.Pagina = 1;
                ConsultarSecretarias();
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

        private async void ConsultarSecretarias()
        {

            banderaLoader = false;
            paginas = new List<int>();
            Secretarias = new List<Secretaria>();
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();
            SelectSecretariasFiltro selectSecretariasFiltro = new SelectSecretariasFiltro(Cliente);
            response = await selectSecretariasFiltro.SelectAll(Sesion.TokenAcceso, FiltroSecretaria);
            if (response.Status.Exito == 1)
            {
                Secretarias = response.Data;
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
            Secretarias = new List<Secretaria>();
            paginaActual = page;
            FiltroSecretaria.Pagina = paginaActual;
            StateHasChanged();
            ConsultarSecretarias();
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
        private void IrNuevaSecretaria()
        {
            NavigationManager.NavigateTo("/TramitesServicios/Secretarias/Nueva");
        }

        private void IrEditarSecretaria(int idSecretaria)
        {
            NavigationManager.NavigateTo("/TramitesServicios/Secretarias/Editar/" + idSecretaria);
        }

        private async void EliminarSecretaria(int idSecretaria)
        {
            Response<object> response = new Response<object>();
            DeleteSecretaria deleteSecretaria = new DeleteSecretaria(Cliente);
            response = await deleteSecretaria.Delete(Sesion.TokenAcceso, idSecretaria);
            if (response.Status.Exito == 1)
            {
                ConsultarSecretarias();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
