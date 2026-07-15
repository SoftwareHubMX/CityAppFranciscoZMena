using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevaNoticiaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CityApp.Client.Components.CardNuevaNoticiaComponents
{
    public partial class CardNuevaNoticia
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Noticia Noticia = new Noticia();
        private List<MultipartFormDataContent> ArchivosFile = new List<MultipartFormDataContent>();
        private List<string> Archivos = new List<string>();

        private int idNoticia = 0;

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

        private async void InsertarNoticia()
        {
            Response<int> response = new Response<int>();
            InsertNoticia insertNoticia = new InsertNoticia(Cliente);
            response = await insertNoticia.Insert(Sesion.TokenAcceso, Noticia);
            if (response.Status.Exito == 1)
            {
                idNoticia = response.Data;
                section1 = "no_view";
                section2 = "";
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
            if(response.Status.Exito == 1)
            {
                Archivos.Add(Convert.ToBase64String(response.Data));
            }
            StateHasChanged();
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
            if(Archivos.Count > 0)
            {
                NavigationManager.NavigateTo("/Noticias");
            }
            else
            {
               alerta = "Debes cargar una imagen";
            }
            StateHasChanged();
           
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
