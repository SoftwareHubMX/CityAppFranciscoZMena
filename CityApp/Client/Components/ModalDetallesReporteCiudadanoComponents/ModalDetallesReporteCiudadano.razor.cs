using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ModalDetallesReporteCiudadanoLogic;
using CityApp.Client.Logic.TablaReporteCiudadanoLogic;
using CityApp.Client.Services.SoketSignalR;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalDetallesReporteCiudadanoComponents
{
    public partial class ModalDetallesReporteCiudadano
    {
        
        [Parameter] public int idReporteCiudadano { get; set; } = 0;
        [Parameter] public Sesion Sesion { get; set; } = new Sesion();
        [Parameter] public EventCallback OpenCloseModal { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] private SignalRService SignalRService { get; set; }

        private Validaciones Validaciones = new Validaciones();

        private string observaciones = "";
        private string ErrorObservaciones = "";

        private bool banderaBoton = false;
        
        private ReporteCiudadano ReporteCiudadano = null;

        private string alerta = "";
        private bool banderaCargaInfo = false;

        protected override async Task OnInitializedAsync()
        {
            //observaciones = ReporteCiudadano.Observaciones;
            ConsultarReporteCiudadano();
        }

        private async void ConsultarReporteCiudadano()
        {
            SelectReporteCiudadanoCompleto selectReporteCiudadanoCompleto = new SelectReporteCiudadanoCompleto(Cliente);
            Response<ReporteCiudadano> response = new Response<ReporteCiudadano>();
            response = await selectReporteCiudadanoCompleto.Select(Sesion.TokenAcceso, idReporteCiudadano);
            if (response.Status.Exito == 1)
            {
                ReporteCiudadano = new ReporteCiudadano();
                ReporteCiudadano = response.Data;
                observaciones = ReporteCiudadano.Observaciones;    
                DescargarArchivosEvidencia();
                DescargarArchivosEvidenciaSolucion();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaCargaInfo = true;
            StateHasChanged();
        }

        private async void DescargarArchivosEvidencia()
        {
            if (ReporteCiudadano != null)
            {
                if (ReporteCiudadano.VercionesReporteCiudadano != null && ReporteCiudadano.VercionesReporteCiudadano.Count > 0)
                {
                    for (int i = 0; i < ReporteCiudadano.VercionesReporteCiudadano.Count; i++)
                    {
                        if (ReporteCiudadano.VercionesReporteCiudadano[i].EvidenciasReporteCiudadano != null && ReporteCiudadano.VercionesReporteCiudadano[i].EvidenciasReporteCiudadano.Count > 0)
                        {
                            for (int j = 0; j < ReporteCiudadano.VercionesReporteCiudadano[i].EvidenciasReporteCiudadano.Count; j++)
                            {
                                Response<byte[]> response = new Response<byte[]>();
                                DowloadEvidenciasResporteCiudadano dowloadEvidenciasResporteCiudadano = new DowloadEvidenciasResporteCiudadano(Cliente);
                                response = await dowloadEvidenciasResporteCiudadano.Dowload(ReporteCiudadano.VercionesReporteCiudadano[i].EvidenciasReporteCiudadano[j].Ruta, Sesion.TokenAcceso, ReporteCiudadano.VercionesReporteCiudadano[i].IdVercionReporteCiudadano);
                                if (response.Status.Exito == 1)
                                {
                                    ReporteCiudadano.VercionesReporteCiudadano[i].EvidenciasReporteCiudadano[j].Ruta = Convert.ToBase64String(response.Data);
                                }
                            }
                            StateHasChanged();
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private async void DescargarArchivosEvidenciaSolucion()
        {
            if (ReporteCiudadano != null)
            {
                if (ReporteCiudadano.EvidenciasSolucionReporteCiudadano != null && ReporteCiudadano.EvidenciasSolucionReporteCiudadano.Count > 0)
                {
                    for (int i = 0; i < ReporteCiudadano.EvidenciasSolucionReporteCiudadano.Count; i++)
                    {
                        Response<byte[]> response = new Response<byte[]>();
                        DowloadEvidenciasSolucionResporteCiudadano dowloadEvidenciasSolucionResporteCiudadano = new DowloadEvidenciasSolucionResporteCiudadano(Cliente);
                        response = await dowloadEvidenciasSolucionResporteCiudadano.Dowload(ReporteCiudadano.EvidenciasSolucionReporteCiudadano[i].Ruta, Sesion.TokenAcceso, ReporteCiudadano.IdReporteCiudadano);
                        if (response.Status.Exito == 1)
                        {
                            ReporteCiudadano.EvidenciasSolucionReporteCiudadano[i].Ruta = Convert.ToBase64String(response.Data);
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private async void ActualizarObservaciones()
        {
            Response<object> response = new Response<object>();
            UpdateObservacionesReporteCiudadano updateObservacionesReporteCiudadano = new UpdateObservacionesReporteCiudadano(Cliente);
            response = await updateObservacionesReporteCiudadano.Updata(Sesion.TokenAcceso, observaciones, idReporteCiudadano);
            if (response.Status.Exito == 1)
            {

                NavigationManager.NavigateTo("/ReporteCiudadano");
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
        private void TxtObservaciones(ChangeEventArgs args)
        {
            observaciones = args.Value.ToString();
            if (observaciones != "")
            {
                ErrorObservaciones = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(observaciones))
                {
                    ErrorObservaciones = "";
                    ReporteCiudadano.Observaciones = observaciones;
                }
                else
                {
                    ErrorObservaciones = "NoCaracteresEspeciales";
                    observaciones = "";
                    ReporteCiudadano.Observaciones = "NA";
                }
            }
            StateHasChanged();
        }
    }
}
