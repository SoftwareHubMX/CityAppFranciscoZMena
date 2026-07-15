using Blazored.LocalStorage;
using CityApp.Client.Logic.ModalPagoCompletoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalPagoCompletoComponents
{
    public partial class ModalPagoCompleto
    {
        [Parameter] public int IdPago { get; set; } = 0;
        [Parameter] public EventCallback<int> OpenCloseModal { get; set; }
        [Inject] private HttpClient cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private Sesion Sesion = new Sesion();
        private Pago pago = new Pago();
        private string alerta = "";
        private string alerta2 = "";
        private bool loader = true;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
            {
                ConsultarPago();
            }
        }

        private async void ConsultarPago()
        {
            if (IdPago != 0)
            {
                Response<Pago> response = new Response<Pago>();
                SelectPago selectPago = new SelectPago(cliente);
                response = await selectPago.Select(Sesion.TokenAcceso, IdPago);
                if (response.Status.Exito == 1)
                {
                    pago = response.Data;
                }
                else 
                {
                    alerta = response.Status.Mensaje;
                }
                loader = false;
            }
            else
            {
                ConsultarPago();
            }
            StateHasChanged();
        }

        private async void Eliminar()
        {
            Response<object> response = new Response<object>();
            DeletePago deletePago = new DeletePago(cliente);
            response = await deletePago.Delete(Sesion.TokenAcceso, IdPago);
            if(response.Status.Exito == 1)
            {
                 await OpenCloseModal.InvokeAsync(1);
            }
            else
            {
                alerta2 = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
