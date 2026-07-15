using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNewDescuentoPredioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNewDescuentoPredioComponents
{
    public partial class CardNewDescuentoPredio
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private DescuentoPredio DescuentoPredio = new DescuentoPredio();

        //private string busqueda = "";
        private string tituloDescuento = "";
        private DateTime fechaInicio = Fecha.GetFechaMx();
        private DateTime fechaFin = Fecha.GetFechaMx();
        private int yearResago = 0;
        private bool porsentajeMonto = false;
        private double descuento = 0;
        private string tituloDescuentoError = "";
        private string fechaInicioError = "";
        private string fechaFinError = "";
        private string yearResagoError = "";
        private string porsentajeMontoError = "";
        private string descuentoError = "";

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

        private async void InsertarContacto()
        {
            Response<object> response = new Response<object>();
            InsertDescuentoPredio insertDescuentoPredio = new InsertDescuentoPredio(Cliente);
            response = await insertDescuentoPredio.Insert(Sesion.TokenAcceso, DescuentoPredio);
            if (response.Status.Exito == 1)
            {
                NavigationManager.NavigateTo("/Predios/Descuentos");
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
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
                    DescuentoPredio.TituloDescuento = tituloDescuento;
                }
                else
                {
                    tituloDescuentoError = "NoCaracteresEspeciales";
                    tituloDescuento = "";
                    DescuentoPredio.TituloDescuento = "NA";
                }
            }

            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                fechaInicioError = "";
                DescuentoPredio.FechaInicio = fechaInicio;
            }
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                fechaFinError = "";
                DescuentoPredio.FechaFin = fechaFin;
            }
            StateHasChanged();
        }

        private void TxtYearResago(ChangeEventArgs args)
        {
            yearResago = int.Parse(args.Value.ToString());
            if (yearResago != 0)
            {
                yearResagoError = "";
                DescuentoPredio.YearResago = yearResago;
            }

            StateHasChanged();
        }

        private void CambiarPorcentajeMonto()
        {
            if (porsentajeMonto)
            {
                porsentajeMonto = false;
                DescuentoPredio.PorsentajeMonto = porsentajeMonto;
            }
            else
            {
                porsentajeMonto = true;
                DescuentoPredio.PorsentajeMonto = porsentajeMonto;
            }
            StateHasChanged();
        }

        private void TxtDescuento(ChangeEventArgs args)
        {
            descuento = int.Parse(args.Value.ToString());
            if (descuento != 0)
            {
                descuentoError = "";
                DescuentoPredio.Descuento = descuento;
            }
            else
            {
                descuentoError = "SeleccioneOpcion";
                DescuentoPredio.Descuento = 0;
            }

            StateHasChanged();
        }
    }
}
