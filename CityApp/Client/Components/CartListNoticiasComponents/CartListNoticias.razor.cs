using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CartListNoticiasLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CartListNoticiasComponents
{
    public partial class CartListNoticias
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

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

        private string alerta = "";

        //Diseño
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
            FiltroNoticias.Pagina = 1;
            FiltroNoticias.MaximoNoticias = 20;
            ConsultarNoticias();
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
            if (Noticias != null)
            {
                for (int i = 0; i < Noticias.Count; i++)
                {
                    if (Noticias[i].ArchivosNoticia != null)
                    {
                        Response<byte[]> response = new Response<byte[]>();
                        DownloadArchivoNoticia downloadArchivoNoticia = new DownloadArchivoNoticia(Cliente);
                        response = await downloadArchivoNoticia.Dowload(Noticias[i].ArchivosNoticia[0].Ruta, Noticias[i].IdNoticia);
                        if (response.Status.Exito == 1)
                        {
                            Noticias[i].ArchivosNoticia[0].Ruta = Convert.ToBase64String(response.Data);
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
            if (year != 0)
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
            if (FiltroNoticias.FiltroFechas >= 3)
            {
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                FiltroNoticias.FechaInicio = Fecha.GetFechaMx();
                FiltroNoticias.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (FiltroNoticias.FiltroFechas == 2)
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
            else if (posicion == 2)
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

        private void irNoticia(int idNoticia)
        {
            NavigationManager.NavigateTo("/Publico/Noticias/Noticia/" + idNoticia);
        }
    }
}
