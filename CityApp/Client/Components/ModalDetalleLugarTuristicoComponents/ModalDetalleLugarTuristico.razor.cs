using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarLugarturisticoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalDetalleLugarTuristicoComponents
{
    public partial class ModalDetalleLugarTuristico
    {
        [Parameter] public int idLugar { get; set; } = 0;
        [Parameter] public Sesion Sesion { get; set; } = new Sesion();
        [Parameter] public EventCallback OpenCloseModal { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private bool banderaCargaInfo = false;
        private string alerta = "";
        private LugarTuristico LugarTuristico = new LugarTuristico();


        protected override async Task OnInitializedAsync()
        {
            ConsultarLugarTuristico();
        }
        private async void ConsultarLugarTuristico()
        {
            
            Response<LugarTuristico> response = new Response<LugarTuristico>();
            SelectLugarTuristico selectLugarTuristico = new SelectLugarTuristico(Cliente);
            response = await selectLugarTuristico.Select(idLugar);
            if (response.Status.Exito == 1)
            {
                LugarTuristico = response.Data;
               
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaCargaInfo = true;
            StateHasChanged();
        }
    }
}
