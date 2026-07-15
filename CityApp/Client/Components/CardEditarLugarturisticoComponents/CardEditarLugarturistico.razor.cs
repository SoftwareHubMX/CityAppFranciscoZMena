using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarLugarturisticoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarLugarturisticoComponents
{
    public partial class CardEditarLugarturistico
    {
        [Parameter] public int idLugarTuristico { get; set; } = 0;
        [Parameter] public int AspectWidth { get; set; } = 0;
        [Parameter] public int AspectHeight { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private LugarTuristico LugarTuristico = new LugarTuristico();
        private List<TipoLugarTuristico> TiposLugarTuristico = new List<TipoLugarTuristico>();
        private ActualizarDireccionLugarTuristico ActualizarDireccionLugarTuristico = new ActualizarDireccionLugarTuristico();
        private AgregarCaracteristicaLugarTuristico AgregarCaracteristicaLugarTuristico = new AgregarCaracteristicaLugarTuristico();
        private List<CaracteristicaLugarTuristico> CaracteristicasLugarTuristico = new List<CaracteristicaLugarTuristico>();
        private List<(int, string)> Archivos = new List<(int, string)>();
        private List<ArchivoLugarTuristico> ArchivosLugarTuristico = new List<ArchivoLugarTuristico>();

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
        private string section2 = "";
        private string section3 = "";

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            await ConsultarLugarTuristico();
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

        public async Task ConsultarLugarTuristico()
        {
            Response<LugarTuristico> response = new Response<LugarTuristico>();
            SelectLugarTuristico selectLugarTuristico = new SelectLugarTuristico(Cliente);
            response = await selectLugarTuristico.Select(idLugarTuristico);
            if(response.Status.Exito == 1)
            {
                LugarTuristico = response.Data;
                nombre = response.Data.Nombre;
                telefono = response.Data.Telefono;
                urlWebFacebook = response.Data.UrlWebFacebook;  
                descripcion = response.Data.Descripcion;
                localidad = response.Data.DireccionLugarTuristico.Localidad;
                colonia = response.Data.DireccionLugarTuristico.Colonia;
                calle = response.Data.DireccionLugarTuristico.Calle;
                numero = response.Data.DireccionLugarTuristico.Numero;
                codigoPostal = response.Data.DireccionLugarTuristico.CodigoPostal;
                latitud = response.Data.DireccionLugarTuristico.Latitud;
                longitud = response.Data.DireccionLugarTuristico.Longitud;
                idTipoLugarTuristico = response.Data.IdTipoLugarTuristico;
                fecha = response.Data.FechaFundacionConstruccionApertura;
                CaracteristicasLugarTuristico = response.Data.CaracteristicasLugarTuristico;
                //ArchivosLugarTuristico = response.Data.ArchivosLugarTuristico;
                ActualizarDireccionLugarTuristico.Localidad = localidad;
                ActualizarDireccionLugarTuristico.Colonia = colonia;
                ActualizarDireccionLugarTuristico.Calle = calle;
                ActualizarDireccionLugarTuristico.Numero = numero;
                ActualizarDireccionLugarTuristico.CodigoPostal = codigoPostal;
                ActualizarDireccionLugarTuristico.Latitud = latitud;
                ActualizarDireccionLugarTuristico.Longitud = longitud;
                ActualizarDireccionLugarTuristico.IdLugarTuristico = idLugarTuristico;
                if (LugarTuristico.ArchivosLugarTuristico != null && LugarTuristico.ArchivosLugarTuristico.Count > 0)
                {
                    for (int i = 0; i < LugarTuristico.ArchivosLugarTuristico.Count; i++)
                    {
                        LugarTuristico.ArchivosLugarTuristico[i].Ruta = await DescargarImagenesLugarTuristicos(LugarTuristico.ArchivosLugarTuristico[i].Ruta);
                        StateHasChanged();
                    }
                }
                StateHasChanged();
                //DescargarImagenesLugarTuristicos();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async Task<string> DescargarImagenesLugarTuristicos(string ruta)
        {
            string archivoDescargado = ruta;
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoLugarTuristico dwnloadArchivoLugarTuristico = new DownloadArchivoLugarTuristico(Cliente);
            response = await dwnloadArchivoLugarTuristico.Dowload(ruta, idLugarTuristico);
            if (response.Status.Exito == 1)
            {
                archivoDescargado = Convert.ToBase64String(response.Data);
            }
            return archivoDescargado;
        }
        //private async void DescargarImagenesLugarTuristicos(string ruta)
        //{
        //    if(ArchivosLugarTuristico != null && ArchivosLugarTuristico.Count > 0)
        //    {
        //        for(int i = 0; i < ArchivosLugarTuristico.Count; i++)
        //        {
        //            Response<byte[]> response = new Response<byte[]>();
        //            DownloadArchivoLugarTuristico downloadArchivoLugarTuristico = new DownloadArchivoLugarTuristico(Cliente);
        //            response = await downloadArchivoLugarTuristico.Dowload(ArchivosLugarTuristico[i].Ruta, idLugarTuristico);
        //            if (response.Status.Exito == 1)
        //            {
        //                (int, string) data = (ArchivosLugarTuristico[i].IdArchivoLugarTuristico, Convert.ToBase64String(response.Data));
        //                Archivos.Add(data);
        //            }
        //        }
        //    }
        //    StateHasChanged();
        //}

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

        private async void ActualizarLugarTuristico()
        {
            Response<object> response = new Response<object>();
            UpdateLugarTuristico updateLugarTuristico = new UpdateLugarTuristico(Cliente);
            response = await updateLugarTuristico.Update(Sesion.TokenAcceso, LugarTuristico);
            if (response.Status.Exito == 1)
            {
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
            if (response.Status.Exito == 1)
            {
                Guardar();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarImagenLugarTuristicos(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoLugarTuristico downloadArchivoLugarTuristico = new DownloadArchivoLugarTuristico(Cliente);
            response = await downloadArchivoLugarTuristico.Dowload(ruta, idLugarTuristico);
            if (response.Status.Exito == 1)
            {
                (int, string) data = (0, Convert.ToBase64String(response.Data));
                Archivos.Add(data);
            }
            StateHasChanged();
        }
        private async void EliminarArchivo(ArchivoLugarTuristico archivo)
        {
            Response<object> response = new Response<object>();
            DeleteArchivoLugarTuristico deleteArchivoLugarTuristico = new DeleteArchivoLugarTuristico(Cliente);
            response = await deleteArchivoLugarTuristico.Delete(Sesion.TokenAcceso, archivo.IdArchivoLugarTuristico);
            if (response.Status.Exito == 1)
            {
                LugarTuristico.ArchivosLugarTuristico.Remove(archivo);
                StateHasChanged();
            }
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
                    LugarTuristico.Nombre = nombre;
                }
                else
                {
                    nombreError = "NoCaracteresEspeciales";
                    nombre = "";
                    LugarTuristico.Nombre = "NA";
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
                    LugarTuristico.Telefono = telefono;
                }
                else
                {
                    telefonoError = "NoCaracteresEspeciales";
                    telefono = "";
                    LugarTuristico.Telefono = "NA";
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
                    LugarTuristico.UrlWebFacebook = urlWebFacebook;
                }
                else
                {
                    urlError = "NoCaracteresEspeciales";
                    urlWebFacebook = "";
                    LugarTuristico.UrlWebFacebook = "NA";
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
                    LugarTuristico.Descripcion = descripcion;
                }
                else
                {
                    descripcionError = "NoCaracteresEspeciales";
                    descripcion = "";
                    LugarTuristico.Descripcion = "NA";
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
                    LugarTuristico.DireccionLugarTuristico.Localidad = localidad;
                    ActualizarDireccionLugarTuristico.Localidad = localidad;
                }
                else
                {
                    localidadError = "NoCaracteresEspeciales";
                    localidad = "";
                    LugarTuristico.DireccionLugarTuristico.Localidad = "NA";
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
                    LugarTuristico.DireccionLugarTuristico.Colonia = colonia;
                    ActualizarDireccionLugarTuristico.Colonia = colonia;
                }
                else
                {
                    coloniaError = "NoCaracteresEspeciales";
                    colonia = "";
                    LugarTuristico.DireccionLugarTuristico.Colonia = "NA";
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
                    LugarTuristico.DireccionLugarTuristico.Calle = calle;
                    ActualizarDireccionLugarTuristico.Calle = calle;
                }
                else
                {
                    calleError = "NoCaracteresEspeciales";
                    calle = "";
                    LugarTuristico.DireccionLugarTuristico.Calle = "NA";
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
                    LugarTuristico.DireccionLugarTuristico.Numero = numero;
                    ActualizarDireccionLugarTuristico.Numero = numero;
                }
                else
                {
                    numeroError = "NoCaracteresEspeciales";
                    numero = "";
                    LugarTuristico.DireccionLugarTuristico.Numero = "NA";
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
                    LugarTuristico.DireccionLugarTuristico.CodigoPostal = codigoPostal;
                    ActualizarDireccionLugarTuristico.CodigoPostal = codigoPostal;
                }
                else
                {
                    codigoPostalError = "NoCaracteresEspeciales";
                    codigoPostal = "";
                    LugarTuristico.DireccionLugarTuristico.CodigoPostal = "NA";
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
            catch (Exception e)
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
                LugarTuristico.IdTipoLugarTuristico = idTipoLugarTuristico;
            }
            else
            {
                LugarTuristico.IdTipoLugarTuristico = idTipoLugarTuristico;
            }

            StateHasChanged();
        }

        private void TxtFecha(ChangeEventArgs args)
        {
            fecha = DateTime.Parse(args.Value.ToString());
            if (fecha.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                fechaError = "";
                LugarTuristico.FechaFundacionConstruccionApertura = fecha;
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
                LugarTuristico = new LugarTuristico();
                StateHasChanged();
                ConsultarLugarTuristico();
                StateHasChanged();
                //DescargarImagenLugarTuristicos(responseArchivoImagen.Data);
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

        private void Guardar()
        {
            NavigationManager.NavigateTo("/Turismo");
        }
    }
}
