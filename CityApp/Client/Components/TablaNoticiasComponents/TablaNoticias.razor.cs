using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using CityApp.Client.Logic.CardNuevaNoticiaLogic;
using CityApp.Client.Logic.TablaNoticiasLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaNoticiasComponents
{
    public partial class TablaNoticias
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] private ISyncSessionStorageService SessionStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private List<Noticia> Noticias = new List<Noticia>();
        private FiltroNoticias FiltroNoticias = new FiltroNoticias();

        private string busqueda = "";
        private string autor = "";
        private string fuente = "";
        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string busquedaError = "";
        private string autorError = "";
        private string fuenteError = "";
        private string fechaFijaError = "";
        private string fechaInicioError = "";
        private string fechaFinError = "";
        private string yearError = "";
        private string monthError = "";
        private string tokenFB = "";
        private string facebookAlerta = "";

        private string alerta = "";

        //Diseño
        private bool banderaLoader = false;
        private bool banderaFacebook = true;

        private string section1 = "selected";
        private string section2 = "";
        private string section3 = "";
        private string carrusel1 = "";
        private string carrusel2 = "no_view";
        private string carrusel3 = "no_view";
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
            {
                //tokenFB = SessionStorage.GetItemAsString("tokenFacebook");
                //if(tokenFB != null && tokenFB != "")
                //{
                //    banderaFacebook = true;
                //}
                FiltroNoticias.Pagina = 1;
                FiltroNoticias.MaximoNoticias = 5;
                banderaLoader = true;
                StateHasChanged();
                ConsultarNoticias();
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


        private async void DescargarImagenesNoticias()
        {
            if(Noticias != null)
            {
                for (int i = 0; i < Noticias.Count; i++)
                {
                    if(Noticias[i].ArchivosNoticia != null)
                    {
                        for (int j = 0; j < Noticias[i].ArchivosNoticia.Count; j++)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DownloadArchivoNoticia downloadArchivoNoticia = new DownloadArchivoNoticia(Cliente);
                            response = await downloadArchivoNoticia.Dowload(Noticias[i].ArchivosNoticia[j].Ruta, Noticias[i].IdNoticia);
                            if (response.Status.Exito == 1)
                            {
                                Noticias[i].ArchivosNoticia[j].Ruta = Convert.ToBase64String(response.Data);
                            }
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private void TxtBusqueda(ChangeEventArgs args)
        {
            busqueda = args.Value.ToString();
            if (busqueda != "")
            {
                busquedaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(busqueda))
                {
                    busquedaError = "";
                    FiltroNoticias.Busqueda = busqueda;
                }
                else
                {
                    busquedaError = "NoCaracteresEspeciales";
                    busqueda = "";
                }
            }
            ConsultarNoticias();
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
                    FiltroNoticias.Autor = autor;
                }
                else
                {
                    autorError = "NoCaracteresEspeciales";
                    autor = "";
                }
            }
            ConsultarNoticias();
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
                    FiltroNoticias.Fuente = fuente;
                }
                else
                {
                    fuenteError = "NoCaracteresEspeciales";
                    fuente = "";
                }
            }
            ConsultarNoticias();
            StateHasChanged();
        }

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroNoticias.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                FiltroNoticias.FechaFija = fechaFija;
            }
            ConsultarNoticias();
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroNoticias.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                FiltroNoticias.FechaInicio = fechaInicio;
            }
            ConsultarNoticias();
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroNoticias.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                FiltroNoticias.FechaFin = fechaFin;
            }
            ConsultarNoticias();
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                FiltroNoticias.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                FiltroNoticias.Year = year;
            }
            ConsultarNoticias();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                FiltroNoticias.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                FiltroNoticias.Mes = month;
            }
            if(year != 0)
            {
                ConsultarNoticias();
            }
            StateHasChanged();
        }
        private async void ConsultarNoticias()
        {
            paginas = new List<int>();
            Response<List<Noticia>> response = new Response<List<Noticia>>();
            SelectNoticias selectNoticias = new SelectNoticias(Cliente);
            response = await selectNoticias.SelectAll(FiltroNoticias);
            if (response.Status.Exito == 1)
            {

                banderaLoader = false;
                StateHasChanged();
                Noticias = response.Data;
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
                DescargarImagenesNoticias();
            }
            else
            {

                banderaLoader = false;
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void CambiarPaginaActual(int page)
        {
            Noticias = new List<Noticia>();
            paginaActual = page;
            FiltroNoticias.Pagina = paginaActual;
            StateHasChanged();
            ConsultarNoticias();
        }

        private void actualizarFiltro()
        {
            if(FiltroNoticias.FiltroFechas >= 3)
            {
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                FiltroNoticias.FechaInicio = Fecha.GetFechaMx();
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if(FiltroNoticias.FiltroFechas == 2)
            {
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                FiltroNoticias.Year = 0;
                FiltroNoticias.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                FiltroNoticias.FechaInicio = Fecha.GetFechaMx();
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                FiltroNoticias.Year = 0;
                FiltroNoticias.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            busqueda = "";
            autor = "";
            fuente = "";
            Noticias = new List<Noticia>();
            FiltroNoticias = new FiltroNoticias();
            FiltroNoticias.Pagina = 1;
            FiltroNoticias.MaximoNoticias = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ConsultarNoticias();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroNoticias.Orden == 1)
                {
                    FiltroNoticias.Orden = 2;
                }
                else
                {
                    FiltroNoticias.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroNoticias.Orden == 3)
                {
                    FiltroNoticias.Orden = 4;
                }
                else
                {
                    FiltroNoticias.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroNoticias.Orden == 5)
                {
                    FiltroNoticias.Orden = 6;
                }
                else
                {
                    FiltroNoticias.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroNoticias.Orden == 7)
                {
                    FiltroNoticias.Orden = 8;
                }
                else
                {
                    FiltroNoticias.Orden = 7;
                }
            }
            else if (sectionOrden == 5)
            {
                if (FiltroNoticias.Orden == 9)
                {
                    FiltroNoticias.Orden = 10;
                }
                else
                {
                    FiltroNoticias.Orden = 9;
                }
            }
            else if (sectionOrden == 6)
            {
                if (FiltroNoticias.Orden == 11)
                {
                    FiltroNoticias.Orden = 12;
                }
                else
                {
                    FiltroNoticias.Orden = 11;
                }
            }
            ConsultarNoticias();
            StateHasChanged();
        }

        private void IrNuevaNoticia()
        {
            NavigationManager.NavigateTo("/Noticias/Nueva");
        }

        private void CambioSection(int posicion)
        {
            if (posicion == 0)
            {
                section1 = "selected";
                section2 = "";
                section3 = "";
                carrusel1 = "";
                carrusel2 = "no_view";
                carrusel3 = "no_view";
            }
            else if (posicion == 1)
            {
                section1 = "";
                section2 = "selected";
                section3 = "";
                carrusel1 = "no_view";
                carrusel2 = "";
                carrusel3 = "no_view";
            }
            else if(posicion == 2)
            {
                section1 = "";
                section2 = "";
                section3 = "selected";
                carrusel1 = "no_view";
                carrusel2 = "no_view";
                carrusel3 = "";
            }
            StateHasChanged();
        }

        private async void EliminarNoticia(int idNoticia)
        {
            Response<object> response = new Response<object>();
            DeleteNoticia deleteNoticia = new DeleteNoticia(Cliente);
            response = await deleteNoticia.Delete(Sesion.TokenAcceso, idNoticia);
            if (response.Status.Exito == 1)
            {
                ConsultarNoticias();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void reconsultarSesionStorage()
        {
            tokenFB = SessionStorage.GetItemAsString("tokenFacebook");
            if (tokenFB != null && tokenFB != "")
            {
                banderaFacebook = true;
            }
            StateHasChanged();
        }

        private async void publicarNoticia(int idNoticia)
        {
            for (int i = 0; i < Noticias.Count; i++)
            {
                if(idNoticia == Noticias[i].IdNoticia)
                {
                    if(Noticias[i].EnlaceFacebook != "NA" && Noticias[i].EnlaceFacebook != "" && Noticias[i].EnlaceFacebook != null)
                    {
                        NavigationManager.NavigateTo(Noticias[i].EnlaceFacebook);
                    }
                    else
                    {
                        PublicarNoticiaFacebook publicarNoticiaFacebook = new PublicarNoticiaFacebook(Cliente);
                        Response<string> response = new Response<string>();
                        response = await publicarNoticiaFacebook.Publicar(Sesion.TokenAcceso, tokenFB, idNoticia);
                        if (response.Status.Exito == 1)
                        {
                            facebookAlerta = "Publicación realizada con éxito";
                            Noticias[i].EnlaceFacebook = response.Data;
                            StateHasChanged();
                            await Task.Delay(3000);
                        }
                        else
                        {
                            facebookAlerta = response.Status.Mensaje;
                            StateHasChanged();
                            await Task.Delay(3000);
                        }
                        facebookAlerta = "";
                    }
                }
            }
            StateHasChanged();
        }

        private void irNoticia(int idNoticia)
        {
            NavigationManager.NavigateTo("/Publico/Noticias/Noticia/" + idNoticia);
        }

        private void irEditarNoticia(int idNoticia)
        {
            NavigationManager.NavigateTo("/Noticias/Editar/" + idNoticia);
        }
    }
}
