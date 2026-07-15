using CityApp.Client.Logic.TablaReporteCiudadanoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace CityApp.Client.Components.MapaReporteCiudadanoComponents
{
public partial class MapaReporteCiudadano : IAsyncDisposable
    {
        [Parameter] public List<ReporteCiudadano> reportes { get; set; }
        [Parameter] public Sesion Sesion { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;

        private bool banderaReportes = false;

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                if(reportes != null)
                {
                    try
                    {
                        modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/MapaReporteCiudadanoJs/MapaReporteCiudadano.js");
                        StateHasChanged();
                    }
                    catch(Exception e)
                    {
                        NavigationManager.NavigateTo(NavigationManager.Uri.ToString(), true);
                    }
                }
            }
            else
            {
                if(reportes != null && reportes.Count > 0)
                {
                    if (!banderaReportes)
                    {
                        DescargarArchivosEvidencia();
                        banderaReportes = true;
                        StateHasChanged();
                    }
                }
                else
                {
                    banderaReportes = false;
                }
            }
        }

        private async void DescargarArchivosEvidencia()
        {
            if (reportes != null)
            {
                for (int i = 0; i < reportes.Count; i++)
                {
                    if (reportes[i].VercionesReporteCiudadano != null && reportes[i].VercionesReporteCiudadano.Count > 0)
                    {
                        if (reportes[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano != null)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DowloadEvidenciasResporteCiudadano dowloadEvidenciasResporteCiudadano = new DowloadEvidenciasResporteCiudadano(Cliente);
                            response = await dowloadEvidenciasResporteCiudadano.Dowload(reportes[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano[0].Ruta, Sesion.TokenAcceso, reportes[i].VercionesReporteCiudadano[0].IdVercionReporteCiudadano);
                            if (response.Status.Exito == 1)
                            {
                                reportes[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano[0].Ruta = Convert.ToBase64String(response.Data);
                            }
                            StateHasChanged();
                        }
                    }
                }
            }
            GenerarDataPushPins();
            StateHasChanged();
        }

        private async void GenerarDataPushPins()
        {
            string data = "";
            for (int i = 0; i < reportes.Count; i++)
            {
                data += "https://simplepos.mx/smart_city/PushPoints/";
                if (reportes[i].IdEstatusReporteCiudadano == 1)
                {
                    data += "Reportado/" + reportes[i].TipoReporteCiudadano.TipoReporte + ".png, ";
                }
                else if (reportes[i].IdEstatusReporteCiudadano == 2)
                {
                    data += "EnProceso/" + reportes[i].TipoReporteCiudadano.TipoReporte + ".png, ";
                }
                else if (reportes[i].IdEstatusReporteCiudadano == 3)
                {
                    data += "Resuelto/" + reportes[i].TipoReporteCiudadano.TipoReporte + ".png, ";
                }
                else if (reportes[i].IdEstatusReporteCiudadano == 4)
                {
                    data += "FalsaAlarma/" + reportes[i].TipoReporteCiudadano.TipoReporte + ".png, ";
                }
                data += reportes[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Latitud.ToString("0,0.0000", CultureInfo.InvariantCulture) + ", " + reportes[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Longitud.ToString("0,0.0000", CultureInfo.InvariantCulture) + ", ";
                data += reportes[i].TipoReporteCiudadano.TipoReporte + ", ";
                data += reportes[i].VercionesReporteCiudadano.Count + ", ";
                data += reportes[i].FechaPrimerReporte.ToString("dd/MM/yyyy") + ", ";
                if (reportes[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano != null && reportes[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano.Count > 0)
                {
                    data += reportes[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano[0].Ruta + ", ";
                }
                else
                {
                    data += ", ";
                }
                if (i == (reportes.Count - 1))
                {
                    data += reportes[i].IdReporteCiudadano;
                }
                else
                {

                    data += reportes[i].IdReporteCiudadano + " : ";
                }
            }
            await modulo.InvokeVoidAsync("CargaMap", data);
        }

        public async ValueTask DisposeAsync()
        {
            if (modulo != null)
            {
                await modulo.DisposeAsync();
            }
        }
    }
}
