using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaPagosLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaPagosComponents
{
    public partial class TablaPagos
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();
        private Sesion Sesion = new Sesion();

        private List<Pago> Pagos = new List<Pago>();
        private List<TipoPago> TiposPagos = new List<TipoPago>();
        private FiltroPagos FiltroPagos = new FiltroPagos();

        private bool banderaLoader = false;

        private string referencia = "";
        private int tipoPago = 0;
        private int idCuenta = 0;
        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string referenciaError = "";
        private string tipoPagoError = "";
        private string idCuentaError = "";
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

        private bool modalOpen = false;
        private int idPagoModal = 0;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroPagos.Pagina = 1;
                FiltroPagos.MaximoNoticias = 20;
                StateHasChanged();
                ConsultarTiposPagos();
                ConsultarPagos();
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

        private async void ConsultarTiposPagos()
        {
            Response<List<TipoPago>> response = new Response<List<TipoPago>>();
            SelectTiposPagos selectTiposPagos = new SelectTiposPagos(Cliente);
            response = await selectTiposPagos.SelectAll();
            if(response.Status.Exito == 1)
            {
                TiposPagos = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void TxtReferencia(ChangeEventArgs args)
        {
            referencia = args.Value.ToString();
            if (referencia != "")
            {
                referenciaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(referencia))
                {
                    referenciaError = "";
                    FiltroPagos.Referencia = referencia;
                }
                else
                {
                    referenciaError = "NoCaracteresEspeciales";
                    referencia = "";
                    FiltroPagos.Referencia = "NA";
                }
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void TxtTipoPago(ChangeEventArgs args)
        {
            tipoPago = int.Parse(args.Value.ToString());
            if (tipoPago != 0)
            {
                tipoPagoError = "";
                FiltroPagos.TipoPago = tipoPago;
            }
            else
            {
                FiltroPagos.TipoPago = tipoPago;
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void TxtIdCuenta(ChangeEventArgs args)
        {
            idCuenta = int.Parse(args.Value.ToString());
            if (idCuenta != 0)
            {
                idCuentaError = "";
                FiltroPagos.IdCuenta = idCuenta;
            }
            else
            {
                FiltroPagos.IdCuenta = idCuenta;
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroPagos.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                FiltroPagos.FechaFija = fechaFija;
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroPagos.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                FiltroPagos.FechaInicio = fechaInicio;
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroPagos.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                FiltroPagos.FechaFin = fechaFin;
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                FiltroPagos.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                FiltroPagos.Year = year;
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                FiltroPagos.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                FiltroPagos.Mes = month;
            }
            if (year != 0)
            {
                ConsultarPagos();
            }
            StateHasChanged();
        }
        private async void ConsultarPagos()
        {
            banderaLoader = false;
            Pagos = new List<Pago>();
            StateHasChanged();
            paginas = new List<int>();
            Response<List<Pago>> response = new Response<List<Pago>>();
            SelectPagos selectPagos = new SelectPagos(Cliente);
            response = await selectPagos.SelectAll(Sesion.TokenAcceso, FiltroPagos);
            if (response.Status.Exito == 1)
            {
                Pagos = response.Data;
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
            banderaLoader = true;
            StateHasChanged();
        }

        private async void CambiarPaginaActual(int page)
        {
            Pagos = new List<Pago>();
            paginaActual = page;
            FiltroPagos.Pagina = paginaActual;
            StateHasChanged();
            ConsultarPagos();
        }

        private void actualizarFiltro()
        {
            if (FiltroPagos.FiltroFechas >= 3)
            {
                FiltroPagos.FechaFin = Fecha.GetFechaMx();
                FiltroPagos.FechaInicio = Fecha.GetFechaMx();
                FiltroPagos.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (FiltroPagos.FiltroFechas == 2)
            {
                FiltroPagos.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                FiltroPagos.Year = 0;
                FiltroPagos.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                FiltroPagos.FechaFin = Fecha.GetFechaMx();
                FiltroPagos.FechaInicio = Fecha.GetFechaMx();
                FiltroPagos.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                FiltroPagos.Year = 0;
                FiltroPagos.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            referencia = "";
            tipoPago = 0;
            idCuenta = 0;
            Pagos = new List<Pago>();
            FiltroPagos = new FiltroPagos();
            FiltroPagos.Pagina = 1;
            FiltroPagos.MaximoNoticias = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ConsultarPagos();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroPagos.Orden == 1)
                {
                    FiltroPagos.Orden = 2;
                }
                else
                {
                    FiltroPagos.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroPagos.Orden == 3)
                {
                    FiltroPagos.Orden = 4;
                }
                else
                {
                    FiltroPagos.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroPagos.Orden == 5)
                {
                    FiltroPagos.Orden = 6;
                }
                else
                {
                    FiltroPagos.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroPagos.Orden == 7)
                {
                    FiltroPagos.Orden = 8;
                }
                else
                {
                    FiltroPagos.Orden = 7;
                }
            }
            else if (sectionOrden == 5)
            {
                if (FiltroPagos.Orden == 9)
                {
                    FiltroPagos.Orden = 10;
                }
                else
                {
                    FiltroPagos.Orden = 9;
                }
            }
            else if (sectionOrden == 6)
            {
                if (FiltroPagos.Orden == 11)
                {
                    FiltroPagos.Orden = 12;
                }
                else
                {
                    FiltroPagos.Orden = 11;
                }
            }
            ConsultarPagos();
            StateHasChanged();
        }

        private void IrNuevaPago()
        {
            NavigationManager.NavigateTo("/Pagos/Nuevo");
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

        private void OpenCloseModal(int tipo)
        {
            if (modalOpen)
            {
                if(tipo == 0)
                {
                    modalOpen = false;
                    idPagoModal = 0;
                }
                else if(tipo == 1)
                {
                    modalOpen = false;
                    idPagoModal = 0;
                    ConsultarPagos();
                }
            }
            else
            {
                modalOpen = true;
                idPagoModal = tipo;
            }
            StateHasChanged();
        }

        private async void Eliminar(int idPago)
        {
            Response<object> response = new Response<object>();
            DeletePago deletePago = new DeletePago(Cliente);
            response = await deletePago.Delete(Sesion.TokenAcceso, idPago);
            if (response.Status.Exito == 1)
            {
                ConsultarPagos();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
