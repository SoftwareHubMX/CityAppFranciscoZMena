using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaAnuncioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaAnuncioComponents
{
    public partial class TablaAnuncio
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

       
        private Sesion Sesion = new Sesion();
        private FiltroAnuncio FiltroAnuncio = new FiltroAnuncio();

        private List<Anuncio> Anuncios = new List<Anuncio>();
        //private List<(List<string>, Directorio)> ArchivosDirectorios = new List<(List<string>, Directorio)>();
        private bool banderaLoader = false;

        private string alerta = "";

        //private MudCarousel<string> _carousel;
        //private bool _arrows = true;
        //private bool _bullets = true;
        //private bool _enableSwipeGesture = true;
        //private bool _autocycle = true;

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroAnuncio.MaximoElementos = 6;
                FiltroAnuncio.Pagina = 1;
                ConsultarAnuncios();
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

        private async Task DescargarImagenesAnuncio()
        {
            if (Anuncios != null)
            {
                for (int i = 0; i < Anuncios.Count; i++)
                {
                    if (Anuncios[i].ArchivosAnuncio != null)
                    {
                        for (int j = 0; j < Anuncios[i].ArchivosAnuncio.Count; j++)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DownloadArchivoAnuncioLogic downloadArchivoAnuncioLogic = new DownloadArchivoAnuncioLogic(Cliente);
                            response = await downloadArchivoAnuncioLogic.Download(Anuncios[i].ArchivosAnuncio[j].Ruta, Anuncios[i].IdAnuncio);
                            if (response.Status.Exito == 1)
                            {
                                Anuncios[i].ArchivosAnuncio[j].Ruta = Convert.ToBase64String(response.Data);
                            }
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private async void ConsultarAnuncios()
        {
            banderaLoader = false;
            Anuncios = new List<Anuncio>();
            StateHasChanged();
            paginas = new List<int>();
            Response<List<Anuncio>> response = new Response<List<Anuncio>>();
            SelectAnunciosLogic selectAnunciosLogic = new SelectAnunciosLogic(Cliente);
            response = await selectAnunciosLogic.SelectAll(Sesion.TokenAcceso, FiltroAnuncio);
            if (response.Status.Exito == 1)
            {
                Anuncios = response.Data;
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
            await DescargarImagenesAnuncio();
            banderaLoader = true;
            StateHasChanged();
        }
        private void IrNuevoAnuncio()
        {
            NavigationManager.NavigateTo("/Anuncios/Nuevo");
        }

        private void IrEditarAnuncio(int idAnuncio)
        {
            NavigationManager.NavigateTo("/Anuncios/Editar/" + idAnuncio);
        }

        private async void CambiarPaginaActual(int page)
        {
            Anuncios = new List<Anuncio>();
            paginaActual = page;
            FiltroAnuncio.Pagina = paginaActual;
            StateHasChanged();
            ConsultarAnuncios();
        }

        private async void EliminarAnuncio(int idAnuncio)
        {
            Response<object> response = new Response<object>();
            DeleteAnuncioLogic deleteDirectorioLogic = new DeleteAnuncioLogic(Cliente);
            response = await deleteDirectorioLogic.Delete(Sesion.TokenAcceso, idAnuncio);
            if (response.Status.Exito == 1)
            {
                ConsultarAnuncios();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
