using Blazored.LocalStorage;
using CityApp.Client.Logic.DashBoardLogic;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.DashBoardComponents.SubComponents
{
    public partial class Turismo
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
            SelectTiposLugarTuristico selectTiposLugarTuristico = new SelectTiposLugarTuristico(Cliente);
            response = await selectTiposLugarTuristico.Select(fechasDashBoard, Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                foreach (var item in response.Data)
                {
                    item.ImageSource = GetImageForValue(item.Label);
                }
                Data = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaCarga = false;
            StateHasChanged();
        }

        private string GetImageForValue(string value)
        {
            switch (value)
            {
                case "Museo":
                    return "Iconografia/ic_turismo_museo.svg";
                case "Restaurante":
                    return "Iconografia/ic_turismo_restaurante.svg";
                case "Monumento":
                    return "Iconografia/ic_turismo_monumentos.svg";
                case "Parque":
                    return "Iconografia/ic_turismo_parque.svg";
                case "Teatro":
                    return "Iconografia/ic_turismo_teatro.svg";
                case "Edificio histórico":
                    return "Iconografia/ic_turismo_edificiohistorico.svg";
                case "Hotel":
                    return "Iconografia/ic_turismo_hotel.svg";
                default:
                    return "Iconografia/noticias.svg"; // Imagen predeterminada si no coincide ningún valor
            }
        }

        //private void SelectYear(ChangeEventArgs args)
        //{
        //    year = int.Parse(args.Value.ToString());
        //    if (year != 0)
        //    {
        //        yearError = "";
        //        fechasDashBoard.Year = year;
        //        Consultar();
        //    }
        //    else
        //    {
        //        yearError = "Seleccione un año";
        //    }
        //    StateHasChanged();
        //}

        //private void SelectMonth(ChangeEventArgs args)
        //{
        //    mes = int.Parse(args.Value.ToString());
        //    if (mes != 0)
        //    {
        //        mesError = "";
        //        fechasDashBoard.Mes = mes;
        //        if (year != 0)
        //        {
        //            Consultar();
        //        }
        //        else
        //        {
        //            yearError = "Seleccione un año";
        //        }
        //    }
        //    else
        //    {
        //        mesError = "Seleccione un mes";
        //    }
        //    StateHasChanged();
        //}
    }
}
