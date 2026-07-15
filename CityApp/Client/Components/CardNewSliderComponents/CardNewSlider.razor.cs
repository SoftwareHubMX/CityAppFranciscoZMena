using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using CityApp.Client.Logic.CardNewSliderLogic;

namespace CityApp.Client.Components.CardNewSliderComponents
{
    public partial class CardNewSlider
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Slider Slider = new Slider();
        private List<TipoSlider> TiposSliders = new List<TipoSlider>();
        private List<MultipartFormDataContent> ArchivosFile = new List<MultipartFormDataContent>();
        private List<string> Archivos = new List<string>();

        private int idSlider = 0;

        private int idTipoSlider = 0;
        private string idTipoSliderError = "";

        private string section1 = "";
        private string section2 = "no_view";

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            ConsultarTiposSlider();
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
                Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
                StateHasChanged();
            }
        }

        private async void ConsultarTiposSlider()
        {
            Response<List<TipoSlider>> response = new Response<List<TipoSlider>>();
            SelectTiposSliders selectTiposSliders = new SelectTiposSliders(Cliente);
            response = await selectTiposSliders.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposSliders = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void InsertarSlider()
        {
            Response<int> response = new Response<int>();
            InsertSlider insertSlider = new InsertSlider(Cliente);
            response = await insertSlider.Insert(Sesion.TokenAcceso, Slider);
            if (response.Status.Exito == 1)
            {
                idSlider = response.Data;
                section1 = "no_view";
                section2 = "";
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarImagenesSliders(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoSlider downloadArchivoSlider = new DownloadArchivoSlider(Cliente);
            response = await downloadArchivoSlider.Download(ruta, idSlider);
            if (response.Status.Exito == 1)
            {
                Archivos.Add(Convert.ToBase64String(response.Data));
            }
            StateHasChanged();
        }

        private void TxtIdTipoSlider(ChangeEventArgs args)
        {
            idTipoSlider = int.Parse(args.Value.ToString());
            if (idTipoSlider != 0)
            {
                idTipoSliderError = "";
                Slider.IdTipoSlider = idTipoSlider;
                foreach(var tipo in TiposSliders)
                {
                    if(tipo.IdTipoSlider == idTipoSlider)
                    {
                        Slider.Titulo = tipo.Slider;
                        break;
                    }
                }
            }
            else
            {
                Slider.Titulo = "NA";
                Slider.IdTipoSlider = 0;
                idTipoSliderError = "SeleccioneOpcion";
            }
            StateHasChanged();
        }

        private async Task saveImage(MultipartFormDataContent content)
        {
            if(Archivos.Count < 3)
            {
                Response<string> responseArchivoImagen = new Response<string>();
                InsertArchivoSlider insertArchivoSlider = new InsertArchivoSlider(Cliente);
                responseArchivoImagen = await insertArchivoSlider.Insert(content, idSlider, Sesion.TokenAcceso);
                if (responseArchivoImagen.Status.Exito == 1)
                {
                    DescargarImagenesSliders(responseArchivoImagen.Data);
                }
            }
            else
            {
                alerta = "MaximoArchivos";
            }
            StateHasChanged();
        }

        private void Guardar()
        {
            NavigationManager.NavigateTo("/MultimediaApp");
        }

        private void limpiar()
        {
            Slider = new Slider();
            idTipoSlider = 0;
            StateHasChanged();
        }
    }
}
