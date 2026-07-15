using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaDescuentosPrediosLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaDescuentosPrediosComponents
{
    public partial class TablaDescuentosPredios
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private List<DescuentoPredio> DescuentoPredios = new List<DescuentoPredio>();
        private FiltroDescuentoPredios FiltroDescuentoPredios = new FiltroDescuentoPredios();

        private string tituloDescuento = "";
        private bool porsentajeMonto = false;
        private double monto = 0;
        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string tituloDescuentoError = "";
        private string porsentajeMontoError = "";
        private string montoError = "";
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
                FiltroDescuentoPredios.Pagina = 1;
                FiltroDescuentoPredios.MaximoElementos = 10;
                banderaLoader = true;
                StateHasChanged();
                ConsultarDescuentoPredios();
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

        private void TxtTituloDescuento(ChangeEventArgs args)
        {
            tituloDescuento = args.Value.ToString();
            if (tituloDescuento != "")
            {
                tituloDescuentoError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(tituloDescuento))
                {
                    tituloDescuentoError = "";
                    FiltroDescuentoPredios.Titulo = tituloDescuento;
                    ConsultarDescuentoPredios();
                    StateHasChanged();
                }
                else
                {
                    tituloDescuentoError = "";
                    tituloDescuento = "";
                    FiltroDescuentoPredios.Titulo = "NA";
                    StateHasChanged();
                }
            }
        }

        private void CambiarPorcentajeMonto()
        {
            if (porsentajeMonto)
            {
                porsentajeMonto = false;
                FiltroDescuentoPredios.PorsentajeMonto = porsentajeMonto;
            }
            else
            {
                porsentajeMonto = true;
                FiltroDescuentoPredios.PorsentajeMonto = porsentajeMonto;
            }
            montoError = "CampoRequerido";
            StateHasChanged();
        }

        private void TxtMonto(ChangeEventArgs args)
        {
            monto = double.Parse(args.Value.ToString());
            if (monto != 0)
            {
                montoError = "";
                FiltroDescuentoPredios.Descuento = monto;
            }
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroDescuentoPredios.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                FiltroDescuentoPredios.FechaFija = fechaFija;
            }
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroDescuentoPredios.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                FiltroDescuentoPredios.FechaInicio = fechaInicio;
            }
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroDescuentoPredios.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                FiltroDescuentoPredios.FechaFin = fechaFin;
            }
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                FiltroDescuentoPredios.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                FiltroDescuentoPredios.Year = year;
            }
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                FiltroDescuentoPredios.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                FiltroDescuentoPredios.Mes = month;
            }
            if (year != 0)
            {
                ConsultarDescuentoPredios();
            }
            StateHasChanged();
        }

        private async void ConsultarDescuentoPredios()
        {
            paginas = new List<int>();
            DescuentoPredios = new List<DescuentoPredio>();
            banderaLoader = true;
            StateHasChanged();
            Response<List<DescuentoPredio>> response = new Response<List<DescuentoPredio>>();
            SelectDescuentoPredios selectDescuentoPredios = new SelectDescuentoPredios(Cliente);
            response = await selectDescuentoPredios.SelectAll(Sesion.TokenAcceso, FiltroDescuentoPredios);
            if (response.Status.Exito == 1)
            {
                DescuentoPredios = response.Data;
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
            DescuentoPredios = new List<DescuentoPredio>();
            paginaActual = page;
            FiltroDescuentoPredios.Pagina = paginaActual;
            StateHasChanged();
            ConsultarDescuentoPredios();
        }

        private void actualizarFiltro()
        {
            if (FiltroDescuentoPredios.FiltroFechas >= 3)
            {
                FiltroDescuentoPredios.FechaFin = Fecha.GetFechaMx();
                FiltroDescuentoPredios.FechaInicio = Fecha.GetFechaMx();
                FiltroDescuentoPredios.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (FiltroDescuentoPredios.FiltroFechas == 2)
            {
                FiltroDescuentoPredios.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                FiltroDescuentoPredios.Year = 0;
                FiltroDescuentoPredios.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                FiltroDescuentoPredios.FechaFin = Fecha.GetFechaMx();
                FiltroDescuentoPredios.FechaInicio = Fecha.GetFechaMx();
                FiltroDescuentoPredios.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                FiltroDescuentoPredios.Year = 0;
                FiltroDescuentoPredios.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            DescuentoPredios = new List<DescuentoPredio>();
            FiltroDescuentoPredios = new FiltroDescuentoPredios();
            FiltroDescuentoPredios.Pagina = 1;
            FiltroDescuentoPredios.MaximoElementos = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroDescuentoPredios.Orden == 1)
                {
                    FiltroDescuentoPredios.Orden = 2;
                }
                else
                {
                    FiltroDescuentoPredios.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroDescuentoPredios.Orden == 3)
                {
                    FiltroDescuentoPredios.Orden = 4;
                }
                else
                {
                    FiltroDescuentoPredios.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroDescuentoPredios.Orden == 5)
                {
                    FiltroDescuentoPredios.Orden = 6;
                }
                else
                {
                    FiltroDescuentoPredios.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroDescuentoPredios.Orden == 7)
                {
                    FiltroDescuentoPredios.Orden = 8;
                }
                else
                {
                    FiltroDescuentoPredios.Orden = 7;
                }
            }
            else if (sectionOrden == 5)
            {
                if (FiltroDescuentoPredios.Orden == 9)
                {
                    FiltroDescuentoPredios.Orden = 10;
                }
                else
                {
                    FiltroDescuentoPredios.Orden = 9;
                }
            }
            else if (sectionOrden == 6)
            {
                if (FiltroDescuentoPredios.Orden == 11)
                {
                    FiltroDescuentoPredios.Orden = 12;
                }
                else
                {
                    FiltroDescuentoPredios.Orden = 11;
                }
            }
            ConsultarDescuentoPredios();
            StateHasChanged();
        }

        private void IrNuevaDescuentoPredio()
        {
            NavigationManager.NavigateTo("/Predios/Descuentos/Nuevo");
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

        private async void EliminarDescuentoPredio(int idDescuentoPredio)
        {
            Response<object> response = new Response<object>();
            DeleteDescuentoPredio deleteDescuentoPredio = new DeleteDescuentoPredio(Cliente);
            response = await deleteDescuentoPredio.Delete(Sesion.TokenAcceso, idDescuentoPredio);
            if (response.Status.Exito == 1)
            {
                ConsultarDescuentoPredios();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
