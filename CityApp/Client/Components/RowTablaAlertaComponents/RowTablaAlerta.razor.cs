using CityApp.Client.Logic.RowTablaAlertaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.RowTablaAlertaComponents
{
    public partial class RowTablaAlerta
    {
        [Parameter] public List<EstatusAlerta> estatusAlertas { get; set; } = new List<EstatusAlerta>();
        [Parameter] public Alerta alerta { get; set; } = new Alerta();
        [Parameter] public Sesion sesion { get; set; }
        [Parameter] public EventCallback consultarAlertas { get; set; }
        [Inject] private HttpClient Cliente { get; set; }

        private int idEstatusAlerta = 0;
        private string idEstatusAlertaError = "";

        protected override async Task OnInitializedAsync()
        {
            if(alerta != null)
            {
                if(alerta.IdAlerta != 0)
                {
                    idEstatusAlerta = alerta.IdEstatusAlerta;
                }
            }

        }

        public async Task ActualizarEstusAlerta()
        {
            Response<object> response = new Response<object>();
            UpdateEstatusAlerta updateEstatusAlerta = new UpdateEstatusAlerta(Cliente);
            response = await updateEstatusAlerta.Update(sesion.TokenAcceso, alerta.IdAlerta, idEstatusAlerta);
            if(response.Status.Exito == 1)
            {
                await consultarAlertas.InvokeAsync();
            }
            StateHasChanged();
        }

        private void SelectIdEstatusAlerta(ChangeEventArgs args)
        {
            idEstatusAlerta = int.Parse(args.Value.ToString());
            if (idEstatusAlerta != 0)
            {
                idEstatusAlertaError = "";
            }
            else
            {
                idEstatusAlertaError = "Seleccione un estatus";
            }
            ActualizarEstusAlerta();
            StateHasChanged();
        }
    }
}
