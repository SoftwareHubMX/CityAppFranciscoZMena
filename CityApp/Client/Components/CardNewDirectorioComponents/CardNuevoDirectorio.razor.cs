using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevoDirectorioLogic;
using CityApp.Client.Logic.ViewDirectorioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNewDirectorioComponents
{
    public partial class CardNuevoDirectorio
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Directorio Directorio = new Directorio();
        private List<Directorio> Directorios = new List<Directorio>();
        private List<MultipartFormDataContent> ArchivosFile = new List<MultipartFormDataContent>();
        private List<string> Archivos = new List<string>();

        private List<TipoDirectorio> TiposDirectorio = new List<TipoDirectorio>();

        private int idTiposDirectorio = 0;
        private string errorIdTipoDirectorio = "";

        private int idDirectorio = 0;

        private string alerta = "";

        private string section1 = "";
        private string section2 = "no_view";

        private string  nombreDirectorio= "";
        private string  puesto= "";
        private string  metodoContacto= "";
        private string  errorDirectorio= "";
        private string  errorPuesto= "";
        private string  errorMetodoCon= "";

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
                ConsultarTiposDirectorio();
                StateHasChanged();

            }
        }

        private async void ConsultarTiposDirectorio()
        {
            Response<List<TipoDirectorio>> response = new Response<List<TipoDirectorio>>();
            SelectTiposDirectorioLogic selectTiposDirectorioLogic = new SelectTiposDirectorioLogic(Cliente);
            response = await selectTiposDirectorioLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposDirectorio = response.Data;
            }
            StateHasChanged();
        }

        private void TxtIdTipoDirectorio(ChangeEventArgs args)
        {
            idTiposDirectorio = int.Parse(args.Value.ToString());
            if (idTiposDirectorio != 0)
            {
                errorIdTipoDirectorio = "";
                Directorio.IdTipoDirectorio = idTiposDirectorio;
            }
            else
            {
                errorIdTipoDirectorio = "SeleccioneOpcion";
                Directorio.IdTipoDirectorio = 0;
            }

            StateHasChanged();
        }


        private void TxtNombreDirectorio(ChangeEventArgs args)
        {
            nombreDirectorio = args.Value.ToString();
            if (nombreDirectorio != "")
            {
                errorDirectorio = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(nombreDirectorio))
                {
                    errorDirectorio = "";
                    Directorio.NombreDirecctorio = nombreDirectorio;
                }
                else
                {
                    errorDirectorio = "NoCaracteresEspeciales";
                    nombreDirectorio = "";
                }
            }
            StateHasChanged();
        }

        private void TxtPuesto(ChangeEventArgs args)
        {
            puesto = args.Value.ToString();
            if (puesto != "")
            {
                errorPuesto = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(puesto))
                {
                    errorPuesto = "";
                    Directorio.Puesto = puesto;
                }
                else
                {
                    errorPuesto = "NoCaracteresEspeciales";
                    puesto = "";
                }
            }
            StateHasChanged();
        }

        private void TxtMetodoContacto(ChangeEventArgs args)
        {
            metodoContacto = args.Value.ToString();
            if (metodoContacto != "")
            {
                errorMetodoCon = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(metodoContacto))
                {
                    errorMetodoCon = "";
                    Directorio.MetodoContacto = metodoContacto;
                }
                else
                {
                    errorMetodoCon = "NoCaracteresEspeciales";
                    metodoContacto = "";
                }
            }
            StateHasChanged();
        }

        private async void AgregarDirectorio()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();

                Response<int> response = new Response<int>();
                InsertDirectorioLogic insertDirectorioLogic = new InsertDirectorioLogic(Cliente);
                response = await insertDirectorioLogic.Insert(Sesion.TokenAcceso, Directorio);
                if (response.Status.Exito == 1)
                {
                    idDirectorio = response.Data;
                    section1 = "no_view";
                    section2 = "";
                    //NavigationManager.NavigateTo("/Directorios");
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

        private async void DescargarImagenesDirectorios(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoDirectorioCardLogic downloadArchivoDirectorioCardLogic = new DownloadArchivoDirectorioCardLogic(Cliente);
            response = await downloadArchivoDirectorioCardLogic.Download(ruta, idDirectorio);
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
                InserArchivoDirectoriosLogic inserArchivoDirectoriosLogic = new InserArchivoDirectoriosLogic(Cliente);
                responseArchivoImagen = await inserArchivoDirectoriosLogic.Insert(content, idDirectorio, Sesion.TokenAcceso);
                if (responseArchivoImagen.Status.Exito == 1)
                {
                    DescargarImagenesDirectorios(responseArchivoImagen.Data);
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
            if(Archivos.Count > 0)
            {
                NavigationManager.NavigateTo("/Directorios");
            }
            else
            {
                alerta = "Debes cargar una imagen";
            }
            StateHasChanged();
        }
    }
}
