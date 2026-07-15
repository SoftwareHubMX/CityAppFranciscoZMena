using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNewAnuncioLogic;
using CityApp.Client.Logic.CardNuevoDirectorioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNuevoAnuncioComponents
{
    public partial class CardNuevoAnuncio
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Anuncio Anuncio = new Anuncio();
        private List<Anuncio> Anuncios = new List<Anuncio>();
        private List<MultipartFormDataContent> ArchivosFile = new List<MultipartFormDataContent>();
        private List<string> Archivos = new List<string>();

       

        private int idAnuncio = 0;

        private string alerta = "";

        private string section1 = "";
        private string section2 = "no_view";

        private string titulo = "";
        private DateTime fecha = DateTime.Now;
        private string errorTitulo = "";
        private string errorFecha = "";

        private bool banderaBoton = false;

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
        private void TxtTitulo(ChangeEventArgs args)
        {
            titulo = args.Value.ToString();
            if (titulo != "")
            {
                errorTitulo = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(titulo))
                {
                    errorTitulo = "";
                    Anuncio.Titulo = titulo;
                }
                else
                {
                    errorTitulo = "NoCaracteresEspeciales";
                    titulo = "";
                }
            }
            StateHasChanged();
        }
        private void TxtFecha(ChangeEventArgs args)
        {
            fecha = DateTime.Parse(args.Value.ToString());
            if (fecha.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                errorFecha = "";
                Anuncio.FechaPublicacion = fecha;
            }
            StateHasChanged();
        }

        private async void AgregarAnuncio()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();

                Response<int> response = new Response<int>();
                InsertAnuncioLogic insertAnuncioLogic = new InsertAnuncioLogic(Cliente);
                response = await insertAnuncioLogic.Insert(Sesion.TokenAcceso, Anuncio);
                if (response.Status.Exito == 1)
                {
                    idAnuncio = response.Data;
                    section1 = "no_view";
                    section2 = "";
                }
                else
                {
                    alerta = response.Status.Mensaje;
                }
                StateHasChanged();
            }
            else
            {
                alerta = "Actual mente hay un proceso en ejecución, espere a que termine.";
            }
            StateHasChanged();
        }

        private async void DescargarImagenesAnuncios(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoAnuncioCardLogic downloadArchivoAnuncioCardLogic = new DownloadArchivoAnuncioCardLogic(Cliente);
            response = await downloadArchivoAnuncioCardLogic.Download(ruta, idAnuncio);
            if (response.Status.Exito == 1)
            {
                Archivos.Add(Convert.ToBase64String(response.Data));
            }
            StateHasChanged();
        }

        private async Task saveImage(MultipartFormDataContent content)
        {
            if (Archivos.Count < 3)
            {
                Response<string> responseArchivoImagen = new Response<string>();
                InsertArchivoAnuncioLogic insertArchivoAnuncioLogic = new InsertArchivoAnuncioLogic(Cliente);
                responseArchivoImagen = await insertArchivoAnuncioLogic.Insert(content, idAnuncio, Sesion.TokenAcceso);
                if (responseArchivoImagen.Status.Exito == 1)
                {
                    DescargarImagenesAnuncios(responseArchivoImagen.Data);
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
            if (Archivos.Count > 0)
            {
                NavigationManager.NavigateTo("/Anuncios");
            }
            else
            {
                alerta = "Debes cargar una imagen";
            }
            StateHasChanged();
        }
    }
}
