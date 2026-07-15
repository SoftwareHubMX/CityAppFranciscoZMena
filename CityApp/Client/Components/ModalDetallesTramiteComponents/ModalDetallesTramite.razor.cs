using CityApp.Client.Logic.ModalDetallesTramiteLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalDetallesTramiteComponents
{
    public partial class ModalDetallesTramite
    {
        [Parameter] public int idTramite { get; set; } = 0;
        [Parameter] public Sesion Sesion { get; set; } = new Sesion();
        [Parameter] public EventCallback OpenCloseModal { get; set; }
        [Inject] private HttpClient Cliente { get; set; }

        private Tramite Tramite = null;

        private string alerta = "";
        private bool banderaCargaInfo = false;

        protected override async Task OnInitializedAsync()
        {
            ConsultarReporteCiudadano();
        }

        private async void ConsultarReporteCiudadano()
        {
            SelectTramiteCompletoLogic selectTramiteCompletoLogic = new SelectTramiteCompletoLogic(Cliente);
            Response<Tramite> response = new Response<Tramite>();
            response = await selectTramiteCompletoLogic.Select(Sesion.TokenAcceso, idTramite);
            if (response.Status.Exito == 1)
            {
                Tramite = new Tramite();
                Tramite = response.Data;
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
