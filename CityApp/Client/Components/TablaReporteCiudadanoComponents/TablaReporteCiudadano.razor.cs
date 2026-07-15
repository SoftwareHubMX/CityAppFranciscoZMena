using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaReporteCiudadanoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace CityApp.Client.Components.TablaReporteCiudadanoComponents
{
    public partial class TablaReporteCiudadano
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        [Inject] IJSRuntime js { get; set; }
        IJSObjectReference modulo;
        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();
        private string alertaDescarga = "";

        private List<ReporteCiudadano> ReportesCiudadanos = new List<ReporteCiudadano>();
        private List<EstatusReporteCiudadano> EstatusReporteCiudadanos = new List<EstatusReporteCiudadano>();
        private List<TipoReporteCiudadano> TiposReportesCiudadanos = new List<TipoReporteCiudadano>();
        private List<string> EvidenciasRepoteCiudadano = new List<string>();
        private List<string> EvidenciasSolucionRepoteCiudadano = new List<string>();
        private Sesion Sesion = new Sesion();
        private TipoReporteCiudadano TipoReporteCiudadano = new TipoReporteCiudadano();
        private FiltroReportesCiudadanos FiltroReportesCiudadanos = new FiltroReportesCiudadanos();

        private string estatus = "Desconocido";
        private string direccion = "Desconocido";

        private string alerta = "";
        private int idRol = 0;
        private int idTipoReportesss = 0;


        private int idReporteCiudadano = 0;
        private int idEstatusReporteCiudadano = 0;
        private string idEstatusReporteCiudadanoError = "";


        private List<int> paginas = new List<int>();
        private int paginaActual = 1;


        private bool banderaLoader = false;
        private bool banderamodal = false;


        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                idRol = Sesion.IdRol;
                FiltroReportesCiudadanos.Pagina = 1;
                FiltroReportesCiudadanos.MaximoElementos = 20;
                banderaLoader = true;
                StateHasChanged();
                ConsultarEstatus();
                await ConsultarTipos();
                foreach (var tipo in TiposReportesCiudadanos.ToList())
                {
                    if (idRol == 10 && tipo.IdTipoReporteCiudadano == 2)
                    {
                        TiposReportesCiudadanos.Remove(tipo);
                    }
                }
                if (idRol == 8)
                {
                    idTipoReportesss = 2;
                }
                ConsultarReporteCiudadano();
            }
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {

                modulo = await js.InvokeAsync<IJSObjectReference>("import", "../Js/DescargaArchivos/DescargaArchivos.js");

                archivoIdioma = await LocalStorage.GetItemAsync<string>("Language");

                if (archivoIdioma != null)
                {
                    ViewString.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(archivoIdioma));
                }
                else
                {
                    archivoIdioma = "es-MX";
                    ViewString.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(archivoIdioma));
                    await LocalStorage.SetItemAsync<string>("Language", archivoIdioma);
                }
                StateHasChanged();

            }
        }



        private async void ConsultarReporteCiudadano()
        {
            paginas = new List<int>();
            Response<List<ReporteCiudadano>> response = new Response<List<ReporteCiudadano>>();
            SelectReportesaCiudadnos selectReportesaCiudadnos = new SelectReportesaCiudadnos(Cliente);
            // Agrega un filtro para idTipoReporteCiudadano si se proporciona
            if (idTipoReportesss > 0)
            {
                FiltroReportesCiudadanos.IdTipoReporteCiudadano = idTipoReportesss;
            }
            response = await selectReportesaCiudadnos.SelectAll(Sesion.TokenAcceso, FiltroReportesCiudadanos);
            if (response.Status.Exito == 1)
            {
                ReportesCiudadanos = response.Data;
                if (idRol == 10)
                {
                    for (int i = ReportesCiudadanos.Count - 1; i >= 0; i--)
                    {
                        if (ReportesCiudadanos[i].IdTipoReporteCiudadano == 2)
                        {
                            ReportesCiudadanos.RemoveAt(i);
                        }
                    }
                }
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
                DescargarArchivosEvidenciaSolucion();
                DescargarArchivosEvidencia();
            }
            else
            {
                alerta = response.Status.Mensaje;
                banderaLoader = false;
            }
            banderaLoader = false;
            StateHasChanged();
        }
        


        private async Task DescargarArchivosExcel(List<ReporteCiudadano> reportesCiudadanos)
        {

            try
            {
                //FiltroReportesCiudadanos.Pagina = 0;
                if (reportesCiudadanos != null && reportesCiudadanos.Count > 0)
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Reportes Ciudadanos");

                        // Añadir encabezados
                        worksheet.Cells["A1"].Value = "ID";
                        worksheet.Cells["B1"].Value = "Tipo";
                        worksheet.Cells["C1"].Value = "Observaciones";
                        worksheet.Cells["D1"].Value = "Descripcion";
                        worksheet.Cells["E1"].Value = "Fecha";
                        worksheet.Cells["F1"].Value = "Direccion";
                        worksheet.Cells["G1"].Value = "Latitud";
                        worksheet.Cells["H1"].Value = "Longitud";
                        worksheet.Cells["I1"].Value = "Estatus";
                        ////worksheet.Cells["E1"].Value = "Observaciones";
                        // Añadir más columnas según sea necesario

                        // Llena los datos
                        for (int i = 0; i < reportesCiudadanos.Count; i++)
                        {
                            direccion = $"{reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Colonia}, {reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Calle}, {reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Numero}, {reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.CodigoPostal}, {reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Localidad}";
                            estatus = ObtenerEstatus(reportesCiudadanos[i].IdReporteCiudadano);

                            worksheet.Cells[i + 2, 1].Value = reportesCiudadanos[i].IdReporteCiudadano;
                            worksheet.Cells[i + 2, 2].Value = reportesCiudadanos[i].TipoReporteCiudadano.TipoReporte;
                            worksheet.Cells[i + 2, 3].Value = reportesCiudadanos[i].Observaciones;
                            worksheet.Cells[i + 2, 4].Value = reportesCiudadanos[i].VercionesReporteCiudadano[0].Descripcion;
                            worksheet.Cells[i + 2, 5].Value = reportesCiudadanos[i].VercionesReporteCiudadano[0].FechaReporte.ToString("dd/MM/yyyy");
                            worksheet.Cells[i + 2, 6].Value = direccion;
                            worksheet.Cells[i + 2, 7].Value = reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Latitud;
                            worksheet.Cells[i + 2, 8].Value = reportesCiudadanos[i].VercionesReporteCiudadano[0].DireccionReporteCiudadano.Longitud;
                            worksheet.Cells[i + 2, 9].Value = estatus;
                        }

                        // Guarda el archivo y lo descarga
                        await modulo.InvokeVoidAsync("SaveFile", "Reportes_Ciudadanos.xlsx", Convert.ToBase64String(package.GetAsByteArray()));
                    }
                    alertaDescarga = "Exito";
                }
                else
                {
                    alertaDescarga = "Ocurrio un error";
                }
            }
            catch (Exception ex)
            {
                alertaDescarga = ex.Message;
            }
            StateHasChanged(); 
            await Task.Delay(8000);
            alertaDescarga = "";
            //FiltroReportesCiudadanos.MaximoElementos = int.MaxValue;
            StateHasChanged();
        }

        private string ObtenerEstatus(int idReporteCiudadano)
        {
            var reporte = ReportesCiudadanos.FirstOrDefault(r => r.IdReporteCiudadano == idReporteCiudadano);
            if (reporte != null)
            {
                var estatusReporte = EstatusReporteCiudadanos.FirstOrDefault(e => e.IdEstatusReporteCiudadano == reporte.IdEstatusReporteCiudadano);
                if (estatusReporte != null)
                {
                    estatus = estatusReporte.Estatus;
                }
            }

            return estatus;
        }

        

       
        private async void ConsultarEstatus()
        {
            Response<List<EstatusReporteCiudadano>> response = new Response<List<EstatusReporteCiudadano>>();
            SelectEstatusReporteCiudadano selectEstatusReporteCiudadano = new SelectEstatusReporteCiudadano(Cliente);
            response = await selectEstatusReporteCiudadano.SelectAll();
            if (response.Status.Exito == 1)
            {
                EstatusReporteCiudadanos = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async Task ConsultarTipos()
        {
            Response<List<TipoReporteCiudadano>> response = new Response<List<TipoReporteCiudadano>>();
            SelectTiposReportesCiudadanos selectTiposReportesCiudadanos = new SelectTiposReportesCiudadanos(Cliente);
            response = await selectTiposReportesCiudadanos.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposReportesCiudadanos = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarArchivosEvidencia()
        {
            if (ReportesCiudadanos != null)
            {
                for (int i = 0; i < ReportesCiudadanos.Count; i++)
                {
                    if (ReportesCiudadanos[i].VercionesReporteCiudadano != null && ReportesCiudadanos[i].VercionesReporteCiudadano.Count > 0)
                    {
                        if (ReportesCiudadanos[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano != null)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DowloadEvidenciasResporteCiudadano dowloadEvidenciasResporteCiudadano = new DowloadEvidenciasResporteCiudadano(Cliente);
                            response = await dowloadEvidenciasResporteCiudadano.Dowload(ReportesCiudadanos[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano[0].Ruta, Sesion.TokenAcceso, ReportesCiudadanos[i].VercionesReporteCiudadano[0].IdVercionReporteCiudadano);
                            if (response.Status.Exito == 1)
                            {
                                ReportesCiudadanos[i].VercionesReporteCiudadano[0].EvidenciasReporteCiudadano[0].Ruta = Convert.ToBase64String(response.Data);
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
            if (ReportesCiudadanos != null)
            {
                for (int i = 0; i < ReportesCiudadanos.Count; i++)
                {
                    if (ReportesCiudadanos[i].EvidenciasSolucionReporteCiudadano != null)
                    {
                        for (int j = 0; j < ReportesCiudadanos[i].EvidenciasSolucionReporteCiudadano.Count; j++)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DowloadEvidenciasSolucionResporteCiudadano dowloadEvidenciasSolucionResporteCiudadano = new DowloadEvidenciasSolucionResporteCiudadano(Cliente);
                            response = await dowloadEvidenciasSolucionResporteCiudadano.Dowload(ReportesCiudadanos[i].EvidenciasSolucionReporteCiudadano[j].Ruta, Sesion.TokenAcceso, ReportesCiudadanos[i].IdReporteCiudadano);
                            if (response.Status.Exito == 1)
                            {
                                ReportesCiudadanos[i].EvidenciasSolucionReporteCiudadano[j].Ruta = Convert.ToBase64String(response.Data);
                            }
                            StateHasChanged();
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private async void ActualizarFiltro(FiltroReportesCiudadanos filtro)
        {
            ReportesCiudadanos = new List<ReporteCiudadano>();
            StateHasChanged();
            FiltroReportesCiudadanos = filtro;
            ConsultarReporteCiudadano();
            StateHasChanged();
        }

        private async void CambiarPaginaActual(int page)
        {
            ReportesCiudadanos = new List<ReporteCiudadano>();
            StateHasChanged();
            paginaActual = page;
            FiltroReportesCiudadanos.Pagina = paginaActual;
            StateHasChanged();
            ConsultarReporteCiudadano();
        }

        private async void ActualizacionVistaEstatus(ReporteCiudadano reporteCiudadano)
        {
            for (int i = 0; i < ReportesCiudadanos.Count; i++)
            {
                if (ReportesCiudadanos[i].IdReporteCiudadano == reporteCiudadano.IdReporteCiudadano)
                {
                    ReportesCiudadanos[i] = reporteCiudadano;
                }
            }
            List<ReporteCiudadano> ReportesCiudadanosAux = ReportesCiudadanos;
            ReportesCiudadanos = new List<ReporteCiudadano>();
            StateHasChanged();
            await Task.Delay(100);
            ReportesCiudadanos = ReportesCiudadanosAux;
            StateHasChanged();
        }

        private void openModalDetalles(int idReporte)
        {
            idReporteCiudadano = idReporte;
            openCloseModalDetalles();

        }

        private void openCloseModalDetalles()
        {
            if (banderamodal)
            {
                banderamodal = false;
            }
            else
            {
                banderamodal = true;
            }
            StateHasChanged();
        }

        private void IrNuevaNoticia()
        {
            NavigationManager.NavigateTo("/Noticias/Nueva");
        }
    }
}
