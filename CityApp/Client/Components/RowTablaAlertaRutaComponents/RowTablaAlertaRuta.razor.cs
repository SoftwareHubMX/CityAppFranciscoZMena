using CityApp.Client.Logic.RowTablaAlertaRutaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.RowTablaAlertaRutaComponents
{
    public partial class RowTablaAlertaRuta
    {
        [Parameter] public List<StatusAlertaRuta> statusAlertasRutas { get; set; } = new List<StatusAlertaRuta>();
        [Parameter] public AlertaRuta alertaRuta { get; set; } = new AlertaRuta();
        [Parameter] public Sesion sesion { get; set; }
        [Parameter] public EventCallback consultarAlertasRuta { get; set; }
        [Inject] private HttpClient Cliente { get; set; }

        private int idStatusAlertaRuta = 0;
        private string idStatusAlertaRutaError = "";

        protected override async Task OnInitializedAsync()
        {
            if(alertaRuta != null)
            {
                if(alertaRuta.IdAlertaRuta != 0)
                {
                    idStatusAlertaRuta = alertaRuta.IdStatusAlertaRuta;
                }
            }

        }

        public async Task ActualizarStatusAlertaRuta()
        {
            Response<object> response = new Response<object>();
            UpdateStatusAlertaRutaLogic updateStatusAlertaRutaLogic = new UpdateStatusAlertaRutaLogic(Cliente);
            response = await updateStatusAlertaRutaLogic.Update(sesion.TokenAcceso, alertaRuta.IdAlertaRuta, idStatusAlertaRuta);
            if(response.Status.Exito == 1)
            {
                await consultarAlertasRuta.InvokeAsync();
            }
            StateHasChanged();
        }

        private void SelectIdStatusAlertaRuta(ChangeEventArgs args)
        {
            idStatusAlertaRuta = int.Parse(args.Value.ToString());
            if (idStatusAlertaRuta != 0)
            {
                idStatusAlertaRutaError = "";
            }
            else
            {
                idStatusAlertaRutaError = "Seleccione un estatus";
            }
            ActualizarStatusAlertaRuta();
            StateHasChanged();
        }
    }
}
