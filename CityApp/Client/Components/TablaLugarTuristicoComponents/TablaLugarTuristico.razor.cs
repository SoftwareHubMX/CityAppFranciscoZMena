using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaLugarTuristicoLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaLugarTuristicoComponents
{
    public partial class TablaLugarTuristico
    {
        
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();
        private Sesion Sesion = new Sesion();

        private List<LugarTuristico> LugaresTuristicos = new List<LugarTuristico>();
        private List<TipoLugarTuristico> TiposLugarTuristico = new List<TipoLugarTuristico>();
        private FiltroLugaresTuristicos FiltroLugaresTuristicos = new FiltroLugaresTuristicos();

        private bool banderaLoader = false;
        private int IdLugarTuristico = 0;

        private string busqueda = "";
        private string nombre = "";
        private string descripcion = "";
        private string caracteristica = "";
        private string caracteristicaData = "";
        private string localidad = "";
        private string colonia = "";
        private string calle = "";
        private string numero = "";
        private string codigoPostal = "";
        private int idTipoLugarTuristico = 0;
        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string busquedaError = "";
        private string nombreError = "";
        private string descripcionError = "";
        private string caracteristicaError = "";
        private string caracteristicaDataError = "";
        private string localidadError = "";
        private string coloniaError = "";
        private string calleError = "";
        private string numeroError = "";
        private string codigoPostalError = "";
        private string idTipoLugarTuristicoError = "";
        private string fechaFijaError = "";
        private string fechaInicioError = "";
        private string fechaFinError = "";
        private string yearError = "";
        private string monthError = "";

        private string alerta = "";
        
        private bool banderamodalDetalles = false;

        //Diseño

        private string section1 = "selected";
        private string section2 = "";
        private string section3 = "";
        private string carrusel1 = "";
        private string carrusel2 = "no_view";
        private string carrusel3 = "no_view";
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroLugaresTuristicos.Pagina = 1;
                FiltroLugaresTuristicos.MaximoNoticias = 20;
                StateHasChanged();
                ConsultarTiposLugarTuristicos();
                ConsultarLugarTuristicos();
            }
            StateHasChanged();
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

        private async Task DescargarImagenesLugarTuristico()
        {
            if (LugaresTuristicos != null)
            {
                for (int i = 0; i < LugaresTuristicos.Count; i++)
                {
                    if (LugaresTuristicos[i].ArchivosLugarTuristico != null)
                    {
                        for (int j = 0; j < LugaresTuristicos[i].ArchivosLugarTuristico.Count; j++)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DownloadArchivoLugarTuristico downloadArchivoLugarTuristico = new DownloadArchivoLugarTuristico(Cliente);
                            response = await downloadArchivoLugarTuristico.Dowload(LugaresTuristicos[i].ArchivosLugarTuristico[j].Ruta, LugaresTuristicos[i].IdLugarTuristico);
                            if (response.Status.Exito == 1)
                            {
                                LugaresTuristicos[i].ArchivosLugarTuristico[j].Ruta = Convert.ToBase64String(response.Data);
                            }
                        }
                    }
                }
            }
            StateHasChanged();
        }

        private void TxtBusqueda(ChangeEventArgs args)
        {
            busqueda = args.Value.ToString();
            if (busqueda != "")
            {
                busquedaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(busqueda))
                {
                    busquedaError = "";
                    FiltroLugaresTuristicos.Busqueda = busqueda;
                }
                else
                {
                    busquedaError = "NoCaracteresEspeciales";
                    busqueda = "";
                    FiltroLugaresTuristicos.Busqueda = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Nombre = nombre;
                }
                else
                {
                    nombreError = "NoCaracteresEspeciales";
                    nombre = "";
                    FiltroLugaresTuristicos.Nombre = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Descripcion = descripcion;
                }
                else
                {
                    descripcionError = "NoCaracteresEspeciales";
                    descripcion = "";
                    FiltroLugaresTuristicos.Descripcion = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Caracteristica = caracteristica;
                }
                else
                {
                    caracteristicaError = "NoCaracteresEspeciales";
                    caracteristica = "";
                    FiltroLugaresTuristicos.Caracteristica = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.CaracteristicaData = caracteristicaData;
                }
                else
                {
                    caracteristicaDataError = "NoCaracteresEspeciales";
                    caracteristicaData = "";
                    FiltroLugaresTuristicos.CaracteristicaData = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Localidad = localidad;
                }
                else
                {
                    localidadError = "NoCaracteresEspeciales";
                    localidad = "";
                    FiltroLugaresTuristicos.Localidad = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Colonia = colonia;
                }
                else
                {
                    coloniaError = "NoCaracteresEspeciales";
                    colonia = "";
                    FiltroLugaresTuristicos.Colonia = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Calle = calle;
                }
                else
                {
                    calleError = "NoCaracteresEspeciales";
                    calle = "";
                    FiltroLugaresTuristicos.Calle = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.Numero = numero;
                }
                else
                {
                    numeroError = "NoCaracteresEspeciales";
                    numero = "";
                    FiltroLugaresTuristicos.Numero = "NA";
                }
            }
            ConsultarLugarTuristicos();
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
                    FiltroLugaresTuristicos.CodigoPostal = codigoPostal;
                }
                else
                {
                    codigoPostalError = "NoCaracteresEspeciales";
                    codigoPostal = "";
                    FiltroLugaresTuristicos.CodigoPostal = "NA";
                }
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void TxtIdTipoLugarTuristico(ChangeEventArgs args)
        {
            idTipoLugarTuristico = int.Parse(args.Value.ToString());
            if (idTipoLugarTuristico != 0)
            {
                idTipoLugarTuristicoError = "";
                FiltroLugaresTuristicos.IdTipoLugarTuristico = idTipoLugarTuristico;
            }
            else
            {
                FiltroLugaresTuristicos.IdTipoLugarTuristico = idTipoLugarTuristico;
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroLugaresTuristicos.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                FiltroLugaresTuristicos.FechaFija = fechaFija;
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroLugaresTuristicos.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                FiltroLugaresTuristicos.FechaInicio = fechaInicio;
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroLugaresTuristicos.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                FiltroLugaresTuristicos.FechaFin = fechaFin;
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                FiltroLugaresTuristicos.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                FiltroLugaresTuristicos.Year = year;
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                FiltroLugaresTuristicos.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                FiltroLugaresTuristicos.Mes = month;
            }
            if (year != 0)
            {
                ConsultarLugarTuristicos();
            }
            StateHasChanged();
        }
        private async void ConsultarLugarTuristicos()
        {
            banderaLoader = false;
            LugaresTuristicos = new List<LugarTuristico>();
            StateHasChanged();
            paginas = new List<int>();
            Response<List<LugarTuristico>> response = new Response<List<LugarTuristico>>();
            SelectLugaresTuristicos selectLugaresTuristicos = new SelectLugaresTuristicos(Cliente);
            response = await selectLugaresTuristicos.SelectAll(FiltroLugaresTuristicos);
            if (response.Status.Exito == 1)
            {
                LugaresTuristicos = response.Data;
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            //await DescargarImagenesLugarTuristico();
            banderaLoader = true;
            StateHasChanged();
        }
        private void openModalDetalles(int idLugar)
        {
            IdLugarTuristico = idLugar;
            openCloseModalDetalles();

        }

        private void openCloseModalDetalles()
        {
            if (banderamodalDetalles)
            {
                banderamodalDetalles = false;
            }
            else
            {
                banderamodalDetalles = true;
            }
            StateHasChanged();
        }
        private async void CambiarPaginaActual(int page)
        {
            LugaresTuristicos = new List<LugarTuristico>();
            paginaActual = page;
            FiltroLugaresTuristicos.Pagina = paginaActual;
            StateHasChanged();
            ConsultarLugarTuristicos();
        }

        private void actualizarFiltro()
        {
            if (FiltroLugaresTuristicos.FiltroFechas >= 3)
            {
                FiltroLugaresTuristicos.FechaFin = Fecha.GetFechaMx();
                FiltroLugaresTuristicos.FechaInicio = Fecha.GetFechaMx();
                FiltroLugaresTuristicos.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (FiltroLugaresTuristicos.FiltroFechas == 2)
            {
                FiltroLugaresTuristicos.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                FiltroLugaresTuristicos.Year = 0;
                FiltroLugaresTuristicos.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                FiltroLugaresTuristicos.FechaFin = Fecha.GetFechaMx();
                FiltroLugaresTuristicos.FechaInicio = Fecha.GetFechaMx();
                FiltroLugaresTuristicos.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                FiltroLugaresTuristicos.Year = 0;
                FiltroLugaresTuristicos.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            busqueda = "";
            nombre = "";
            descripcion = "";
            caracteristica = "";
            caracteristicaData = "";
            localidad = "";
            colonia = "";
            calle = "";
            numero = "";
            codigoPostal = "";
            idTipoLugarTuristico = 0;
            LugaresTuristicos = new List<LugarTuristico>();
            FiltroLugaresTuristicos = new FiltroLugaresTuristicos();
            FiltroLugaresTuristicos.Pagina = 1;
            FiltroLugaresTuristicos.MaximoNoticias = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroLugaresTuristicos.Orden == 1)
                {
                    FiltroLugaresTuristicos.Orden = 2;
                }
                else
                {
                    FiltroLugaresTuristicos.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroLugaresTuristicos.Orden == 3)
                {
                    FiltroLugaresTuristicos.Orden = 4;
                }
                else
                {
                    FiltroLugaresTuristicos.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroLugaresTuristicos.Orden == 5)
                {
                    FiltroLugaresTuristicos.Orden = 6;
                }
                else
                {
                    FiltroLugaresTuristicos.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroLugaresTuristicos.Orden == 7)
                {
                    FiltroLugaresTuristicos.Orden = 8;
                }
                else
                {
                    FiltroLugaresTuristicos.Orden = 7;
                }
            }
            else if (sectionOrden == 5)
            {
                if (FiltroLugaresTuristicos.Orden == 9)
                {
                    FiltroLugaresTuristicos.Orden = 10;
                }
                else
                {
                    FiltroLugaresTuristicos.Orden = 9;
                }
            }
            else if (sectionOrden == 6)
            {
                if (FiltroLugaresTuristicos.Orden == 11)
                {
                    FiltroLugaresTuristicos.Orden = 12;
                }
                else
                {
                    FiltroLugaresTuristicos.Orden = 11;
                }
            }
            ConsultarLugarTuristicos();
            StateHasChanged();
        }

        private void IrNuevaLugarTuristico()
        {
            NavigationManager.NavigateTo("/Turismo/LugarTuristico/Nuevo");
        }

        private void IrEditarLugarTuristico(int idLugarTuristico)
        {
            NavigationManager.NavigateTo("/Turismo/LugarTuristico/Editar/" + idLugarTuristico);
        }

        private void CambioSection(int posicion)
        {
            if (posicion == 0)
            {
                section1 = "selected";
                section2 = "";
                section3 = "";
                carrusel1 = "";
                carrusel2 = "no_view";
                carrusel3 = "no_view";
            }
            else if (posicion == 1)
            {
                section1 = "";
                section2 = "selected";
                section3 = "";
                carrusel1 = "no_view";
                carrusel2 = "";
                carrusel3 = "no_view";
            }
            else if (posicion == 2)
            {
                section1 = "";
                section2 = "";
                section3 = "selected";
                carrusel1 = "no_view";
                carrusel2 = "no_view";
                carrusel3 = "";
            }
            StateHasChanged();
        }

        private async void EliminarLugarTuristico(int idLugarTuristico)
        {
            Response<object> response = new Response<object>();
            DeleteLugarTuristico deleteLugarTuristico = new DeleteLugarTuristico(Cliente);
            response = await deleteLugarTuristico.Delete(Sesion.TokenAcceso, idLugarTuristico);
            if (response.Status.Exito == 1)
            {
                ConsultarLugarTuristicos();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
