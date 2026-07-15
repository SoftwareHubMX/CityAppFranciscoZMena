using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarDirectorioLogic;
using CityApp.Client.Logic.CardNuevoDirectorioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Migrations;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarDirectorioComponents
{
    public partial class CardEditarDirectorio
    {
        [Parameter] public int idDirectorio { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Directorio Directorio = new Directorio();
        private List<string> Archivos = new List<string>();
        private List<TipoDirectorio> TiposDirectorio = new List<TipoDirectorio>();

        private string nombreDirectorio = "";
        private string puesto = "";
        private string metodoContacto = "";
        private string errorDirectorio = "";
        private string errorPuesto = "";
        private string errorMetodoCon = "";

        private string section1 = "";
        private string section2 = "no_view";

        private string alerta = "";

        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarDirectorio();
                
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

        private async void ConsultarDirectorio()
        {

            Response<Directorio> response = new Response<Directorio>();
            SelectDirectorioLogic selectDirectorioLogic = new SelectDirectorioLogic(Cliente);
            response = await selectDirectorioLogic.Select(idDirectorio);
            if (response.Status.Exito == 1)
            {
                Directorio = response.Data;
                nombreDirectorio = Directorio.NombreDirecctorio;
                puesto = Directorio.Puesto;
                metodoContacto = Directorio.MetodoContacto;
                if (Directorio.ArchivosDirectorio!= null && Directorio.ArchivosDirectorio.Count > 0)
                {
                    for (int i = 0; i < Directorio.ArchivosDirectorio.Count; i++)
                    {
                        Directorio.ArchivosDirectorio[i].Ruta = await DescargarImagenesDirectorios(Directorio.ArchivosDirectorio[i].Ruta);
                        StateHasChanged();
                    }
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void ActualizarDirectorio()
        {
            if (!banderaBoton)
            {
                Response<object> response = new Response<object>();
                UpdateDirectorioLogic updataDirectorioLogic = new UpdateDirectorioLogic(Cliente);
                response = await updataDirectorioLogic.Updata(Sesion.TokenAcceso, Directorio);
                if (response.Status.Exito == 1)
                {
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

        private async Task<string> DescargarImagenesDirectorios(string ruta)
        {
            string archivoDescargado = ruta;
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoDirectorioLogic downloadArchivoDirectorioLogic = new DownloadArchivoDirectorioLogic(Cliente);
            response = await downloadArchivoDirectorioLogic.Dowload(ruta, idDirectorio);
            if (response.Status.Exito == 1)
            {
                archivoDescargado = Convert.ToBase64String(response.Data);
            }
            return archivoDescargado;
        }

        private async void EliminarArchivo(ArchivoDirectorio archivo)
        {
            Response<object> response = new Response<object>();
            DeleteArchivoDirectorioLogic DeleteArchivoDirectorioLogic = new DeleteArchivoDirectorioLogic(Cliente);
            response = await DeleteArchivoDirectorioLogic.Delete(Sesion.TokenAcceso, archivo.IdArchivoDirectorio);
            if (response.Status.Exito == 1)
            {
                Directorio.ArchivosDirectorio.Remove(archivo);
                StateHasChanged();
            }
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
        

        private async Task saveImage(MultipartFormDataContent content)
        {
            Response<string> responseArchivoImagen = new Response<string>();
            InsertArchivoDirectorioLogic insertArchivoDirectorioLogic = new InsertArchivoDirectorioLogic(Cliente);
            responseArchivoImagen = await insertArchivoDirectorioLogic.Insert(content, idDirectorio, Sesion.TokenAcceso);
            if (responseArchivoImagen.Status.Exito == 1)
            {
                Directorio = new Directorio();
                StateHasChanged();
                ConsultarDirectorio();
                StateHasChanged();
            }
        }

        private void Guardar()
        {
            NavigationManager.NavigateTo("/Directorios");
        }

        
    }
}
