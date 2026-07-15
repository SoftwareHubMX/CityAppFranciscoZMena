using Blazored.LocalStorage;
using CityApp.Client.Logic.DashBoardLogic;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.DashBoardComponents.SubComponents
{
    public partial class DonutsReportesCiudadanos
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private List<ChartData> DataChart = new List<ChartData>();
        private Sesion Sesion = new Sesion();
        private FechasDashBoard fechasDashBoard = new FechasDashBoard();
        private int year = DateTime.UtcNow.AddHours(-6).Year;
        private int mes = DateTime.UtcNow.AddHours(-6).Month;
        private string yearError = "";
        private string mesError = "";
        private string alerta = "";
        private bool banderaCarga = true;

        public double[] data = { };
        public string[] labels = { };

        protected override async void OnInitialized()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                fechasDashBoard.Year = year;
                fechasDashBoard.Mes = mes;
                fechasDashBoard.TipoFecha = 1;
                Consultar();
            }
        }

        private async void Consultar()
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            SelectDataSetYearReporteCiudadano selectDataSetYearReporteCiudadano = new SelectDataSetYearReporteCiudadano(Cliente);
            response = await selectDataSetYearReporteCiudadano.Select(fechasDashBoard, Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                DataChart = response.Data;
                List<double> arrayData = new List<double>();
                List<string> arrayLabel = new List<string>();
                foreach (var d in DataChart)
                {
                    arrayData.Add(d.Data[0]);
                    arrayLabel.Add(d.Label + ": " + d.Data[0].ToString());
                }
                data = arrayData.ToArray();
                labels = arrayLabel.ToArray();
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
                yearError = "";
                fechasDashBoard.Year = year;
                Consultar();
            }
            else
            {
                yearError = "Seleccione un año";
            }
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            mes = int.Parse(args.Value.ToString());
            if (mes != 0)
            {
                mesError = "";
                fechasDashBoard.Mes = mes;
                if (year != 0)
                {
                    Consultar();
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
            StateHasChanged();
        }
    }
}
