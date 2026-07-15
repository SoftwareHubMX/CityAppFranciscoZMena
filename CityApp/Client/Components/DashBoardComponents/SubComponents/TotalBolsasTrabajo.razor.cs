using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.DashBoardLogic;
using CityApp.Client.Logic.TablaBolsaTrabajoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;

using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.DashBoardComponents.SubComponents
{
    public partial class TotalBolsasTrabajo
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Sesion Sesion = new Sesion();
        private FiltroTotalBolsasTrabajo filtroTotalBolsasTrabajo = new FiltroTotalBolsasTrabajo();
        public List<ChartSeries> Series = new List<ChartSeries>();

        private int Index = -1; //default value cannot be 0 -> first selectedindex is 0.
        private double[] data = { 4000, 2000, 3100, 2000 };
        public string[] XAxisLabels = {};

        private string totalBolsasTrabajo = "";

        private int year = Fecha.GetFechaMx().Year;
        private int mes = Fecha.GetFechaMx().Month;
        private string yearError = "";
        private string mesError = "";

        //Diseño
        private string section1 = "selected";
        private string section2 = "";
        private string section3 = "";
        private string carrusel1 = "";
        private string carrusel2 = "no_view";
        private string carrusel3 = "no_view";

        private bool banderaLoader = false;
        private bool estatusBolsa = true;
        private string alerta = "";
       

        

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                filtroTotalBolsasTrabajo.FiltroFechas = 4;
                filtroTotalBolsasTrabajo.Year = DateTime.UtcNow.AddHours(-6).Year;
                filtroTotalBolsasTrabajo.Mes = DateTime.UtcNow.AddHours(-6).Month;
                await ConsultarDataSet();
            }
            StateHasChanged();
        }
      
        private async Task ConsultarDataSet()
        {
            Response<List<DataSet>> response = new Response<List<DataSet>>();
            SelectTotalBolsasTrabajo selectTotalBolsasTrabajo = new SelectTotalBolsasTrabajo(Cliente);
            response = await selectTotalBolsasTrabajo.Select(filtroTotalBolsasTrabajo, Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                //List<double> listAux1 = new List<double>();
                //List<double> listAux2 = new List<double>();
                //List<string> dias = new List<string>();

                //for (int i = 0; i < response.Data[0].Items.Count; i++)
                //{

                //    listAux1.Add(response.Data[0].Items[i].Cantidad);
                //    listAux2.Add(response.Data[1].Items[i].Cantidad);
                //    dias.Add((i + 1).ToString());
                //}

                Series = new List<ChartSeries>()
                {
                    new ChartSeries() { Name = response.Data[0].Titulo + ": " + response.Data[0].CantidadTitulo, Data = response.Data[0].Items.Select(item => item.Cantidad).ToArray() },
                    new ChartSeries() { Name = response.Data[1].Titulo + ": " + response.Data[1].CantidadTitulo, Data = response.Data[1].Items.Select(item => item.Cantidad).ToArray() }
                    //new ChartSeries() { Name = response.Data[0].Titulo + ": " + response.Data[0].CantidadTitulo, Data = listAux1.ToArray() },
                    //new ChartSeries() { Name = response.Data[1].Titulo + ": " + response.Data[1].CantidadTitulo, Data = listAux2.ToArray() }
                };
                //XAxisLabels = dias.ToArray();
                totalBolsasTrabajo = " Total : " + response.Info.TotalData.ToString();
            }
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                filtroTotalBolsasTrabajo.FiltroFechas = 4;
                actualizarFiltro();
                yearError = "";
                filtroTotalBolsasTrabajo.Year = year;
                
            }
            else
            {
                yearError = "Seleccione un año";
            }
            ActualizarFiltros();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            mes = int.Parse(args.Value.ToString());
            if (mes != 0)
            {
                filtroTotalBolsasTrabajo.FiltroFechas= 4;
                actualizarFiltro();
                mesError = "";
                filtroTotalBolsasTrabajo.Mes = mes;
                if (year != 0)
                {
                    ActualizarFiltros();
                }
                else
                {
                    yearError = "Seleccione un año";
                }
            }
            else
            {
                mesError = "Seleccione un mes";
            }
            ActualizarFiltros();
            StateHasChanged();
        }

        private void actualizarFiltro()
        {
            if (filtroTotalBolsasTrabajo.FiltroFechas >= 3)
            {
                filtroTotalBolsasTrabajo.FechaFin = Fecha.GetFechaMx();
                filtroTotalBolsasTrabajo.FechaInicio = Fecha.GetFechaMx();
                filtroTotalBolsasTrabajo.FechaFin = Fecha.GetFechaMx();
                //FechaFija = Fecha.GetFechaMx();
                //FechaInicio = Fecha.GetFechaMx();
                //FechaFin = Fecha.GetFechaMx();
            }
            else if (filtroTotalBolsasTrabajo.FiltroFechas == 2)
            {
                filtroTotalBolsasTrabajo.FechaFin = Fecha.GetFechaMx();
                //FechaFija = Fecha.GetFechaMx();
                filtroTotalBolsasTrabajo.Year = 0;
                filtroTotalBolsasTrabajo.Mes = 0;
                year = 0;
                mes = 0;
            }
            else
            {
                filtroTotalBolsasTrabajo.FechaFin = Fecha.GetFechaMx();
                filtroTotalBolsasTrabajo.FechaInicio = Fecha.GetFechaMx();
                filtroTotalBolsasTrabajo.FechaFin = Fecha.GetFechaMx();
                //FechaInicio = Fecha.GetFechaMx();
                //FechaFin = Fecha.GetFechaMx();
                filtroTotalBolsasTrabajo.Year = 0;
                filtroTotalBolsasTrabajo.Mes = 0;
                year = 0;
                mes = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            filtroTotalBolsasTrabajo = new FiltroTotalBolsasTrabajo();
            filtroTotalBolsasTrabajo.Year = Fecha.GetFechaMx().Year;
            filtroTotalBolsasTrabajo.Mes = Fecha.GetFechaMx().Month;
            filtroTotalBolsasTrabajo.FiltroFechas = 4;
            year = Fecha.GetFechaMx().Year;
            mes = Fecha.GetFechaMx().Month;
            CambioSection(0);
            ActualizarFiltros();
            StateHasChanged();
        }

        private async void ActualizarFiltros()
        {
            Series = new List<ChartSeries>();
            XAxisLabels = new string[] { };
            totalBolsasTrabajo = "";
            StateHasChanged();
            ConsultarDataSet();
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
    }
}
