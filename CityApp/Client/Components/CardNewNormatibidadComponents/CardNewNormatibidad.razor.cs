using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevaNormatividadLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CityApp.Client.Components.CardNewNormatibidadComponents
{
    public partial class CardNewNormatibidad
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Normatividad Normatividad = new Normatividad();

        private string alerta = "";

        private string titulo = "";
        private string archivoCarga = "";
        private string errortitulo = "";
        private string errorArchivo = "";

        private bool banderaBoton = false;

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
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
                Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
                StateHasChanged();
            }
        }

        private void TxtTitulo(ChangeEventArgs args)
        {
            titulo = args.Value.ToString();
            if (titulo != "")
            {
                errortitulo = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(titulo))
                {
                    errortitulo = "";
                    Normatividad.Nombre = titulo;
                }
                else
                {
                    errortitulo = "NoCaracteresEspeciales";
                    titulo = "";
                    Normatividad.Nombre = "NA";
                }
            }
            StateHasChanged();
        }

        private async void CargarArchivo(InputFileChangeEventArgs args)
        {;
            UploadArchivo uploadArchivo = new UploadArchivo(Cliente);
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

                        Response<string> response = await uploadArchivo.Upload(Sesion.TokenAcceso, content);
                        if (response.Status.Exito == 1)
                        {
                            archivoCarga = response.Data;
                            Normatividad.Archivo = archivoCarga;

                        }
                        else
                        {
                            errorArchivo = response.Status.Mensaje;
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private async void Crear()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();
                if (Normatividad.Nombre != "NA" && Normatividad.Nombre != "")
                {
                    Response<object> response = new Response<object>();
                    InsertNormatividadLogic insertNormatividadLogic = new InsertNormatividadLogic(Cliente);
                    response = await insertNormatividadLogic.Insert(Sesion.TokenAcceso, Normatividad);
                    if (response.Status.Exito == 1)
                    {
                        NavigationManager.NavigateTo("/SeguridadPublica/Normatividades");
                    }
                    else
                    {
                        alerta = response.Status.Mensaje;
                    }
                    banderaBoton = false;
                    StateHasChanged();
                }
            }
            else
            {
                alerta = "Actual mente hay un proceso en ejecución, espere a que termine.";
            }
            StateHasChanged();
        }
    }
}
