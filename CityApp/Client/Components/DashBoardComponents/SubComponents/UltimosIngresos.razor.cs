using Blazored.LocalStorage;
using CityApp.Client.Logic.DashBoardLogic;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.DashBoardComponents.SubComponents
{
    public partial class UltimosIngresos
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private List<UltimoPago> Data = new List<UltimoPago>();
        private Sesion Sesion = new Sesion();
        private string alerta = "";
        private bool banderaCarga = true;

        protected override async void OnInitialized()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                Consultar();
            }
        }

        private async void Consultar()
        {
            Response<List<UltimoPago>> response = new Response<List<UltimoPago>>();
            SelectLastIngresos selectLastIngresos = new SelectLastIngresos(Cliente);
            response = await selectLastIngresos.Select(Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
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
    }
}
