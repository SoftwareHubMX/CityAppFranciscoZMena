using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevaBolsaTrabajoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNewBolsaTrabajoComponents
{
    public partial class CarNewBolsaTrabajo
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private BolsaTrabajo BolsaTrabajo = new BolsaTrabajo();
        private List<Giro> Giros = new List<Giro>();


        private string alerta = "";

        private int idGiros = 0;

        private string puesto = "";
        private string empresa = "";
        private string escolaridad = "";
        private string especialidad = "";
        private string edad = "";
        private string sexo = "";
        private string experiencia = "";
        private string conocimientos = "";
        private string habilidades = "";
        private string funciones = "";
        private string jornada = "";
        private string sueldo = "";
        private string prestaciones = "";
        private string otrasPrestaciones = "";
        private string requisitos = "";
        private string entrevista = "";
        private string contacto = "";
        private string calle = "";
        private string numero = "";
        private string codigoPostal = "";
        private string colonia = "";
        private string localidad = "";
        private string telefono1 = "";
        private string telefono2 = "";
        private string correo = "";
        private string actividadPrincipal = "";
        private string rfc = "";
        private string plaza = "";

        private string errorIdGiro = "";

        private string errorPuesto = "";
        private string errorEmpresa = "";
        private string errorEscolaridad = "";
        private string errorEspecialidad = "";
        private string errorEdad = "";
        private string errorSexo = "";
        private string errorExperiencia = "";
        private string errorConocimientos = "";
        private string errorHabilidades = "";
        private string errorFunciones = "";
        private string errorJornada = "";
        private string errorSueldo = "";
        private string errorPrestaciones = "";
        private string errorOtrasPrestaciones = "";
        private string errorRequisitos = "";
        private string errorEntrevista = "";
        private string errorContacto = "";
        private string errorCalle = "";
        private string errorNumero = "";
        private string errorCodigoPostal = "";
        private string errorColonia = "";
        private string errorLocalidad = "";
        private string errorTelefono1 = "";
        private string errorTelefono2 = "";
        private string errorCorreo = "";
        private string errorActividadPrincipal = "";
        private string errorRfc = "";
        private string errorPlaza = "";

        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {
            ConsultarGiros();
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

        private async void ConsultarGiros()
        {
            Response<List<Giro>> response = new Response<List<Giro>>();
            SelectGirosLogic selectGirosLogic = new SelectGirosLogic(Cliente);
            response = await selectGirosLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                Giros = response.Data;
            }
            StateHasChanged();
        }

        private void TxtIdGiro(ChangeEventArgs args)
        {
            idGiros = int.Parse(args.Value.ToString());
            if (idGiros != 0)
            {
                errorIdGiro = "";
                BolsaTrabajo.IdGiro = idGiros;
            }
            else
            {
                errorIdGiro = "SeleccioneOpcion";
                BolsaTrabajo.IdGiro = 0;
            }

            StateHasChanged();
        }

        private void TxtPuesto(ChangeEventArgs args)
        {
            puesto = args.Value.ToString();
            if (puesto != "")
            {
                errorPuesto = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(puesto))
                {
                    errorPuesto = "";
                    BolsaTrabajo.Puesto = puesto;
                }
                else
                {
                    errorPuesto = "NoCaracteresEspeciales";
                    puesto = "";
                    BolsaTrabajo.Puesto = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtEmpresa(ChangeEventArgs args)
        {
            empresa = args.Value.ToString();
            if (empresa != "")
            {
                errorEmpresa = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(empresa))
                {
                    errorEmpresa = "";
                    BolsaTrabajo.Empresa = empresa;
                }
                else
                {
                    errorEmpresa = "NoCaracteresEspeciales";
                    empresa = "";
                    BolsaTrabajo.Empresa = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtEscolaridad(ChangeEventArgs args)
        {
            escolaridad = args.Value.ToString();
            if (escolaridad != "")
            {
                errorEscolaridad = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(escolaridad))
                {
                    errorEscolaridad = "";
                    BolsaTrabajo.Escolaridad = escolaridad;
                }
                else
                {
                    errorEscolaridad = "NoCaracteresEspeciales";
                    escolaridad = "";
                    BolsaTrabajo.Escolaridad = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtEspecialidad(ChangeEventArgs args)
        {
            especialidad = args.Value.ToString();
            if (escolaridad != "")
            {
                errorEspecialidad = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(especialidad))
                {
                    errorEspecialidad = "";
                    BolsaTrabajo.Especialidad = especialidad;
                }
                else
                {
                    errorEspecialidad = "NoCaracteresEspeciales";
                    especialidad = "";
                    BolsaTrabajo.Especialidad = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtEdad(ChangeEventArgs args)
        {
            edad = args.Value.ToString();
            if (edad != "")
            {
                errorEdad = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(edad))
                {
                    errorEdad = "";
                    BolsaTrabajo.Edad = edad;
                }
                else
                {
                    errorEdad = "NoCaracteresEspeciales";
                    edad = "";
                    BolsaTrabajo.Edad = "NA";
                }
            }
            StateHasChanged();
        }
        private void SelectSexo(ChangeEventArgs args)
        {
            try
            {
                sexo = args.Value.ToString(); 
                if (sexo != "")
                {
                    errorSexo = "";
                    switch (sexo)
                    {
                        case "Femenino":
                            BolsaTrabajo.Sexo = "Femenino";
                            break;
                        case "Masculino":
                            BolsaTrabajo.Sexo = "Masculino";
                            break;
                        case "Otro":
                            BolsaTrabajo.Sexo = "Otro";
                            break;
                        default:
                            BolsaTrabajo.Sexo = "No especificado"; 
                            break;
                    }
                }
                else
                {
                    errorSexo = "seleccione una opción";
                }
            }
            catch (Exception ex)
            {
                errorSexo = "seleccione una opción";
            }
            StateHasChanged();
        }


        private void TxtExperiencia(ChangeEventArgs args)
        {
            experiencia = args.Value.ToString();
            if (experiencia != "")
            {
                errorExperiencia = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(experiencia))
                {
                    errorExperiencia = "";
                    BolsaTrabajo.Experiencia = experiencia;
                }
                else
                {
                    errorExperiencia = "NoCaracteresEspeciales";
                    experiencia = "";
                    BolsaTrabajo.Experiencia = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtConocimientos(ChangeEventArgs args)
        {
            conocimientos = args.Value.ToString();
            if (conocimientos != "")
            {
                errorConocimientos = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(conocimientos))
                {
                    errorConocimientos = "";
                    BolsaTrabajo.Conocimiento = conocimientos;
                }
                else
                {
                    errorConocimientos = "NoCaracteresEspeciales";
                    conocimientos = "";
                    BolsaTrabajo.Conocimiento = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtHabilidades(ChangeEventArgs args)
        {
            habilidades = args.Value.ToString();
            if (habilidades != "")
            {
                errorHabilidades = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(habilidades))
                {
                    errorHabilidades = "";
                    BolsaTrabajo.Habilidades = habilidades;
                }
                else
                {
                    errorExperiencia = "NoCaracteresEspeciales";
                    habilidades = "";
                    BolsaTrabajo.Habilidades = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtFuciones(ChangeEventArgs args)
        {
            funciones = args.Value.ToString();
            if (funciones != "")
            {
                errorFunciones = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(funciones))
                {
                    errorFunciones = "";
                    BolsaTrabajo.Funciones = funciones;
                }
                else
                {
                    errorFunciones = "NoCaracteresEspeciales";
                    funciones = "";
                    BolsaTrabajo.Funciones = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtJornada(ChangeEventArgs args)
        {
            jornada = args.Value.ToString();
            if (jornada != "")
            {
                errorJornada = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(jornada))
                {
                    errorJornada = "";
                    BolsaTrabajo.Jornada = jornada;
                }
                else
                {
                    errorJornada = "NoCaracteresEspeciales";
                    jornada = "";
                    BolsaTrabajo.Jornada = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtSueldo(ChangeEventArgs args)
        {
            sueldo = args.Value.ToString();
            if (sueldo != "")
            {
                errorSueldo = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(sueldo))
                {
                    errorSueldo = "";
                    BolsaTrabajo.Sueldo = sueldo;
                }
                else
                {
                    errorSueldo = "NoCaracteresEspeciales";
                    sueldo = "";
                    BolsaTrabajo.Sueldo = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtPrestaciones(ChangeEventArgs args)
        {
            prestaciones = args.Value.ToString();
            if (prestaciones != "")
            {
                errorPrestaciones = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(prestaciones))
                {
                    errorPrestaciones = "";
                    BolsaTrabajo.Prestaciones = prestaciones;
                }
                else
                {
                    errorPrestaciones = "NoCaracteresEspeciales";
                    prestaciones = "";
                    BolsaTrabajo.Prestaciones = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtOtrasPrestaciones(ChangeEventArgs args)
        {
            otrasPrestaciones = args.Value.ToString();
            if (otrasPrestaciones != "")
            {
                errorOtrasPrestaciones = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(otrasPrestaciones))
                {
                    errorOtrasPrestaciones = "";
                    BolsaTrabajo.OtrasPrestaciones = otrasPrestaciones;
                }
                else
                {
                    errorOtrasPrestaciones = "NoCaracteresEspeciales";
                    otrasPrestaciones = "";
                    BolsaTrabajo.OtrasPrestaciones = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtRequisitos(ChangeEventArgs args)
        {
            requisitos = args.Value.ToString();
            if (requisitos != "")
            {
                errorRequisitos = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(requisitos))
                {
                    errorRequisitos = "";
                    BolsaTrabajo.Requisitos = requisitos;
                }
                else
                {
                    errorRequisitos = "NoCaracteresEspeciales";
                    requisitos = "";
                    BolsaTrabajo.Requisitos = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtEntrevista(ChangeEventArgs args)
        {
            entrevista = args.Value.ToString();
            if (entrevista != "")
            {
                errorEntrevista = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(entrevista))
                {
                    errorEntrevista = "";
                    BolsaTrabajo.Entrevisata = entrevista;
                }
                else
                {
                    errorEntrevista = "NoCaracteresEspeciales";
                    entrevista = "";
                    BolsaTrabajo.Entrevisata = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtContacto(ChangeEventArgs args)
        {
            contacto = args.Value.ToString();
            if (contacto != "")
            {
                errorContacto = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(contacto))
                {
                    errorContacto = "";
                    BolsaTrabajo.Contacto = contacto;
                }
                else
                {
                    errorContacto = "NoCaracteresEspeciales";
                    contacto = "";
                    BolsaTrabajo.Contacto = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtCalle(ChangeEventArgs args)
        {
            calle = args.Value.ToString();
            if (calle != "")
            {
                errorCalle = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(calle))
                {
                    errorCalle = "";
                    BolsaTrabajo.Calle = calle;
                }
                else
                {
                    errorCalle = "NoCaracteresEspeciales";
                    calle = "";
                    BolsaTrabajo.Calle = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtNumero(ChangeEventArgs args)
        {
            numero = args.Value.ToString();
            if (numero != "")
            {
                errorNumero = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(numero))
                {
                    errorNumero = "";
                    BolsaTrabajo.Numero = numero;
                }
                else
                {
                    errorNumero = "NoCaracteresEspeciales";
                    numero = "";
                    BolsaTrabajo.Numero = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtCodigoPostal(ChangeEventArgs args)
        {
            codigoPostal = args.Value.ToString();
            if (codigoPostal != "")
            {
                errorCodigoPostal = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(codigoPostal))
                {
                    errorCodigoPostal = "";
                    BolsaTrabajo.CodigoPostal = codigoPostal;
                }
                else
                {
                    errorCodigoPostal = "NoCaracteresEspeciales";
                    codigoPostal = "";
                    BolsaTrabajo.CodigoPostal = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtColonia(ChangeEventArgs args)
        {
            colonia = args.Value.ToString();
            if (colonia != "")
            {
                errorColonia = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(colonia))
                {
                    errorColonia = "";
                    BolsaTrabajo.Colonia = colonia;
                }
                else
                {
                    errorColonia = "NoCaracteresEspeciales";
                    colonia = "";
                    BolsaTrabajo.Colonia = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtLocalidad(ChangeEventArgs args)
        {
            localidad = args.Value.ToString();
            if (localidad != "")
            {
                errorLocalidad = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(localidad))
                {
                    errorLocalidad = "";
                    BolsaTrabajo.Localidad = localidad;
                }
                else
                {
                    errorLocalidad = "NoCaracteresEspeciales";
                    localidad = "";
                    BolsaTrabajo.Localidad = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtTelefono1(ChangeEventArgs args)
        {
            telefono1 = args.Value.ToString();
            if (telefono1 != "")
            {
                errorTelefono1 = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(telefono1))
                {
                    errorTelefono1 = "";
                    BolsaTrabajo.Telefono1 = telefono1;
                }
                else
                {
                    errorTelefono1 = "NoCaracteresEspeciales";
                    telefono1 = "";
                    BolsaTrabajo.Telefono1 = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtTelefono2(ChangeEventArgs args)
        {
            telefono2 = args.Value.ToString();
            if (telefono2 != "")
            {
                errorTelefono2 = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(telefono2))
                {
                    errorTelefono2 = "";
                    BolsaTrabajo.Telefono2 = telefono2;
                }
                else
                {
                    errorTelefono2 = "NoCaracteresEspeciales";
                    telefono2 = "";
                    BolsaTrabajo.Telefono2 = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtCorreo(ChangeEventArgs args)
        {
            correo = args.Value.ToString();
            if (correo != "")
            {
                errorCorreo = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(correo))
                {
                    errorCorreo = "";
                    BolsaTrabajo.Correo = correo;
                }
                else
                {
                    errorCorreo = "NoCaracteresEspeciales";
                    correo = "";
                    BolsaTrabajo.Correo = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtActividadPrincipal(ChangeEventArgs args)
        {
            actividadPrincipal = args.Value.ToString();
            if (actividadPrincipal != "")
            {
                errorActividadPrincipal = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(actividadPrincipal))
                {
                    errorActividadPrincipal = "";
                    BolsaTrabajo.ActividadPrincipal = actividadPrincipal;
                }
                else
                {
                    errorActividadPrincipal = "NoCaracteresEspeciales";
                    actividadPrincipal = "";
                    BolsaTrabajo.ActividadPrincipal = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtRfc(ChangeEventArgs args)
        {
            rfc = args.Value.ToString();
            if (experiencia != "")
            {
                errorRfc = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(rfc))
                {
                    errorRfc = "";
                    BolsaTrabajo.Rfc = rfc;
                }
                else
                {
                    errorRfc = "NoCaracteresEspeciales";
                    rfc = "";
                    BolsaTrabajo.Rfc = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtPlaza(ChangeEventArgs args)
        {
            plaza = args.Value.ToString();
            if (plaza != "")
            {
                errorPlaza = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(plaza))
                {
                    errorPlaza = "";
                    BolsaTrabajo.Plaza = plaza;
                }
                else
                {
                    errorPlaza = "NoCaracteresEspeciales";
                    plaza = "";
                    BolsaTrabajo.Plaza = "NA";
                }
            }
            StateHasChanged();
        }
        private async void AgregarBolsaTrabajo()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();
                if (BolsaTrabajo.IdGiro != 0)
                {
                    if(BolsaTrabajo.Sexo != "")
                    {
                        Response<object> response = new Response<object>();
                        InsertBolsaTrabajoLogic insertBolsaTrabajoLogic = new InsertBolsaTrabajoLogic(Cliente);
                        response = await insertBolsaTrabajoLogic.Insert(Sesion.TokenAcceso, BolsaTrabajo);
                        if (response.Status.Exito == 1)
                        {
                            NavigationManager.NavigateTo("/BolsaTrabajos/BolsasTrabajos");
                        }
                        else
                        {
                            alerta = response.Status.Mensaje;
                        }
                    }
                    else
                    {
                        errorSexo = "SeleccioneOpcion";
                    }
                    StateHasChanged();
                }
                else
                {
                    errorIdGiro = "SeleccioneOpcion";
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
