using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditRutaRecoleccionLogic;
using CityApp.Client.Logic.CardNewRutaRecoleccionLogic;
using CityApp.Client.Logic.TablaRutaRecoleccionLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditRutaRecoleccionComponents
{
    public partial class CardEditRutaRecoleccion
    {
        [Parameter] public int IdRutaRecoleccion { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private RutaRecoleccion RutaRecoleccion = new RutaRecoleccion();

        private List<Colonia> Colonias = new List<Colonia>();

        private List<ColoniaRutaRecoleccion> ColoniaRutaRecoleccions = new List<ColoniaRutaRecoleccion>();
        private ColoniaRutaRecoleccion ColoniaRutaRecoleccion = new ColoniaRutaRecoleccion();

        private List<RutaRecoleccion> RutasRecoleccion = new List<RutaRecoleccion>();

        private List<Cuenta> Cuentas = new List<Cuenta>();

        private List<DiaRuta> DiasRuta = new List<DiaRuta>();
        private DiaRuta DiaRuta = new DiaRuta();

        private int idCuenta = 0;
        private string idCuentaError = "";
        private Colonia Colonia = new Colonia();


        private string alerta = "";

        private int idDiaRuta = 0;
        private int idColonia = 0;

        private string TextoColonia = "";
        private string TextoDia = "";

        private int idRutaRecoleccion = 0;


        private string concesionario = "";
        private string descripcion = "";
        private string nombreRuta = "";
        private string horario = "";

        private string errorIdColonia = "";
        private string errorIdDiaRuta = "";
        private string errorIdRutaRecoleccion = "";
        private string errorConcesionario = "";
        private string errorDescripcion = "";
        private string errorNombreRuta = "";
        private string errorHorario = "";

        private int RutaRecoleccionAgregar = 0;

        private string carrusel1 = "";
        private string carrusel2 = "no_view";
        private string carrusel3 = "no_view";


        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {

            ConsultarColonias();

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
                    ConsultarRuta();
                    ConsultarCuentas();
                }
                StateHasChanged();
            }
        }

        private async void ConsultarRuta()
        {
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();
            SelectRutaRecoleccionLogic selectRutaRecoleccionLogic = new SelectRutaRecoleccionLogic(Cliente);
            response = await selectRutaRecoleccionLogic.Select(Sesion.TokenAcceso, IdRutaRecoleccion);
            if (response.Status.Exito == 1)
            {
                RutaRecoleccion = response.Data;
                idCuenta = RutaRecoleccion.IdCuenta;
                concesionario = RutaRecoleccion.Concecionario;
                descripcion = RutaRecoleccion.Descripcion;
                nombreRuta = RutaRecoleccion.NombreRuta;
                horario = RutaRecoleccion.Horario;
                ColoniaRutaRecoleccions = RutaRecoleccion.ColoniaRutaRecolecciones ?? new List<ColoniaRutaRecoleccion>();
                DiasRuta = RutaRecoleccion.DiasRuta ?? new List<DiaRuta>();
            }
            StateHasChanged();
        }
        private async void ConsultarCuentas()
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();
            SelectCuentasLogic selectCuentasLogic = new SelectCuentasLogic(Cliente);
            response = await selectCuentasLogic.SelectAll(Sesion.TokenAcceso);
            if (response.Status.Exito == 1)
            {
                Cuentas = response.Data;
            }
            StateHasChanged();
        }
        private async void ConsultarColonias()
        {
            Response<List<Colonia>> response = new Response<List<Colonia>>();
            SelectColoniasLogic selectColoniasLogic = new SelectColoniasLogic(Cliente);
            response = await selectColoniasLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                Colonias = response.Data;
            }
            StateHasChanged();
        }


        public void SelectCuenta(ChangeEventArgs args)
        {
            idCuenta = int.Parse(args.Value.ToString());
            if (idCuenta != 0)
            {
                idCuentaError = "";
                RutaRecoleccion.IdCuenta = idCuenta;
            }
            else
            {
                idCuentaError = "seleccione una opción";
            }
            StateHasChanged();
        }
        private void SelectColonia(ChangeEventArgs args)
        {
            try
            {
                idColonia = int.Parse(args.Value.ToString());
                if (idColonia != 0)
                {
                    errorIdColonia = "";
                    ColoniaRutaRecoleccion.IdColonia = idColonia;
                    foreach (var coloniaRutaRecoleccion in Colonias)
                    {
                        if (coloniaRutaRecoleccion.IdColonia == idColonia)
                        {

                            ColoniaRutaRecoleccion.Colonia = coloniaRutaRecoleccion;
                            break;
                        }
                    }
                }
                else
                {
                    errorIdColonia = "seleccione una opción";
                }
            }
            catch (Exception ex)
            {
                errorIdColonia = "seleccione una opción";
            }
            StateHasChanged();
        }
        private void SelectDia(ChangeEventArgs args)
        {
            try
            {
                idDiaRuta = int.Parse(args.Value.ToString());
                if (idDiaRuta != 0)
                {
                    errorIdDiaRuta = "";
                    string[] diasSeleccionados = new string[] { };

                    switch (idDiaRuta)
                    {
                        case 1: diasSeleccionados = new string[] { "Domingo" }; break;
                        case 2: diasSeleccionados = new string[] { "Lunes" }; break;
                        case 3: diasSeleccionados = new string[] { "Martes" }; break;
                        case 4: diasSeleccionados = new string[] { "Miércoles" }; break;
                        case 5: diasSeleccionados = new string[] { "Jueves" }; break;
                        case 6: diasSeleccionados = new string[] { "Viernes" }; break;
                        case 7: diasSeleccionados = new string[] { "Sábado" }; break;
                    }
                    DiaRuta.Dias = string.Join(" / ", diasSeleccionados);
                    //DiaRuta.Dias = (idDiaRuta == 0) ? "Domingo" :
                    //    (idDiaRuta == 1) ? "Lunes" :
                    //    (idDiaRuta == 2) ? "Martes" :
                    //    (idDiaRuta == 3) ? "Miercoles" :
                    //    (idDiaRuta == 4) ? "Jueves" :
                    //    (idDiaRuta == 5) ? "Vienes" :
                    //    "Sabado";
                }
                else
                {
                    errorIdDiaRuta = "seleccione una opción";
                }
            }
            catch (Exception ex)
            {
                errorIdDiaRuta = "seleccione una opción";
            }
            StateHasChanged();
        }
        private void TxtConcesionario(ChangeEventArgs args)
        {
            concesionario = args.Value.ToString();
            if (concesionario != "")
            {
                errorConcesionario = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(concesionario))
                {
                    errorConcesionario = "";
                    RutaRecoleccion.Concecionario = concesionario;
                }
                else
                {
                    errorConcesionario = "NoCaracteresEspeciales";
                    concesionario = "";
                    RutaRecoleccion.Concecionario = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtDescripcion(ChangeEventArgs args)
        {
            descripcion = args.Value.ToString();
            if (descripcion != "")
            {
                errorDescripcion = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(descripcion))
                {
                    errorDescripcion = "";
                    RutaRecoleccion.Descripcion = descripcion;
                }
                else
                {
                    errorDescripcion = "NoCaracteresEspeciales";
                    descripcion = "";
                    RutaRecoleccion.Descripcion = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtNombreRuta(ChangeEventArgs args)
        {
            nombreRuta = args.Value.ToString();
            if (nombreRuta != "")
            {
                errorNombreRuta = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(nombreRuta))
                {
                    errorNombreRuta = "";
                    RutaRecoleccion.NombreRuta = nombreRuta;
                }
                else
                {
                    errorNombreRuta = "NoCaracteresEspeciales";
                    nombreRuta = "";
                    RutaRecoleccion.NombreRuta = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtHorario(ChangeEventArgs args)
        {
            horario = args.Value.ToString();
            if (horario != "")
            {
                errorHorario = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(horario))
                {
                    errorHorario = "";
                    RutaRecoleccion.Horario = horario;
                }
                else
                {
                    errorHorario = "NoCaracteresEspeciales";
                    horario = "";
                    RutaRecoleccion.Horario = "NA";
                }
            }
            StateHasChanged();
        }
        private async void AgregarDia()
        {
            DiaRuta.IdRutaRecoleccion = IdRutaRecoleccion;
            Response<object> response = new Response<object>();
            InsertDiaRutaLogic insertDiaRutaLogic = new InsertDiaRutaLogic(Cliente);
            response = await insertDiaRutaLogic.Insert(Sesion.TokenAcceso, DiaRuta);
            if (response.Status.Exito == 1)
            {

                DiasRuta.Add(DiaRuta);
                DiaRuta = new DiaRuta();
                idDiaRuta = 0;

            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
        private async void EliminarDia(DiaRuta diaRuta)
        {
            Response<object> response = new Response<object>();
            DeleteDiaRuraLogic deleteDiaRuraLogic = new DeleteDiaRuraLogic(Cliente);
            response = await deleteDiaRuraLogic.Delete(Sesion.TokenAcceso, diaRuta);
            if (response.Status.Exito == 1)
            {
                RutaRecoleccion.DiasRuta.Remove(diaRuta);
                StateHasChanged();
            }
        }

        private async void AgregarColonia()
        {
            ColoniaRutaRecoleccion.IdRutaRecoleccion = IdRutaRecoleccion;
            Response<object> response = new Response<object>();
            InsertColoniaRutaRecoleccionLogic insertColoniaLogic = new InsertColoniaRutaRecoleccionLogic(Cliente);
            response = await insertColoniaLogic.Insert(Sesion.TokenAcceso, ColoniaRutaRecoleccion);
            if (response.Status.Exito == 1)
            {

                ColoniaRutaRecoleccions.Add(ColoniaRutaRecoleccion);
                ColoniaRutaRecoleccion = new ColoniaRutaRecoleccion();
                idColonia = 0;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
        private async void EliminarColoniaRutaRecoleccion(ColoniaRutaRecoleccion colonia)
        {
            Response<object> response = new Response<object>();
            DeleteColoniaRutaRecoleccionLogic deleteColoniaRutaRecoleccionLogic = new DeleteColoniaRutaRecoleccionLogic(Cliente);
            response = await deleteColoniaRutaRecoleccionLogic.Delete(Sesion.TokenAcceso, colonia);
            if (response.Status.Exito == 1)
            {
                RutaRecoleccion.ColoniaRutaRecolecciones.Remove(colonia);
                StateHasChanged();
            }

        }

        private void Siguiente()
        {
            NavigationManager.NavigateTo("/RutasRecolecciones");
        }


        private async void ActualizarRuta()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();
                if (RutaRecoleccion.Concecionario != "NA" && RutaRecoleccion.Concecionario != "")
                {
                    if (RutaRecoleccion.Descripcion != "NA" && RutaRecoleccion.Descripcion != "")
                    {
                        if (RutaRecoleccion.NombreRuta != "NA" && RutaRecoleccion.NombreRuta != "")
                        {
                            if (RutaRecoleccion.Horario != "NA" && RutaRecoleccion.Horario != "")
                            {
                                if (RutaRecoleccion.IdCuenta != 0)
                                {
                                    Response<object> response = new Response<object>();
                                    UpdateRutaRecoleccionLogic updateRutaRecoleccionLogic = new UpdateRutaRecoleccionLogic(Cliente);
                                    response = await updateRutaRecoleccionLogic.Updata(Sesion.TokenAcceso, RutaRecoleccion);
                                    if (response.Status.Exito == 1)
                                    {
                                        carrusel1 = "no_view";
                                        carrusel2 = "";
                                        //IdRutaRecoleccion = response.Data;
                                    }
                                    else
                                    {
                                        alerta = response.Status.Mensaje;
                                    }
                                    StateHasChanged();
                                }
                                else
                                {
                                    idCuentaError = "Selecciona una Opcion";
                                }

                            }
                            else
                            {
                                errorHorario = "CampoObligatorio";
                            }
                        }
                        else
                        {
                            errorNombreRuta = "CampoObligatorio";
                        }

                    }
                    else
                    {
                        errorDescripcion = "CampoObligatorio";
                    }
                }
                else
                {
                    errorConcesionario = "CampoObligatorio";
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
