using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditRutaRecoleccionLogic;
using CityApp.Client.Logic.CardNewRutaRecoleccionLogic;
using CityApp.Client.Logic.TablaRutaRecoleccionLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaRutaRecoleccionComponents
{
    public partial class TablaRutaRecoleccion
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private List<RutaRecoleccion> RutasRecoleccion = new List<RutaRecoleccion>();
        private List<Colonia> Colonias = new List<Colonia>();
        
        private FiltroRutaRecoleccion FiltroRutaRecoleccion = new FiltroRutaRecoleccion();
        private int IdRutaRecoleccion = 0;

        private int idColonia = 0;        
        private string errorIdColonia = "";


        private bool banderaLoader = false;
        private bool banderamodal = false;
        private bool banderamodalDetalles = false;

        private string alerta = "";

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;



        protected override async Task OnInitializedAsync()
        {
            
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                
                FiltroRutaRecoleccion.MaximoElementos = 10;
                FiltroRutaRecoleccion.Pagina = 1;
                ConsultarRutasRecoleccion();
                ConsultarColonias();
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


        private async void ConsultarRutasRecoleccion()
        {
            banderaLoader = false;
            paginas = new List<int>();
            RutasRecoleccion = new List<RutaRecoleccion>();
            Response<List<RutaRecoleccion>> response = new Response<List<RutaRecoleccion>>();
            SelectFiltroRutasRecoleccion selectFiltroRutasRecoleccion = new SelectFiltroRutasRecoleccion(Cliente);
            response = await selectFiltroRutasRecoleccion.SelectAll(Sesion.TokenAcceso, FiltroRutaRecoleccion);
            if (response.Status.Exito == 1)
            {
                RutasRecoleccion = response.Data;
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

        private void IrNuevaRuta()
        {
            NavigationManager.NavigateTo("/RutasRecolecciones/Nueva");
        }
        private void IrNuevaCuentaChofer()
        {
            NavigationManager.NavigateTo("/RutasRecolecciones/NuevaCuentaChofer");
        }

        private void IrEditarRutaRecoleccion(int idRutaRecoleccion)
        {
            NavigationManager.NavigateTo("/RutasRecolecciones/Editar/" + idRutaRecoleccion);
        }

        private void openModalAlertas(int idRutaRecoleccion)
        {
            IdRutaRecoleccion = idRutaRecoleccion;
            openCloseModalAlertas();

        }
        private void openCloseModalAlertas()
        {
            if (banderamodal)
            {
                banderamodal = false;
            }
            else
            {
                banderamodal = true;
            }
            StateHasChanged();
        }
        private void openModalDetalles2(int idRutaRecoleccion)
        {
            IdRutaRecoleccion = idRutaRecoleccion;
            openCloseModalDetalles2();

        }
        private void openCloseModalDetalles2()
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
            RutasRecoleccion = new List<RutaRecoleccion>();
            paginaActual = page;
            FiltroRutaRecoleccion.Pagina = paginaActual;
            StateHasChanged();
            ConsultarRutasRecoleccion();
        }

        

        private void SelectIdColonia (ChangeEventArgs args)
        {
            idColonia = int.Parse(args.Value.ToString());
            if(idColonia > 0)
            {
                FiltroRutaRecoleccion.IdColonia = idColonia;
                errorIdColonia = "";
            }
            else
            {
                FiltroRutaRecoleccion.IdColonia = 0;
                errorIdColonia = "campoRequerido";
            }
            ConsultarRutasRecoleccion();
            StateHasChanged();
        }

        

        private void limpiarFiltro()
        {
            idColonia = 0; 
            RutasRecoleccion = new List<RutaRecoleccion>();
            FiltroRutaRecoleccion = new FiltroRutaRecoleccion();
            FiltroRutaRecoleccion.Pagina = 1;
            FiltroRutaRecoleccion.MaximoElementos = 10;
            ConsultarRutasRecoleccion();
            StateHasChanged();
        }

    }
}
