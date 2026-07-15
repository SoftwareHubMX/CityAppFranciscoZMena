using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarNoticia;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarNoticiaComponents
{
    public partial class CardEditarNoticia
    {
        [Parameter] public int idNoticia { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Noticia Noticia = new Noticia();
        private List<string> Archivos = new List<string>();

        private string titulo = "";
        private string autor = "";
        private string fuente = "";
        private string descripcion = "";
        private DateTime fecha = DateTime.Now;
        private string tituloError = "";
        private string autorError = "";
        private string fuenteError = "";
        private string fechaError = "";
        private string descripcionError = "";
        private string section1 = "";
        private string section2 = "no_view";

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
            {
                ConsultarNoticia();
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

        private async void ConsultarNoticia()
        {
            Response<Noticia> response = new Response<Noticia>();
            SelectNoticia selectNoticia = new SelectNoticia(Cliente);
            response = await selectNoticia.Select(idNoticia);
            if(response.Status.Exito == 1)
            {
                Noticia = response.Data;
                titulo = Noticia.Titulo;
                autor = Noticia.Autor;
                fuente = Noticia.Fuente;
                descripcion = Noticia.Texto;
                fecha = Noticia.FechaPublicacion;
                if(Noticia.ArchivosNoticia != null && Noticia.ArchivosNoticia.Count > 0)
                {
                    foreach(var archivo in Noticia.ArchivosNoticia)
                    {
                        DescargarImagenesNoticias(archivo.Ruta);
                    }
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void ActualizarNoticia()
        {
            Response<object> response = new Response<object>();
            UpdataNoticia updataNoticia = new UpdataNoticia(Cliente);
            response = await updataNoticia.Updata(Sesion.TokenAcceso, Noticia);
            if (response.Status.Exito == 1)
            {
                Guardar();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarImagenesNoticias(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoNoticia downloadArchivoNoticia = new DownloadArchivoNoticia(Cliente);
            response = await downloadArchivoNoticia.Dowload(ruta, idNoticia);
            if (response.Status.Exito == 1)
            {
                Archivos.Add(Convert.ToBase64String(response.Data));
            }
            StateHasChanged();
        }

        private async void EliminarArchivo(int idArchivo)
        {
            Response<object> response = new Response<object>();
            DeleteArchivoNoticia deleteArchivoNoticia = new DeleteArchivoNoticia(Cliente);
            response = await deleteArchivoNoticia.Delete(Sesion.TokenAcceso, idArchivo);
        }

        private void TxtTitulo(ChangeEventArgs args)
        {
            titulo = args.Value.ToString();
            if (titulo != "")
            {
                tituloError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(titulo))
                {
                    tituloError = "";
                    Noticia.Titulo = titulo;
                }
                else
                {
                    tituloError = "NoCaracteresEspeciales";
                    titulo = "";
                }
            }
            StateHasChanged();
        }

        private void TxtAutor(ChangeEventArgs args)
        {
            autor = args.Value.ToString();
            if (autor != "")
            {
                autorError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(autor))
                {
                    autorError = "";
                    Noticia.Autor = autor;
                }
                else
                {
                    autorError = "NoCaracteresEspeciales";
                    autor = "";
                }
            }
            StateHasChanged();
        }

        private void TxtFuente(ChangeEventArgs args)
        {
            fuente = args.Value.ToString();
            if (fuente != "")
            {
                fuenteError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(fuente))
                {
                    fuenteError = "";
                    Noticia.Fuente = fuente;
                }
                else
                {
                    fuenteError = "NoCaracteresEspeciales";
                    fuente = "";
                }
            }
            StateHasChanged();
        }

        private void TxtFecha(ChangeEventArgs args)
        {
            fecha = DateTime.Parse(args.Value.ToString());
            if (fecha.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                fechaError = "";
                Noticia.FechaPublicacion = fecha;
            }
            StateHasChanged();
        }

        private void TxtDescripcion(ChangeEventArgs args)
        {
            descripcion = args.Value.ToString();
            if (descripcion != "")
            {
                descripcionError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(descripcion))
                {
                    descripcionError = "";
                    Noticia.Texto = descripcion;
                }
                else
                {
                    descripcionError = "NoCaracteresEspeciales";
                    descripcion = "";
                }
            }
            StateHasChanged();
        }

        private async Task saveImage(MultipartFormDataContent content)
        {
            Response<string> responseArchivoImagen = new Response<string>();
            InsertArchivoNoticia insertArchivoNoticia = new InsertArchivoNoticia(Cliente);
            responseArchivoImagen = await insertArchivoNoticia.Insert(content, idNoticia, Sesion.TokenAcceso);
            if (responseArchivoImagen.Status.Exito == 1)
            {
                DescargarImagenesNoticias(responseArchivoImagen.Data);
            }
        }

        private void Guardar()
        {
            NavigationManager.NavigateTo("/Noticias");
        }

        private void limpiar()
        {
            Noticia = new Noticia();
            titulo = "";
            autor = "";
            fuente = "";
            descripcion = "";
            fecha = Fecha.GetFechaMx();
            StateHasChanged();
        }
    }
}
