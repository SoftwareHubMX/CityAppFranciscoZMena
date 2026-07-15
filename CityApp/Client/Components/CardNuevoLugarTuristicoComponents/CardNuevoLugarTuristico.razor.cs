using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevoLugarTuristicoLogic;
using CityApp.Client.Logic.TablaLugarTuristicoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNuevoLugarTuristicoComponents
{
    public partial class CardNuevoLugarTuristico
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private CrearLugarTuristico CrearLugarTuristico = new CrearLugarTuristico();
        private List<TipoLugarTuristico> TiposLugarTuristico = new List<TipoLugarTuristico>();
        private ActualizarDireccionLugarTuristico ActualizarDireccionLugarTuristico = new ActualizarDireccionLugarTuristico();
        private AgregarCaracteristicaLugarTuristico AgregarCaracteristicaLugarTuristico = new AgregarCaracteristicaLugarTuristico();
        private List<CaracteristicaLugarTuristico> CaracteristicasLugarTuristico = new List<CaracteristicaLugarTuristico>();
        private List<string> Archivos = new List<string>();

        private int idLugarTuristico = 0;

        //private string busqueda = "";
        private string nombre = "";
        private string telefono = "";
        private string urlWebFacebook = "";
        private string descripcion = "";
        private string caracteristica = "";
        private string caracteristicaData = "";
        private string localidad = "";
        private string colonia = "";
        private string calle = "";
        private string numero = "";
        private string codigoPostal = "";
        private double latitud = 0;
        private double longitud = 0;
        private int idTipoLugarTuristico = 0;
        private DateTime fecha = DateTime.Now;
        private string busquedaError = "";
        private string nombreError = "";
        private string telefonoError = "";
        private string urlError = "";
        private string descripcionError = "";
        private string caracteristicaError = "";
        private string caracteristicaDataError = "";
        private string localidadError = "";
        private string coloniaError = "";
        private string calleError = "";
        private string numeroError = "";
        private string codigoPostalError = "";
        private string idTipoLugarTuristicoError = "";
        private string latitudError = "";
        private string longitudError = "";
        private string fechaError = "";

        private string section1 = "";
        //private string section2 = "no_view";
        private string section3 = "no_view";

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            ConsultarTiposLugarTuristicos();
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

        private async void ConsultarTiposLugarTuristicos()
        {
            Response<List<TipoLugarTuristico>> response = new Response<List<TipoLugarTuristico>>();
            SelectTiposLugarTuristicos selectTiposLugarTuristicos = new SelectTiposLugarTuristicos(Cliente);
            response = await selectTiposLugarTuristicos.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposLugarTuristico = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void InsertarLugarTuristico()
        {
            Response<int> response = new Response<int>();
            InsertLugarTuristico insertLugarTuristico = new InsertLugarTuristico(Cliente);
            response = await insertLugarTuristico.Insert(Sesion.TokenAcceso, CrearLugarTuristico);
            if (response.Status.Exito == 1)
            {
                idLugarTuristico = response.Data;
                ActualizarDireccion();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async Task ActualizarDireccion()
        {
            ActualizarDireccionLugarTuristico.IdLugarTuristico = idLugarTuristico;
            Response<object> response = new Response<object>();
            UpdataDireccionLugarTuristico updataDireccionLugarTuristico = new UpdataDireccionLugarTuristico(Cliente);
            response = await updataDireccionLugarTuristico.Updata(Sesion.TokenAcceso, ActualizarDireccionLugarTuristico);
            if(response.Status.Exito == 1)
            {
                section1 = "no_view";
                section3 = "";
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarImagenesLugarTuristicos(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoLugarTuristico downloadArchivoLugarTuristico = new DownloadArchivoLugarTuristico(Cliente);
            response = await downloadArchivoLugarTuristico.Dowload(ruta, idLugarTuristico);
            if (response.Status.Exito == 1)
            {
                Archivos.Add(Convert.ToBase64String(response.Data));
            }
            StateHasChanged();
        }

        private void TxtNombre(ChangeEventArgs args)
        {
            nombre = args.Value.ToString();
            if (nombre != "")
            {
                nombreError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(nombre))
                {
                    nombreError = "";
                    CrearLugarTuristico.Nombre = nombre;
                }
                else
                {
                    nombreError = "NoCaracteresEspeciales";
                    nombre = "";
                    CrearLugarTuristico.Nombre = "NA";
                }
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
                    CrearLugarTuristico.Telefono = telefono;
                }
                else
                {
                    telefonoError = "NoCaracteresEspeciales";
                    telefono = "";
                    CrearLugarTuristico.Telefono = "NA";
                }
            }
            StateHasChanged();
        }
        private void TxtUrlWebFacebbok(ChangeEventArgs args)
        {
            urlWebFacebook = args.Value.ToString();
            if (urlWebFacebook != "")
            {
                urlError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(urlWebFacebook))
                {
                    urlError = "";
                    CrearLugarTuristico.UrlWebFacebook = urlWebFacebook;
                }
                else
                {
                    urlError = "NoCaracteresEspeciales";
                    urlWebFacebook = "";
                    CrearLugarTuristico.UrlWebFacebook = "NA";
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
                    CrearLugarTuristico.Descripcion = descripcion;
                }
                else
                {
                    descripcionError = "NoCaracteresEspeciales";
                    descripcion = "";
                    CrearLugarTuristico.Descripcion = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtCaracteristica(ChangeEventArgs args)
        {
            caracteristica = args.Value.ToString();
            if (caracteristica != "")
            {
                caracteristicaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(caracteristica))
                {
                    caracteristicaError = "";
                    AgregarCaracteristicaLugarTuristico.NombreCaracteristica = caracteristica;
                }
                else
                {
                    caracteristicaError = "NoCaracteresEspeciales";
                    caracteristica = "";
                    AgregarCaracteristicaLugarTuristico.NombreCaracteristica = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtCaracteristicaData(ChangeEventArgs args)
        {
            caracteristicaData = args.Value.ToString();
            if (caracteristicaData != "")
            {
                caracteristicaDataError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(caracteristicaData))
                {
                    caracteristicaDataError = "";
                    AgregarCaracteristicaLugarTuristico.Caracteristica = caracteristicaData;
                }
                else
                {
                    caracteristicaDataError = "NoCaracteresEspeciales";
                    caracteristicaData = "";
                    AgregarCaracteristicaLugarTuristico.Caracteristica = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtLocalidad(ChangeEventArgs args)
        {
            localidad = args.Value.ToString();
            if (localidad != "")
            {
                localidadError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(localidad))
                {
                    localidadError = "";
                    ActualizarDireccionLugarTuristico.Localidad = localidad;
                }
                else
                {
                    localidadError = "NoCaracteresEspeciales";
                    localidad = "";
                    ActualizarDireccionLugarTuristico.Localidad = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtColonia(ChangeEventArgs args)
        {
            colonia = args.Value.ToString();
            if (colonia != "")
            {
                coloniaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(colonia))
                {
                    coloniaError = "";
                    ActualizarDireccionLugarTuristico.Colonia = colonia;
                }
                else
                {
                    coloniaError = "NoCaracteresEspeciales";
                    colonia = "";
                    ActualizarDireccionLugarTuristico.Colonia = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtCalle(ChangeEventArgs args)
        {
            calle = args.Value.ToString();
            if (calle != "")
            {
                calleError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(calle))
                {
                    calleError = "";
                    ActualizarDireccionLugarTuristico.Calle = calle;
                }
                else
                {
                    calleError = "NoCaracteresEspeciales";
                    calle = "";
                    ActualizarDireccionLugarTuristico.Calle = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtNumero(ChangeEventArgs args)
        {
            numero = args.Value.ToString();
            if (numero != "")
            {
                numeroError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(numero))
                {
                    numeroError = "";
                    ActualizarDireccionLugarTuristico.Numero = numero;
                }
                else
                {
                    numeroError = "NoCaracteresEspeciales";
                    numero = "";
                    ActualizarDireccionLugarTuristico.Numero = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtCodigoPostal(ChangeEventArgs args)
        {
            codigoPostal = args.Value.ToString();
            if (codigoPostal != "")
            {
                codigoPostalError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(codigoPostal))
                {
                    codigoPostalError = "";
                    ActualizarDireccionLugarTuristico.CodigoPostal = codigoPostal;
                }
                else
                {
                    codigoPostalError = "NoCaracteresEspeciales";
                    codigoPostal = "";
                    ActualizarDireccionLugarTuristico.CodigoPostal = "NA";
                }
            }
            
            StateHasChanged();
        }

        private void TxtLatitud(ChangeEventArgs args)
        {
            try
            {
                latitud = double.Parse(args.Value.ToString());
                latitudError = "";
                ActualizarDireccionLugarTuristico.Latitud = latitud;
            }
            catch (Exception e)
            {
                latitudError = "Ingresa un valor";
                ActualizarDireccionLugarTuristico.Latitud = 0;
            }
            StateHasChanged();
        }

        private void TxtLongitud(ChangeEventArgs args)
        {
            try
            {
                longitud = double.Parse(args.Value.ToString());
                longitudError = "";
                ActualizarDireccionLugarTuristico.Longitud = longitud;
            }
            catch(Exception e)
            {
                longitudError = "Ingresa un valor";
                ActualizarDireccionLugarTuristico.Longitud = 0;
            }
            StateHasChanged();
        }

        private void TxtIdTipoLugarTuristico(ChangeEventArgs args)
        {
            idTipoLugarTuristico = int.Parse(args.Value.ToString());
            if (idTipoLugarTuristico != 0)
            {
                idTipoLugarTuristicoError = "";
                CrearLugarTuristico.IdTipoLugarTuristico = idTipoLugarTuristico;
            }
            else
            {
                CrearLugarTuristico.IdTipoLugarTuristico = idTipoLugarTuristico;
            }
            
            StateHasChanged();
        }

        private void TxtFecha(ChangeEventArgs args)
        {
            fecha = DateTime.Parse(args.Value.ToString());
            if (fecha.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                fechaError = "";
                CrearLugarTuristico.FechaFundacionConstruccionApertura = fecha;
            }
            StateHasChanged();
        }

        private async Task saveImage(MultipartFormDataContent content)
        {
            Response<string> responseArchivoImagen = new Response<string>();
            InsertArchivoLugarTuristico insertArchivoLugarTuristico = new InsertArchivoLugarTuristico(Cliente);
            responseArchivoImagen = await insertArchivoLugarTuristico.Insert(content, idLugarTuristico, Sesion.TokenAcceso);
            if (responseArchivoImagen.Status.Exito == 1)
            {
                DescargarImagenesLugarTuristicos(responseArchivoImagen.Data);
            }
        }

        private async Task saveCaracteristica()
        {
            AgregarCaracteristicaLugarTuristico.IdLugarTuristico = idLugarTuristico;
            Response<object> responseArchivoImagen = new Response<object>();
            InsertCaracteristicaLugarTuristico insertCaracteristicaLugarTuristico = new InsertCaracteristicaLugarTuristico(Cliente);
            responseArchivoImagen = await insertCaracteristicaLugarTuristico.Insert(Sesion.TokenAcceso, AgregarCaracteristicaLugarTuristico);
            if (responseArchivoImagen.Status.Exito == 1)
            {
                CaracteristicaLugarTuristico carac = new CaracteristicaLugarTuristico()
                {
                    IdLugarTuristico = idLugarTuristico,
                    NombreCaracteristica = AgregarCaracteristicaLugarTuristico.NombreCaracteristica,
                    Caracteristica = AgregarCaracteristicaLugarTuristico.Caracteristica
                };
                CaracteristicasLugarTuristico.Add(carac);
                AgregarCaracteristicaLugarTuristico = new AgregarCaracteristicaLugarTuristico();
                caracteristica = "";
                caracteristicaData = "";
            }
            StateHasChanged();
        }

        private void siguienteAtras()
        {
            section1 = "";
            section3 = "no_view";
            StateHasChanged();
        }

        private void Guardar()
        {
            if(Archivos.Count > 0)
            {
                NavigationManager.NavigateTo("/Turismo");
            }
            else
            {
                alerta = "Debes cargar una imagen";
            }
            StateHasChanged();
        }

        //private void limpiar()
        //{
        //    LugarTuristico = new LugarTuristico();
        //    titulo = "";
        //    autor = "";
        //    fuente = "";
        //    descripcion = "";
        //    fecha = Fecha.GetFechaMx();
        //    StateHasChanged();
        //}
    }
}
