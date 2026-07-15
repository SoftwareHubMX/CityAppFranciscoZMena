using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarTramiteLogic;
using CityApp.Client.Logic.CardNewTramiteLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarTramiteComponents
{
    public partial class CardEditarTramite
    {
        [Parameter] public int IdTramite { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Tramite Tramite = new Tramite();
        private Dependencia dependencia = new Dependencia();
        private Secretaria secretaria = new Secretaria();
        private List<Secretaria> Secretarias = new List<Secretaria>();
        private List<Dependencia> Dependencias = new List<Dependencia>();
        private List<TipoTramite> TiposTramite = new List<TipoTramite>();


        private string alerta = "";

        private int idSecretarias = 0;
        private string nombreSecretaria = "";
        private int idDependencias = 0;
        private string nombreDependencia = "";
        private int idTiposTramite = 0;

        private string observaciones = "";
        private string concepto = "";
        private string descripcion = "";
        private string direccion = "";
        private string telefono = "";
        private string requisitos = "";
        private double costo = 0;
        private double latitud = 0;
        private double longitud = 0;

        private string ObservacionesError = "";
        private string errorConcepto = "";
        private string errorDescripcion = "";
        private string errorDireccion = "";
        private string telefonoError = "";
        private string requisitosError = "";
        private string costoError = "";
        private string latitudError = "";
        private string longitudError = "";

        private string errorIdSecretaria = "";
        private string errorIdDependencia = "";
        private string errorIdTipoTramite = "";


        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {

            await ConsultarSecretarias();
            //ConsultarDependencias();
            await ConsultarTiposTramite();
            await ConsultarTramite();
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
                if (Sesion != null)
                {
                    ConsultarTramite();
                }
                StateHasChanged();
            }
        }

        private async Task ConsultarSecretarias()
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();
            SelectSecretariasLogic selectSecretariasLogic = new SelectSecretariasLogic(Cliente);
            response = await selectSecretariasLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                Secretarias = response.Data;
            }
            StateHasChanged();
        }

        private async Task ConsultarDependencias()
        {
            if (idSecretarias <= 0)
            {
                Dependencias = new List<Dependencia>();
                return;
            }

            Dependencias = new List<Dependencia>();
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();
            SelectDependenciasLogic selectDependenciasLogic = new SelectDependenciasLogic(Cliente);
            response = await selectDependenciasLogic.SelectAll(idSecretarias);
            if (response.Status.Exito == 1)
            {
                Dependencias = response.Data;
            }
            StateHasChanged();
        }
        private async Task ConsultarTiposTramite()
        {
            Response<List<TipoTramite>> response = new Response<List<TipoTramite>>();
            SelectTiposTramiteLogic selectTiposTramiteLogic = new SelectTiposTramiteLogic(Cliente);
            response = await selectTiposTramiteLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposTramite = response.Data;
            }
            StateHasChanged();
        }

        private async Task ConsultarTramite()
        {
            Response<Tramite> response = new Response<Tramite>();
            SelectTramiteLogic selectBolsaTrabajoLogic = new SelectTramiteLogic(Cliente);
            response = await selectBolsaTrabajoLogic.Select(Sesion.TokenAcceso, IdTramite);
            if (response.Status.Exito == 1)
            {
                Tramite = response.Data;
                concepto = Tramite.Concepto;
                descripcion = Tramite.Descripcion;
                direccion = Tramite.Direccion;
                telefono = Tramite.Telefono;
                requisitos = Tramite.Requisitos;
                costo = Tramite.Costo;
                observaciones = Tramite.Observaciones;

                // IMPORTANTE: Inicializar coordenadas correctamente
                latitud = Tramite.Latitud > 0 ? Tramite.Latitud : 0;
                longitud = Tramite.Longitud != 0 ? Tramite.Longitud : 0;

                idTiposTramite = Tramite.IdTipoTramite;
                idDependencias = Tramite.IdDependencia;

                if (Tramite.Dependencia != null)
                {
                    nombreDependencia = Tramite.Dependencia.NombreDependencia;
                    idSecretarias = Tramite.Dependencia.IdSecretaria;

                    await ConsultarDependencias();

                    if (Tramite.Dependencia.Secretaria != null)
                    {
                        nombreSecretaria = Tramite.Dependencia.Secretaria.NombreSecretaria;
                    }
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }


        private void TxtConcepto(ChangeEventArgs args)
        {
            concepto = args.Value.ToString();
            if (concepto != "")
            {
                errorConcepto = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(concepto))
                {
                    errorConcepto = "";
                    Tramite.Concepto = concepto;
                }
                else
                {
                    errorConcepto = "NoCaracteresEspeciales";
                    concepto = "";
                    Tramite.Concepto = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtDescipcion(ChangeEventArgs args)
        {
            descripcion = args.Value.ToString();
            if (descripcion != "")
            {
                errorDescripcion = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(descripcion))
                {
                    errorDescripcion = "";
                    Tramite.Descripcion = descripcion;
                }
                else
                {
                    errorDescripcion = "NoCaracteresEspeciales";
                    descripcion = "";
                    Tramite.Descripcion = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtObservaciones(ChangeEventArgs args)
        {
            observaciones = args.Value.ToString();
            if (observaciones != "")
            {
                ObservacionesError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(observaciones))
                {
                    ObservacionesError = "";
                    Tramite.Observaciones = observaciones;
                }
                else
                {
                    ObservacionesError = "NoCaracteresEspeciales";
                    observaciones = "";
                    Tramite.Observaciones = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtDireccion(ChangeEventArgs args)
        {
            direccion = args.Value.ToString();
            if (direccion != "")
            {
                errorDireccion = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(direccion))
                {
                    errorDireccion = "";
                    Tramite.Direccion = direccion;
                }
                else
                {
                    errorDireccion = "NoCaracteresEspeciales";
                    direccion = "";
                    Tramite.Direccion = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtIdSecretaria(ChangeEventArgs args)
        {
            try
            {
                int nuevoId = int.Parse(args.Value?.ToString() ?? "0");
                if (nuevoId != idSecretarias)
                {
                    idSecretarias = nuevoId;
                    if (idSecretarias != 0)
                    {
                        errorIdSecretaria = "";
                        idDependencias = 0;
                        Tramite.IdDependencia = 0;
                        _ = ConsultarDependencias();
                    }
                    else
                    {
                        errorIdSecretaria = "SeleccioneOpcion";
                        Dependencias = new List<Dependencia>();
                        idDependencias = 0;
                        Tramite.IdDependencia = 0;
                    }
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                errorIdSecretaria = "Error al seleccionar secretaria: " + ex.Message;
                StateHasChanged();
            }
        }

        private void TxtIdDependencia(ChangeEventArgs args)
        {
            try
            {
                idDependencias = int.Parse(args.Value?.ToString() ?? "0");
                if (idDependencias != 0)
                {
                    errorIdDependencia = "";
                    Tramite.IdDependencia = idDependencias;
                }
                else
                {
                    errorIdDependencia = "SeleccioneOpcion";
                    Tramite.IdDependencia = 0;
                }
                StateHasChanged();
            }
            catch (Exception ex)
            {
                errorIdDependencia = "Error al seleccionar dependencia: " + ex.Message;
                StateHasChanged();
            }
        }

        private void TxtIdTipoTramite(ChangeEventArgs args)
        {
            idTiposTramite = int.Parse(args.Value.ToString());
            if (idTiposTramite != 0)
            {
                errorIdTipoTramite = "";
                Tramite.IdTipoTramite = idTiposTramite;
            }
            else
            {
                errorIdTipoTramite = "SeleccioneOpcion";
                Tramite.IdTipoTramite = 0;
            }

            StateHasChanged();
        }

        private void TxtTelefono(ChangeEventArgs args)
        {
            telefono = args.Value.ToString();
            if (telefono != "")
            {
                telefonoError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(telefono))
                {
                    telefonoError = "";
                    Tramite.Telefono = telefono;
                }
                else
                {
                    telefonoError = "NoCaracteresEspeciales";
                    telefono = "";
                    Tramite.Telefono = "NA";
                }
            }
            StateHasChanged();
        }

        //private void TxtTelefono(ChangeEventArgs args)
        //{
        //    telefono = args.Value.ToString();
        //    if (telefono != "")
        //    {
        //        telefonoError = "";
        //        StateHasChanged();
        //        if (Validaciones.ValidarCaracteres(telefono))
        //        {
        //            if (Validaciones.ValidarTelefono(telefono))
        //            {
        //                telefonoError = "";
        //                Tramite.Telefono = telefono;
        //            }
        //            else
        //            {
        //                telefonoError = "MaximoTelefono";
        //                telefono = telefono.Substring(0, (telefono.Length - 2));
        //            }

        //        }
        //        else
        //        {
        //            telefonoError = "NoCaracteresEspeciales";
        //            telefono = "";
        //            Tramite.Telefono = "NA";
        //        }
        //    }
        //    StateHasChanged();
        //}

        private void TxtRequisitos(ChangeEventArgs args)
        {
            requisitos = args.Value.ToString();
            if (requisitos != "")
            {
                requisitosError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(requisitos))
                {
                    requisitosError = "";
                    Tramite.Requisitos = requisitos;
                }
                else
                {
                    requisitosError = "NoCaracteresEspeciales";
                    requisitos = "";
                    Tramite.Requisitos = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtCosto(ChangeEventArgs args)
        {
            try
            {
                costo = double.Parse(args.Value.ToString());
                costoError = "";
                Tramite.Costo = costo;
            }
            catch (Exception e)
            {
                costoError = "Ingresa un valor";
                Tramite.Costo = 0;
            }
            StateHasChanged();
        }

        private void ActualizarLatitud()
        {
            try
            {
                // Si está vacío o es 0, dejar pasar
                if (latitud == 0 || double.IsNaN(latitud))
                {
                    latitudError = "";
                    Tramite.Latitud = 0;
                    return;
                }

                // Validar rango
                if (latitud >= -90 && latitud <= 90)
                {
                    latitudError = "";
                    Tramite.Latitud = latitud;
                }
                else
                {
                    latitudError = "Latitud debe estar entre -90 y 90";
                    Tramite.Latitud = 0;
                }
            }
            catch (Exception ex)
            {
                latitudError = "Error: " + ex.Message;
                Tramite.Latitud = 0;
            }
            StateHasChanged();
        }

        private void ActualizarLongitud()
        {
            try
            {
                // Si está vacío o es 0, dejar pasar
                if (longitud == 0 || double.IsNaN(longitud))
                {
                    longitudError = "";
                    Tramite.Longitud = 0;
                    return;
                }

                // Validar rango
                if (longitud >= -180 && longitud <= 180)
                {
                    longitudError = "";
                    Tramite.Longitud = longitud;
                }
                else
                {
                    longitudError = "Longitud debe estar entre -180 y 180";
                    Tramite.Longitud = 0;
                }
            }
            catch (Exception ex)
            {
                longitudError = "Error: " + ex.Message;
                Tramite.Longitud = 0;
            }
            StateHasChanged();
        }



        private async void ActualizarTramite()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();

                Tramite.Latitud = latitud;
                Tramite.Longitud = longitud;

                if (Tramite.Concepto != "NA" && Tramite.Concepto != "")
                {
                    if (Tramite.Descripcion != "NA" && Tramite.Descripcion != "")
                    {
                        if (Tramite.IdDependencia != 0)
                        {
                            if (Tramite.IdTipoTramite != 0)
                            {
                                Response<object> response = new Response<object>();
                                UpdateTramiteLogic updateTramiteLogic = new UpdateTramiteLogic(Cliente);
                                response = await updateTramiteLogic.Update(Sesion.TokenAcceso, Tramite);
                                if (response.Status.Exito == 1)
                                {
                                    NavigationManager.NavigateTo("/TramitesServicios/Tramites");
                                }
                                else
                                {
                                    alerta = response.Status.Mensaje;
                                }
                                StateHasChanged();
                            }
                            else
                            {
                                errorIdTipoTramite = "SeleccioneOpcion";
                            }
                        }
                        else
                        {
                            errorIdDependencia = "SeleccioneOpcion";
                        }
                    }
                    else
                    {
                        errorConcepto = "CampoRequerido";
                    }
                }
                else
                {
                    errorConcepto = "CampoRequerido";
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
