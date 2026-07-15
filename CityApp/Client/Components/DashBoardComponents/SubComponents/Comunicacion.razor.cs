using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using CityApp.Client.Logic.DashBoardLogic;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using Blazored.LocalStorage;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;

namespace CityApp.Client.Components.DashBoardComponents.SubComponents
{
    public partial class Comunicacion
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private List<ChartData> Data = new List<ChartData>();
        private Sesion Sesion = new Sesion();
        private FechasDashBoard fechasDashBoard = new FechasDashBoard();
        private int year = DateTime.UtcNow.AddHours(-6).Year;
        private int mes = DateTime.UtcNow.AddHours(-6).Month;
        private string yearError = "";
        private string mesError = "";
        private string alerta = "";
        private bool banderaCarga = true;

        protected override async void OnInitialized()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
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
            SelectComunicacion SelectComunicacion = new SelectComunicacion(Cliente);
            response = await SelectComunicacion.Select(fechasDashBoard, Sesion.TokenAcceso);
            if(response.Status.Exito == 1)
            {
                Data = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaCarga = false;
            StateHasChanged();
        }
        private string GetIconClassForValue(string value)
        {
            switch (value)
            {
                case "Noticias":
                    return "fa-solid fa-square-poll-horizontal icono_info";
                case "Eventos":
                    return "fa-solid fa-calendar-days icono_automatizado";
                default:
                    return "fa-solid fa-question-circle icono_default";
            }
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
