using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaDependenciaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaDependenciaComponents
{
    public partial class TablaDependencia
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Sesion Sesion = new Sesion();

        private List<Dependencia> Dependencias = new List<Dependencia>();
        private FiltroDependencia FiltroDependencia = new FiltroDependencia();

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
                FiltroDependencia.IdSecretaria = 0;
                FiltroDependencia.MaximoElementos = 10;
                FiltroDependencia.Pagina = 1;
                ConsultarDependencias();
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

        private async void ConsultarDependencias()
        {
            banderaLoader = false;
            paginas = new List<int>();
            Dependencias = new List<Dependencia>();
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();
            SelectDependenciasFiltro selectDependencias = new SelectDependenciasFiltro(Cliente);
            response = await selectDependencias.SelectAll(Sesion.TokenAcceso, FiltroDependencia);
            if (response.Status.Exito == 1)
            {
                Dependencias = response.Data;
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

        private void IrNuevaDependencia()
        {
            NavigationManager.NavigateTo("/TramitesServicios/Dependencias/Nueva");
        }

        private void IrEditarDependencia(int idDependencia)
        {
            NavigationManager.NavigateTo("/TramitesServicios/Dependencias/Editar/" + idDependencia);
        }

        private async void CambiarPaginaActual(int page)
        {
            Dependencias = new List<Dependencia>();
            paginaActual = page;
            FiltroDependencia.Pagina = paginaActual;
            StateHasChanged();
            ConsultarDependencias();
        }

        private async void EliminarDependencia(int idDependencia)
        {
            Response<object> response = new Response<object>();
            DeleteDependencia deleteDependencia = new DeleteDependencia(Cliente);
            response = await deleteDependencia.Delete(Sesion.TokenAcceso, idDependencia);
            if (response.Status.Exito == 1)
            {
                ConsultarDependencias();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
