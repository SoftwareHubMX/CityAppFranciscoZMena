using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ViewDirectorioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.ViewDirectoriosComponents
{
    public partial class ViewDirectorios
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }

        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();
        private Sesion Sesion = new Sesion();
        private FiltroDirectorio FiltroDirectorio = new FiltroDirectorio();

        private List<Directorio> Directorios = new List<Directorio >();
        private List<(List<string>, Directorio)> ArchivosDirectorios = new List<(List<string>, Directorio)>();
        private bool banderaLoader = false;

        private string alerta = "";

        private MudCarousel<string> _carousel;
        private bool _arrows = true;
        private bool _bullets = true;
        private bool _enableSwipeGesture = true;
        private bool _autocycle = true;

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroDirectorio.MaximoElementos = 6;
                FiltroDirectorio.Pagina = 1;
                ConsultarDirectorios();
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

        private async void DescargarImagenesDirectorios()
        {
            ArchivosDirectorios = new List<(List<string>, Directorio)>();
            for (int i = 0; i < Directorios.Count; i++)
            {
                List<string> archivos = new List<string>();
                if(Directorios[i].ArchivosDirectorio != null)
                {
                    for (int j = 0; j < Directorios[i].ArchivosDirectorio.Count; j++)
                    {
                        Response<byte[]> response = new Response<byte[]>();
                        DownloadArchivoDirectorioLogic downloadArchivoDirectorioLogic = new DownloadArchivoDirectorioLogic(Cliente);
                        response = await downloadArchivoDirectorioLogic.Download(Directorios[i].ArchivosDirectorio[j].Ruta, Directorios[i].IdDirectorio);
                        if (response.Status.Exito == 1)
                        {
                            Directorios[i].ArchivosDirectorio[j].Ruta = Convert.ToBase64String(response.Data);
                            archivos.Add(Directorios[i].ArchivosDirectorio[j].Ruta);
                        }
                    }
                }
                (List<string>, Directorio) sliderCompleto = new(archivos, Directorios[i]);
                ArchivosDirectorios.Add(sliderCompleto);
            }
            banderaLoader = true;
            StateHasChanged();
        }

        private async void ConsultarDirectorios()
        {
            banderaLoader = false;
            paginas = new List<int>();
            Directorios = new List<Directorio>();
            StateHasChanged();
            Response<List<Directorio>> response = new Response<List<Directorio>>();
            SelectDirectoriosLogic selectDirectoriosLogic = new SelectDirectoriosLogic(Cliente);
            response = await selectDirectoriosLogic.SelectAll(Sesion.TokenAcceso, FiltroDirectorio);
            if (response.Status.Exito == 1)
            {
                Directorios = response.Data;
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
                DescargarImagenesDirectorios();
            }
            else
            {
                banderaLoader = true;
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
        private void IrNuevoDirectorio()
        {
            NavigationManager.NavigateTo("/Directorios/Nuevo");
        }

        private void IrEditarDirectorio(int idDirectorio)
        {
            NavigationManager.NavigateTo("/Directorios/Editar/" + idDirectorio);
        }

        private async void CambiarPaginaActual(int page)
        {
            Directorios = new List<Directorio>();
            paginaActual = page;
            FiltroDirectorio.Pagina = paginaActual;
            StateHasChanged();
            ConsultarDirectorios();
        }

        private async void EliminarDirectorio(int idDirectorio)
        {
            Response<object> response = new Response<object>();
            DeleteDirectorioLogic deleteDirectorioLogic = new DeleteDirectorioLogic(Cliente);
            response = await deleteDirectorioLogic.Delete(Sesion.TokenAcceso, idDirectorio);
            if (response.Status.Exito == 1)
            {
                ConsultarDirectorios();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
