using Blazored.LocalStorage;
using CityApp.Client.Logic.ModalCargaExcelPredioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CityApp.Client.Components.ModalCargaExcelPredioComponents
{
    public partial class ModalCargaExcelPredio
    {
        [Parameter] public string TokenSesion { get; set; } = "";
        [Parameter] public EventCallback<int> OpenCloseModal { get; set; }
        [Inject] private HttpClient cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private HistoricoPredio HistoricoPredio = new HistoricoPredio();

        private Validaciones Validaciones = new Validaciones();


        private int IdHistorico = 0;
        private string Archivo = "";
        private string ArchivoError = "";
        private string alerta = "";
        private string section1 = "";
        private string section2 = "no_view";

        private string notaActualizacion = "";
        private string notaActualizacionError = "";


        private void TxtNotaActualizacion(ChangeEventArgs args)
        {
            notaActualizacion = args.Value.ToString();
            if (notaActualizacion != "")
            {
                notaActualizacionError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(notaActualizacion))
                {
                    notaActualizacionError = "";
                    HistoricoPredio.NotaActualizacion = notaActualizacion;
                }
                else
                {
                    notaActualizacionError = "NoCaracteresEspeciales";
                    notaActualizacion = "";
                    HistoricoPredio.NotaActualizacion = "NA";
                }
            }
            StateHasChanged();
        }

        private async void SelectExcel(InputFileChangeEventArgs args)
        {
            ArchivoError = "";
            StateHasChanged();
            UploadExcelPredio uploadExcel = new UploadExcelPredio(cliente);
            IBrowserFile archivo = args.File;
            bool primerArchivo = true;
            if (primerArchivo)
            {
                primerArchivo = false;
                if (archivo != null)
                {
                    using (var ms = archivo.OpenReadStream(archivo.Size))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(archivo.Size)), "file", archivo.Name);

                        Response<string> response = await uploadExcel.Upload(content, IdHistorico,  TokenSesion);
                        if (response.Status.Exito == 1)
                        {
                            Archivo = response.Data;

                        }
                        else
                        {
                            ArchivoError = response.Status.Mensaje;
                        }
                    }
                }
            }
            StateHasChanged();
        }


        public async void CrearHistorico()
        {
            HistoricoPredio.FechaHistorico = Fecha.GetFechaMx();
            Response<int> response = new Response<int>();
            InsertHistoricoPredio insertHistoricoPredio = new InsertHistoricoPredio(cliente);
            response = await insertHistoricoPredio.Insert(TokenSesion, HistoricoPredio);
            if(response.Status.Exito == 1)
            {
                IdHistorico = response.Data;
                section1 = "no_view";
                section2 = "";
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        public async void CancelarProceso()
        {
            if(IdHistorico != 0)
            {
                Response<object> response = new Response<object>();
                DeleteHistoricoPredio deleteHistoricoPredio = new DeleteHistoricoPredio(cliente);
                response = await deleteHistoricoPredio.Delete(TokenSesion, IdHistorico);
                if(response.Status.Exito == 1)
                {
                    if(Archivo != "")
                    {
                        OpenCloseModal.InvokeAsync();
                        //Response<object> responseDeleteArchivo = new Response<object>();
                        //DeleteArchivoHistoricoPredio deleteArchivoHistoricoPredio = new DeleteArchivoHistoricoPredio(cliente);
                        //responseDeleteArchivo = await deleteArchivoHistoricoPredio.Delete(TokenSesion, IdHistorico);
                        //if (responseDeleteArchivo.Status.Exito == 1)
                        //{
                        //    OpenCloseModal.InvokeAsync();
                        //}
                        //else
                        //{
                        //    ArchivoError = responseDeleteArchivo.Status.Mensaje;
                        //}
                    }
                    else
                    {
                        OpenCloseModal.InvokeAsync();
                    }
                }
                else
                {
                    alerta = response.Status.Mensaje;
                }
            }
            else
            {
                OpenCloseModal.InvokeAsync();
            }
            StateHasChanged();
        }

        private async void Guardar()
        {
            Response<object> response = new Response<object>();
            UpdatePrediosExcel updatePrediosExcel = new UpdatePrediosExcel(cliente);
            response = await updatePrediosExcel.Update(TokenSesion, Archivo);
            if (response.Status.Exito == 1)
            {
                DeleteTercerArchivoPredio deleteTercerArchivoPredio = new DeleteTercerArchivoPredio(cliente);
                response = await deleteTercerArchivoPredio.Delete(TokenSesion);
                if (response.Status.Exito == 1)
                {
                    OpenCloseModal.InvokeAsync();
                }
                else
                {
                    alerta = response.Status.Mensaje;
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
