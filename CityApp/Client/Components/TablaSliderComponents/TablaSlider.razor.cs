using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaSliderLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.TablaSliderComponents
{
    public partial class TablaSlider
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();
        private Sesion Sesion = new Sesion();

        private List<Slider> Sliders = new List<Slider>();
        private List<(List<string>, Slider)> ArchivosSliders = new List<(List<string>, Slider)>();
        private bool banderaLoader = false;

        private MudCarousel<string> _carousel;
        private bool _arrows = true;
        private bool _bullets = true;
        private bool _enableSwipeGesture = true;
        private bool _autocycle = true;

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarSliders();
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

        private async void DescargarImagenesSliders()
        {
            ArchivosSliders = new List<(List<string>, Slider)>();
            for (int i = 0; i < Sliders.Count; i++)
            {
                List<string> archivos = new List<string>();
                if (Sliders[i].ArchivosSlider != null)
                {
                    for (int j = 0; j < Sliders[i].ArchivosSlider.Count; j++)
                    {
                        Response<byte[]> response = new Response<byte[]>();
                        DownloadArchivoSlider downloadArchivoSlider = new DownloadArchivoSlider(Cliente);
                        response = await downloadArchivoSlider.Download(Sliders[i].ArchivosSlider[j].Ruta, Sliders[i].IdSlider);
                        if (response.Status.Exito == 1)
                        {
                            Sliders[i].ArchivosSlider[j].Ruta = Convert.ToBase64String(response.Data);
                            archivos.Add(Sliders[i].ArchivosSlider[j].Ruta);
                        }
                    }
                }

                (List<string>, Slider) sliderCompleto = new(archivos, Sliders[i]);
                ArchivosSliders.Add(sliderCompleto);
            }
            StateHasChanged();
        }

        private async void ConsultarSliders()
        {
            banderaLoader = false;
            Sliders = new List<Slider>();
            StateHasChanged();
            Response<List<Slider>> response = new Response<List<Slider>>();
            SelectSliders selectSliders = new SelectSliders(Cliente);
            response = await selectSliders.SelectAll();
            if (response.Status.Exito == 1)
            {
                Sliders = response.Data;
                DescargarImagenesSliders();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }

        private void IrNuevaSlider()
        {
            NavigationManager.NavigateTo("/MultimediaApp/Nueva");
        }

        private void IrEditarSlider(int idSlider)
        {
            NavigationManager.NavigateTo("/MultimediaApp/Editar/" + idSlider);
        }

        private async void EliminarSlider(int idSlider)
        {
            Response<object> response = new Response<object>();
            DeleteSlider deleteSlider = new DeleteSlider(Cliente);
            response = await deleteSlider.Delete(Sesion.TokenAcceso, idSlider);
            if (response.Status.Exito == 1)
            {
                ConsultarSliders();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
