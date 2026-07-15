using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CartListPrediosLogic;
using CityApp.Client.Services.ApiRest.PredioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace CityApp.Client.Components.CartListPrediosComponents
{
    public partial class CartListPredios
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        [Inject] IJSRuntime js { get; set; }
        IJSObjectReference modulo;

        private Validaciones Validaciones = new Validaciones();
        private Sesion Sesion = new Sesion();

        private List<Predio> Predios = new List<Predio>();
        private FiltroPredios FiltroPredios = new FiltroPredios();

        private bool banderaLoader = false;
        private bool modal = false;

        private string clave = "";
        private string claveCatastral = "";
        private string usuario = "";
        private string calle = "";
        private string colonia = "";
        private string poblacion = "";
        private string ciudad = "";
        private string estado = "";
        private string codigoPostal = ""; 
        private string claveError = "";
        private string claveCatastralError = "";
        private string usuarioError = "";
        private string calleError = "";
        private string coloniaError = "";
        private string poblacionError = "";
        private string ciudadError = "";
        private string estadoError = "";
        private string codigoPostalError = "";

        private string alerta = "";

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
            FiltroPredios.Pagina = 1;
            FiltroPredios.MaximoNoticias = 20;
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
            {
                ConsultarPredios();
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
                modulo = await js.InvokeAsync<IJSObjectReference>("import", "../Js/DescargaArchivos/DescargaArchivos.js");
                StateHasChanged();
            }
        }

        private void TxtClave(ChangeEventArgs args)
        {
            clave = args.Value.ToString();
            if (clave != "")
            {
                claveError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(clave))
                {
                    claveError = "";
                    FiltroPredios.Clave = clave;
                }
                else
                {
                    claveError = "NoCaracteresEspeciales";
                    clave = "";
                    FiltroPredios.Clave = "NA";
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }

        private void TxtClaveCatastral(ChangeEventArgs args)
        {
            claveCatastral = args.Value.ToString();
            if (claveCatastral != "")
            {
                claveCatastralError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(claveCatastral))
                {
                    claveCatastralError = "";
                    FiltroPredios.ClaveCatastral = claveCatastral;
                }
                else
                {
                    claveCatastralError = "NoCaracteresEspeciales";
                    claveCatastral = "";
                    FiltroPredios.ClaveCatastral = "NA";
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }

        private void TxtUsuario(ChangeEventArgs args)
        {
            usuario = args.Value.ToString();
            if (usuario != "")
            {
                usuarioError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(usuario))
                {
                    usuarioError = "";
                    FiltroPredios.Usuario = usuario;
                }
                else
                {
                    usuarioError = "NoCaracteresEspeciales";
                    usuario = "";
                    FiltroPredios.Usuario = "NA";
                }
            }
            ConsultarPredios();
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
                    FiltroPredios.Direccion = calle;
                }
                else
                {
                    calleError = "NoCaracteresEspeciales";
                    calle = "";
                    FiltroPredios.Direccion = "NA";
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }

        private void TxtPoblacion(ChangeEventArgs args)
        {
            poblacion = args.Value.ToString();
            if (poblacion != "")
            {
                poblacionError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(poblacion))
                {
                    poblacionError = "";
                    FiltroPredios.Poblacion = poblacion;
                }
                else
                {
                    poblacionError = "NoCaracteresEspeciales";
                    poblacion = "";
                    FiltroPredios.Poblacion = "NA";
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }

        private void TxtCiudad(ChangeEventArgs args)
        {
            ciudad = args.Value.ToString();
            if (ciudad != "")
            {
                ciudadError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(ciudad))
                {
                    ciudadError = "";
                    FiltroPredios.Ciudad = ciudad;
                }
                else
                {
                    ciudadError = "NoCaracteresEspeciales";
                    ciudad = "";
                    FiltroPredios.Ciudad = "NA";
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }

        private void TxtEstado(ChangeEventArgs args)
        {
            estado = args.Value.ToString();
            if (estado != "")
            {
                estadoError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(estado))
                {
                    estadoError = "";
                    FiltroPredios.Estado = estado;
                }
                else
                {
                    estadoError = "NoCaracteresEspeciales";
                    estado = "";
                    FiltroPredios.Estado = "NA";
                }
            }
            ConsultarPredios();
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
                    FiltroPredios.CodigoPostal = codigoPostal;
                }
                else
                {
                    codigoPostalError = "NoCaracteresEspeciales";
                    codigoPostal = "";
                    FiltroPredios.CodigoPostal = "NA";
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }

        private async void ConsultarPredios()
        {
            banderaLoader = false;
            StateHasChanged();
            Predios = new List<Predio>();
            paginas = new List<int>();
            Response<List<Predio>> response = new Response<List<Predio>>();
            SelectPredios selectPredios = new SelectPredios(Cliente);
            response = await selectPredios.SelectAll(Sesion.TokenAcceso, FiltroPredios);
            if (response.Status.Exito == 1)
            {
                Predios = response.Data;
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
            banderaLoader = true;
            StateHasChanged();
        }

        private async void CambiarPaginaActual(int page)
        {
            Predios = new List<Predio>();
            paginaActual = page;
            FiltroPredios.Pagina = paginaActual;
            StateHasChanged();
            ConsultarPredios();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroPredios.Orden == 1)
                {
                    FiltroPredios.Orden = 2;
                }
                else
                {
                    FiltroPredios.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroPredios.Orden == 3)
                {
                    FiltroPredios.Orden = 4;
                }
                else
                {
                    FiltroPredios.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroPredios.Orden == 5)
                {
                    FiltroPredios.Orden = 6;
                }
                else
                {
                    FiltroPredios.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroPredios.Orden == 7)
                {
                    FiltroPredios.Orden = 8;
                }
                else
                {
                    FiltroPredios.Orden = 7;
                }
            }
            else if (sectionOrden == 5)
            {
                if (FiltroPredios.Orden == 9)
                {
                    FiltroPredios.Orden = 10;
                }
                else
                {
                    FiltroPredios.Orden = 9;
                }
            }
            else if (sectionOrden == 6)
            {
                if (FiltroPredios.Orden == 11)
                {
                    FiltroPredios.Orden = 12;
                }
                else
                {
                    FiltroPredios.Orden = 11;
                }
            }
            ConsultarPredios();
            StateHasChanged();
        }


        private void limpiarFiltro()
        {
            clave = "";
            claveCatastral = "";
            usuario = "";
            calle = "";
            colonia = "";
            poblacion = "";
            ciudad = "";
            estado = "";
            codigoPostal = "";
            Predios = new List<Predio>();
            FiltroPredios = new FiltroPredios();
            FiltroPredios.Pagina = 1;
            FiltroPredios.MaximoNoticias = 20;
            ConsultarPredios();
            StateHasChanged();
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

        private void irNoticia(int idNoticia)
        {
            NavigationManager.NavigateTo("/Publico/Noticias/Noticia/" + idNoticia);
        }

        private async void DescargarPlantilla()
        {
            if (Predios.Count > 0)
            {

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Usuarios");

                    var tableBody = worksheet.Cells["A2:L" + (Predios.Count + 1)].LoadFromCollection<Predio>(Predios);

                    tableBody.Worksheet.Cells["A1"].LoadFromText("ID");
                    tableBody.Worksheet.Cells["B1"].LoadFromText("Clave");
                    tableBody.Worksheet.Cells["C1"].LoadFromText("Clave catastral");
                    tableBody.Worksheet.Cells["D1"].LoadFromText("Resago");
                    tableBody.Worksheet.Cells["E1"].LoadFromText("Dirección");
                    tableBody.Worksheet.Cells["F1"].LoadFromText("Población");
                    tableBody.Worksheet.Cells["G1"].LoadFromText("Ciudad");
                    tableBody.Worksheet.Cells["H1"].LoadFromText("Estado");
                    tableBody.Worksheet.Cells["I1"].LoadFromText("Codigo postal");
                    tableBody.Worksheet.Cells["J1"].LoadFromText("Propietario");
                    tableBody.Worksheet.Cells["K1"].LoadFromText("Fecha del ultimo pago");
                    tableBody.Worksheet.Cells["L1"].LoadFromText("Total");

                    await modulo.InvokeVoidAsync("SaveFile", "Plantilla-Predios.xlsx", Convert.ToBase64String(package.GetAsByteArray()));
                }
            }
        }

        private void OpenCloseModal()
        {
            if (modal)
            {
                modal = false;
            }
            else
            {
                modal = true;
            }
            ConsultarPredios();
            StateHasChanged();
        }
    }
}
