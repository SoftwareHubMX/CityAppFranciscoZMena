using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.FiltrosReporteCiudadanoComponents
{
    public partial class FiltrosReporteCiudadano
    {
        [Parameter] public List<TipoReporteCiudadano> TiposReportesCiudadanos { get; set; } = new List<TipoReporteCiudadano>();
        [Parameter] public List<EstatusReporteCiudadano> estatusReporteCiudadanos { get; set; } = new List<EstatusReporteCiudadano>();
        [Parameter] public FiltroReportesCiudadanos Filtro { get; set; } = new FiltroReportesCiudadanos();
        [Parameter] public EventCallback<FiltroReportesCiudadanos> ActualizarFiltros { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private int idRol = 0;
        private Sesion Sesion = new Sesion();

        private Validaciones Validaciones = new Validaciones();

        private int idReporte = 0;
        private int idTipoReporteCiudadano = 0;
        private int idEstausReporte = 0;
        private int concurrencia = 0;
        private int minConcurrencia = 0;
        private int maxConcurrencia = 0;
        private string localidad = "";
        private string colonia = "";
        private string codigoPostal = "";
        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string idReporteError = ""; 
        private string idTipoReporteCiudadanoError = "";
        private string idEstausReporteError = "";
        private string concurrenciaError = "";
        private string minConcurrenciaError = "";
        private string maxConcurrenciaError = "";
        private string localidadError = "";
        private string coloniaError = "";
        private string codigoPostalError = "";
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
        private string section4 = "selected";
        private string section5 = "";
        private string carrusel4 = "";
        private string carrusel5 = "no_view";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                idRol = Sesion.IdRol;           
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



        private void SelectIdTipoReporteCiudadano(ChangeEventArgs args)
        {
            idTipoReporteCiudadano = int.Parse(args.Value.ToString());
            if (idTipoReporteCiudadano != 0)
            {
                Filtro.IdTipoReporteCiudadano = idTipoReporteCiudadano;
                idTipoReporteCiudadanoError = "";
            }
            else
            {
                Filtro.IdTipoReporteCiudadano = idTipoReporteCiudadano;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void SelectIdEstausReporte(ChangeEventArgs args)
        {
            idEstausReporte = int.Parse(args.Value.ToString());
            if (idEstausReporte != 0)
            {
                Filtro.IdEstatusReporteCiudadano = idEstausReporte;
                idEstausReporteError = "";
            }
            else
            {
                Filtro.IdEstatusReporteCiudadano = idEstausReporte;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtConcurrencia(ChangeEventArgs args)
        {
            concurrencia = int.Parse(args.Value.ToString());
            if (concurrencia != 0)
            {
                concurrenciaError = "";
                Filtro.NumeroReportes = concurrencia;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }
        private void TxtIdReporte(ChangeEventArgs args)
        {
            idReporte = int.Parse(args.Value.ToString());
            if (idReporte != 0)
            {
                idReporteError = "";
                Filtro.IdReporteCiudadano = idReporte;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtMinConcurrencia(ChangeEventArgs args)
        {
            minConcurrencia = int.Parse(args.Value.ToString());
            if (minConcurrencia != 0)
            {
                minConcurrenciaError = "";
                Filtro.MinimoReportes = minConcurrencia;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }
        private void TxtMaxConcurrencia(ChangeEventArgs args)
        {
            maxConcurrencia = int.Parse(args.Value.ToString());
            if (maxConcurrencia != 0)
            {
                maxConcurrenciaError = "";
                Filtro.MaximoReportes = maxConcurrencia;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtLocalidad(ChangeEventArgs args)
        {
            localidad = args.Value.ToString();
            if (localidad != "")
            {
                localidadError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(localidad))
                {
                    localidadError = "";
                    Filtro.Localidad = localidad;
                }
                else
                {
                    localidadError = "NoCaracteresEspeciales";
                    localidad = "";
                }
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtColonia(ChangeEventArgs args)
        {
            colonia = args.Value.ToString();
            if (colonia != "")
            {
                coloniaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(colonia))
                {
                    coloniaError = "";
                    Filtro.Colonia = colonia;
                }
                else
                {
                    coloniaError = "NoCaracteresEspeciales";
                    colonia = "";
                }
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtCodigoPostal(ChangeEventArgs args)
        {
            codigoPostal = args.Value.ToString();
            if (codigoPostal != "")
            {
                codigoPostalError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(codigoPostal))
                {
                    codigoPostalError = "";
                    Filtro.CodigoPostal = codigoPostal;
                }
                else
                {
                    codigoPostalError = "NoCaracteresEspeciales";
                    codigoPostal = "";
                }
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                Filtro.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                Filtro.FechaFija = fechaFija;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                Filtro.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                Filtro.FechaInicio = fechaInicio;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                Filtro.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                Filtro.FechaFin = fechaFin;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                Filtro.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                Filtro.Year = year;
            }
            ActualizarFiltros.InvokeAsync(Filtro);
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                Filtro.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                Filtro.Mes = month;
            }
            if (year != 0)
            {
                ActualizarFiltros.InvokeAsync(Filtro);
            }
            StateHasChanged();
        }

        private void actualizarFiltro()
        {
            if (Filtro.FiltroFechas >= 3)
            {
                Filtro.FechaFin = Fecha.GetFechaMx();
                Filtro.FechaInicio = Fecha.GetFechaMx();
                Filtro.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (Filtro.FiltroFechas == 2)
            {
                Filtro.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                Filtro.Year = 0;
                Filtro.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                Filtro.FechaFin = Fecha.GetFechaMx();
                Filtro.FechaInicio = Fecha.GetFechaMx();
                Filtro.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                Filtro.Year = 0;
                Filtro.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            idReporte = 0;
            idTipoReporteCiudadano = 0;
            idEstausReporte = 0;
            concurrencia = 0;
            localidad = "";
            colonia = "";
            codigoPostal = "";
            Filtro = new FiltroReportesCiudadanos();
            Filtro.Pagina = 1;
            Filtro.MaximoElementos = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ActualizarFiltros.InvokeAsync(Filtro);
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

        private void CambioSection2(int posicion)
        {
            if (posicion == 0)
            {
                maxConcurrencia = 0;
                minConcurrencia = 0;
                section4 = "selected";
                section5 = "";
                carrusel4 = "";
                carrusel5 = "no_view";
            }
            else if (posicion == 1)
            {
                concurrencia = 0;
                section4 = "";
                section5 = "selected";
                carrusel4 = "no_view";
                carrusel5 = "";
            }
            StateHasChanged();
        }
    }
}
