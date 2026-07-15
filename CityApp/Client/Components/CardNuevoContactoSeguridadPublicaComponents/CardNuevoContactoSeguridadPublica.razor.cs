using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevaContactoSeguridadPublicaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNuevoContactoSeguridadPublicaComponents
{
    public partial class CardNuevoContactoSeguridadPublica
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private ContactoSeguridadPublica ContactoSeguridadPublica = new ContactoSeguridadPublica();
        private List<TipoAtencionContacto> TiposAtencionesContacto = new List<TipoAtencionContacto>();

        private string alerta = "";

        private string medio = "";
        private string descripcion = "";
        private int idTipoAtencion = 0;
        private string medioError = "";
        private string descripcionError = "";
        private string idTipoAtencionError = "";

        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {
            ConsultarTiposAtenciones();
        }

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

        private async void ConsultarTiposAtenciones()
        {
            Response<List<TipoAtencionContacto>> response = new Response<List<TipoAtencionContacto>>();
            SelectTiposAtencionesContacto selectTiposAtencionesContacto = new SelectTiposAtencionesContacto(Cliente);
            response = await selectTiposAtencionesContacto.SelectAll();
            if(response.Status.Exito == 1)
            {
                TiposAtencionesContacto = response.Data;
            }
            StateHasChanged();
        }

        private void TxtMedio(ChangeEventArgs args)
        {
            medio = args.Value.ToString();
            if (medio != "")
            {
                medioError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(medio))
                {
                    medioError = "";
                    ContactoSeguridadPublica.Numero = medio;
                }
                else
                {
                    medioError = "NoCaracteresEspeciales";
                    medio = "";
                    ContactoSeguridadPublica.Numero = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtDescripcion(ChangeEventArgs args)
        {
            descripcion = args.Value.ToString();
            if (descripcion != "")
            {
                descripcionError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(descripcion))
                {
                    descripcionError = "";
                    ContactoSeguridadPublica.Descripcion = descripcion;
                }
                else
                {
                    descripcionError = "NoCaracteresEspeciales";
                    descripcion = "";
                    ContactoSeguridadPublica.Descripcion = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtIdTipoAtencion(ChangeEventArgs args)
        {
            idTipoAtencion = int.Parse(args.Value.ToString());
            if (idTipoAtencion != 0)
            {
                idTipoAtencionError = "";
                ContactoSeguridadPublica.IdTipoAtencionContacto = idTipoAtencion;
            }
            else
            {
                idTipoAtencionError = "SeleccioneOpcion";
                ContactoSeguridadPublica.IdTipoAtencionContacto = 0;
            }

            StateHasChanged();
        }

        private async void Crear()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();
                if (ContactoSeguridadPublica.Numero != "NA" && ContactoSeguridadPublica.Numero != "")
                {
                    if (ContactoSeguridadPublica.Descripcion != "NA" && ContactoSeguridadPublica.Descripcion != "")
                    {
                        if(ContactoSeguridadPublica.IdTipoAtencionContacto != 0)
                        {
                            Response<object> response = new Response<object>();
                            InsertContactoSeguridadPublicaLogic insertContactoSeguridadPublicaLogic = new InsertContactoSeguridadPublicaLogic(Cliente);
                            response = await insertContactoSeguridadPublicaLogic.Insert(Sesion.TokenAcceso, ContactoSeguridadPublica);
                            if (response.Status.Exito == 1)
                            {
                                NavigationManager.NavigateTo("/SeguridadPublica/ContactosSeguridadPublica");
                            }
                            else
                            {
                                alerta = response.Status.Mensaje;
                            }
                            banderaBoton = false;
                        }
                        else
                        {
                            idTipoAtencionError = "SeleccioneOpcion";
                        }
                    }
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
