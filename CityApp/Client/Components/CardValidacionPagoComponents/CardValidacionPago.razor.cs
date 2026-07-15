using Blazored.LocalStorage;
using CityApp.Client.Logic.CardValidacionPago;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardValidacionPagoComponents
{
    public partial class CardValidacionPago
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        private bool banderComprobacionPago = false;
        private string alerta = "";

        private int idCuenta = 0;
        private string clave = "";
        private string _url = "";
        CrearPago pago = new CrearPago()
        {
            FechaPago = Fecha.GetFechaMx(),
            Total = 10,
            IdTipoPago = 1,
            Referencia = "Pago_servicio_Predio"
        };

        protected override async Task OnInitializedAsync()
        {
            idCuenta = await LocalStorage.GetItemAsync<int>("idCuenta");
            if(idCuenta != null && idCuenta > 0)
            {
                clave = await LocalStorage.GetItemAsync<string>("clave");
                if (clave != null && clave != "")
                {
                    pago.Identificador = clave;
                    SplitRespuesta();
                }
            }
        }

        private void SplitRespuesta()
        {
            _url = NavigationManager.Uri.ToString();
            string[] arrayDataUrl = _url.Split("1?preapproval_id=");
            pago.Referencia = arrayDataUrl[1];
            CrearPagoPredio();
        }

        private async void CrearPagoPredio()
        {
            Response<PagoTarjeta> response = new Response<PagoTarjeta>();
            InsertPago insertPago = new InsertPago(Cliente);
            response = await insertPago.Insert(idCuenta, pago);
            if(response.Status.Exito == 1)
            {
                await LocalStorage.RemoveItemAsync("idCuenta");
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderComprobacionPago = true;
            StateHasChanged();
        }
    }
}
