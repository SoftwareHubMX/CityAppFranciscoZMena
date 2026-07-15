using Blazored.LocalStorage;
using CityApp.Client.Logic.CardPagoMovilLogic;
using CityApp.Shared.Models.ControllersModels.PredioSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardPagoMovilComponents
{
    public partial class CardPagoMovil
    {
        [Parameter] public int idTipoPago { get; set; } = 0;
        [Parameter] public int idObjeto { get; set; } = 0;
        [Parameter] public string Token { get; set; } = "";
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] private HttpClient Cliente { get; set; }

        private InformacionPagoPredio InformacionPagoPredio = new InformacionPagoPredio();

        private bool banderaPagoPredio = false;
        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            await LocalStorage.SetItemAsync<int>("idObjeto", idObjeto);
            await LocalStorage.SetItemAsync<string>("token", Token);
            if(idTipoPago == 1)
            {
                ConsultarPredioPago();
            }
            else
            {
                alerta = "Metodo de pago no disponible por el momento";
                await Task.Delay(1000);
                banderaPagoPredio = true;
                StateHasChanged();
            }
        }

        private async void ConsultarPredioPago()
        {
            await Task.Delay(1000);
            Response<InformacionPagoPredio> response = new Response<InformacionPagoPredio>();
            SelectPagoPredio selectPagoPredio = new SelectPagoPredio(Cliente);
            response = await selectPagoPredio.Select(idObjeto, Token);
            if(response.Status.Exito == 1)
            {
                InformacionPagoPredio = response.Data;
                await LocalStorage.SetItemAsync<string>("clave", InformacionPagoPredio.Clave);
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaPagoPredio = true;
            StateHasChanged();
        }
    }
}
