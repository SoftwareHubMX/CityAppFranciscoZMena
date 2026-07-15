using CityApp.Client.Logic.RowTablaReportesCiudadanosLogic;
using CityApp.Client.Logic.TablaReporteCiudadanoLogic;
using CityApp.Client.Services.SoketSignalR;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.RowTablaReportesCiudadanosComponents
{
    public partial class RowTablaReportesCiudadanos
    {
        [Parameter] public List<EstatusReporteCiudadano> EstatusReporteCiudadanos { get; set; }
        [Parameter] public ReporteCiudadano reporte { get; set; }
        [Parameter] public Sesion Sesion { get; set; }
        [Parameter] public EventCallback<int> openModalDetalles { get; set; }
        [Parameter] public EventCallback DescargarImagenes { get; set; }
        [Parameter] public EventCallback<ReporteCiudadano> ActualizarvistaEstatus { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] private SignalRService SignalRService { get; set; }

        private string idBtnCroper = "";

        private List<string> ArchivosModal = new List<string>();
        private string imgModal = "";
        private bool modalcarusel = false;

        private int IdReporteCiudadanoModal = 0;
        private List<string> ArchivosModalEvidencias = new List<string>();
        private bool modalEvidenciasSolucion = false;

        private int idEstatusReporteCiudadano = 0;

        protected override async Task OnInitializedAsync()
        {
            idEstatusReporteCiudadano = reporte.IdEstatusReporteCiudadano;
            idBtnCroper = "'input" + reporte.IdReporteCiudadano + "'";
            StateHasChanged();
        }

        private void SelectidEstatusReporteCiudadano(ChangeEventArgs args)
        {
            idEstatusReporteCiudadano = int.Parse(args.Value.ToString());
            if (idEstatusReporteCiudadano > 0)
            {
                //reporte.EstatusReporteCiudadano.IdEstatusReporteCiudadano = idEstatusReporteCiudadano;
                reporte.IdEstatusReporteCiudadano = idEstatusReporteCiudadano;
                ActualizarEstatus();
            }
            StateHasChanged();
        }

        private async void ActualizarEstatus()
        {
            Response<object> response = new Response<object>();
            UpdataEstausReporteCiudadano updataEstausReporteCiudadano = new UpdataEstausReporteCiudadano(Cliente);
            response = await updataEstausReporteCiudadano.Updata(Sesion.TokenAcceso, idEstatusReporteCiudadano, reporte.IdReporteCiudadano);
            if (response.Status.Exito == 1)
            {
                await ActualizarvistaEstatus.InvokeAsync(reporte);
                Peticion<int> peticion = new Peticion<int>()
                {
                    Data = reporte.IdReporteCiudadano
                };
                await SignalRService.ActualizacionEstatus(peticion);
            }
            StateHasChanged();
        }

        private async Task saveImage(MultipartFormDataContent content)
        {
            openModalEvidenciasSolucion(0);
            StateHasChanged();
            Response<string> responseArchivoImagen = new Response<string>();
            InsertArchivoEvidenciaSolucion insertArchivoEvidenciaSolucion = new InsertArchivoEvidenciaSolucion(Cliente);
            responseArchivoImagen = await insertArchivoEvidenciaSolucion.Insert(content, reporte.IdReporteCiudadano, Sesion.TokenAcceso);
            if (responseArchivoImagen.Status.Exito == 1)
            {
                DescargarImagenes.InvokeAsync();
                openModalEvidenciasSolucion(IdReporteCiudadanoModal);
            }
            StateHasChanged();
        }

        private void PasarDatoImg(string img)
        {
            imgModal = img;
            openModalCarusel();
        }

        private async void openModalCarusel()
        {
            if (modalcarusel)
            {
                modalcarusel = false;
            }
            else
            {
                modalcarusel = true;
            }
            StateHasChanged();
        }

        private async void openModalEvidenciasSolucion(int idReporte)
        {
            if (modalEvidenciasSolucion)
            {
                modalEvidenciasSolucion = false;
            }
            else
            {
                IdReporteCiudadanoModal = idReporte;
                GenerarListArchivos();
                modalEvidenciasSolucion = true;
            }
            StateHasChanged();
        }

        private void GenerarListArchivos()
        {
            ArchivosModalEvidencias = new List<string>();
            for (int i = 0; i < reporte.EvidenciasSolucionReporteCiudadano.Count; i++)
            {
                ArchivosModalEvidencias.Add(reporte.EvidenciasSolucionReporteCiudadano[i].Ruta);
            }
        }
    }
}
