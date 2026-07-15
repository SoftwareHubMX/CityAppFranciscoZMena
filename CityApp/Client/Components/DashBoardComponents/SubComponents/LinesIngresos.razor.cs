using Blazored.LocalStorage;
using CityApp.Client.Logic.DashBoardLogic;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.DashBoardComponents.SubComponents
{
    public partial class LinesIngresos
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private List<ChartData> Data = new List<ChartData>();
        private Sesion Sesion = new Sesion();
        private FechasDashBoard fechasDashBoard = new FechasDashBoard();
        private int year = DateTime.UtcNow.AddHours(-6).Year;
        private int year2 = DateTime.UtcNow.AddHours(-6).Year;
        private string yearError = "";
        private string year2Error = "";
        private string alerta = "";
        private bool banderaCarga = true;

        private int Index = -1; //default value cannot be 0 -> first selectedindex is 0.
        private ChartOptions options = new ChartOptions();
        public List<ChartSeries> Series = new List<ChartSeries>();
        public string[] XAxisLabels = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "oct", "Nov", "Dic" };

        protected override async void OnInitialized()
        {
            options.InterpolationOption = InterpolationOption.Straight;
            //options.YAxisFormat = "c2";
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                fechasDashBoard.Year = year;
                fechasDashBoard.Year2 = year2;
                fechasDashBoard.TipoFecha = 2;
                Consultar();
            }
        }

        private async void Consultar()
        {
            Series = new List<ChartSeries>();
            banderaCarga = true;
            yearError = "";
            yearError = "";
            StateHasChanged();
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            SelectDataSetIngresosYear selectDataSetIngresosYear = new SelectDataSetIngresosYear(Cliente);
            response = await selectDataSetIngresosYear.Select(fechasDashBoard, Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                Data = response.Data;
                foreach(var d in Data)
                {
                    ChartSeries ChartSerie = new ChartSeries() 
                    { 
                        Name = d.Label,
                        Data = d.Data.ToArray(),
                    };
                    Series.Add(ChartSerie);
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaCarga = false;
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                if(year > year2)
                {
                    yearError = "El año de inicio no puede ser mayor al año final";
                }
                else
                {
                    yearError = "";
                    fechasDashBoard.Year = year;
                    Consultar();
                }
            }
            else
            {
                yearError = "Seleccione un año";
            }
            StateHasChanged();
        }

        private void SelectYear2(ChangeEventArgs args)
        {
            year2 = int.Parse(args.Value.ToString());
            if (year2 != 0)
            {
                if (year > year2)
                {
                    year2Error = "El año de inicio no puede ser mayor al año final";
                }
                else
                {
                    year2Error = "";
                    fechasDashBoard.Year2 = year2;
                    if (year != 0)
                    {
                        Consultar();
                    }
                    else
                    {
                        yearError = "Seleccione un año";
                    }
                }
            }
            else
            {
                year2Error = "Seleccione un mes";
            }
            StateHasChanged();
        }
    }
}
