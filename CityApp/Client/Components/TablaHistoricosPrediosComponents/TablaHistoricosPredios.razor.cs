using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaHistoricosPrediosLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaHistoricosPrediosComponents
{
    public partial class TablaHistoricosPredios
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private List<HistoricoPredio> HistoricoPredios = new List<HistoricoPredio>();
        private FiltroHistoricoPredio FiltroHistoricoPredios = new FiltroHistoricoPredio();

        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string fechaFijaError = "";
        private string fechaInicioError = "";
        private string fechaFinError = "";
        private string yearError = "";
        private string monthError = "";

        private string alerta = "";

        //Diseño
        private bool banderaLoader = false;

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
            if (Sesion != null)
            {
                FiltroHistoricoPredios.Pagina = 1;
                FiltroHistoricoPredios.MaximoElementos = 10;
                banderaLoader = true;
                StateHasChanged();
                ConsultarHistoricoPredios();
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

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroHistoricoPredios.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                FiltroHistoricoPredios.FechaFija = fechaFija;
            }
            ConsultarHistoricoPredios();
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroHistoricoPredios.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                FiltroHistoricoPredios.FechaInicio = fechaInicio;
            }
            ConsultarHistoricoPredios();
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroHistoricoPredios.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                FiltroHistoricoPredios.FechaFin = fechaFin;
            }
            ConsultarHistoricoPredios();
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                FiltroHistoricoPredios.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                FiltroHistoricoPredios.Year = year;
            }
            ConsultarHistoricoPredios();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                FiltroHistoricoPredios.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                FiltroHistoricoPredios.Mes = month;
            }
            if (year != 0)
            {
                ConsultarHistoricoPredios();
            }
            StateHasChanged();
        }

        private async void ConsultarHistoricoPredios()
        {
            paginas = new List<int>();
            HistoricoPredios = new List<HistoricoPredio>();
            banderaLoader = true;
            StateHasChanged();
            Response<List<HistoricoPredio>> response = new Response<List<HistoricoPredio>>();
            SelectHistoricoPredios selectHistoricoPredios = new SelectHistoricoPredios(Cliente);
            response = await selectHistoricoPredios.SelectAll(Sesion.TokenAcceso, FiltroHistoricoPredios);
            if (response.Status.Exito == 1)
            {
                HistoricoPredios = response.Data;
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
            banderaLoader = false;
            StateHasChanged();
        }

        private async void CambiarPaginaActual(int page)
        {
            HistoricoPredios = new List<HistoricoPredio>();
            paginaActual = page;
            FiltroHistoricoPredios.Pagina = paginaActual;
            StateHasChanged();
            ConsultarHistoricoPredios();
        }

        private void actualizarFiltro()
        {
            if (FiltroHistoricoPredios.FiltroFechas >= 3)
            {
                FiltroHistoricoPredios.FechaFin = Fecha.GetFechaMx();
                FiltroHistoricoPredios.FechaInicio = Fecha.GetFechaMx();
                FiltroHistoricoPredios.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (FiltroHistoricoPredios.FiltroFechas == 2)
            {
                FiltroHistoricoPredios.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                FiltroHistoricoPredios.Year = 0;
                FiltroHistoricoPredios.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                FiltroHistoricoPredios.FechaFin = Fecha.GetFechaMx();
                FiltroHistoricoPredios.FechaInicio = Fecha.GetFechaMx();
                FiltroHistoricoPredios.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                FiltroHistoricoPredios.Year = 0;
                FiltroHistoricoPredios.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            HistoricoPredios = new List<HistoricoPredio>();
            FiltroHistoricoPredios = new FiltroHistoricoPredio();
            FiltroHistoricoPredios.Pagina = 1;
            FiltroHistoricoPredios.MaximoElementos = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ConsultarHistoricoPredios();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroHistoricoPredios.Orden == 1)
                {
                    FiltroHistoricoPredios.Orden = 2;
                }
                else
                {
                    FiltroHistoricoPredios.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroHistoricoPredios.Orden == 3)
                {
                    FiltroHistoricoPredios.Orden = 4;
                }
                else
                {
                    FiltroHistoricoPredios.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroHistoricoPredios.Orden == 5)
                {
                    FiltroHistoricoPredios.Orden = 6;
                }
                else
                {
                    FiltroHistoricoPredios.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroHistoricoPredios.Orden == 7)
                {
                    FiltroHistoricoPredios.Orden = 8;
                }
                else
                {
                    FiltroHistoricoPredios.Orden = 7;
                }
            }
            ConsultarHistoricoPredios();
            StateHasChanged();
        }

        private void IrNuevaHistoricoPredio()
        {
            NavigationManager.NavigateTo("/Eventos/Nuevo");
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

        //private async void EliminarHistoricoPredio(int idHistoricoPredio)
        //{
        //    Response<object> response = new Response<object>();
        //    DeleteHistoricoPredio deleteHistoricoPredio = new DeleteHistoricoPredio(Cliente);
        //    response = await deleteHistoricoPredio.Delete(Sesion.TokenAcceso, idHistoricoPredio);
        //    if (response.Status.Exito == 1)
        //    {
        //        ConsultarHistoricoPredios();
        //    }
        //    else
        //    {
        //        alerta = response.Status.Mensaje;
        //    }
        //    StateHasChanged();
        //}

        //private void irHistoricoPredio(int idHistoricoPredio)
        //{
        //    NavigationManager.NavigateTo("/Publico/Eventos/Evento/" + idHistoricoPredio);
        //}

        //private void irEditarHistoricoPredio(int idHistoricoPredio)
        //{
        //    NavigationManager.NavigateTo("/Eventos/Editar/" + idHistoricoPredio);
        //}
    }
}
