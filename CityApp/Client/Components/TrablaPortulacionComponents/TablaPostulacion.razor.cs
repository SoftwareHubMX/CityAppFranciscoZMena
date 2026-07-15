using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaPostulacionLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TrablaPortulacionComponents
{
    public partial class TablaPostulacion
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Sesion Sesion = new Sesion();

        private List<Postulacion> Postulaciones = new List<Postulacion>();
        private FiltroPostulacion FiltroPostulacion = new FiltroPostulacion();

        private bool banderaLoader = false;

        private string alerta = "";

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;



        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroPostulacion.MaximoElementos = 10;
                FiltroPostulacion.Pagina = 1;
                ConsultarPostulaciones();
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

        private async void ConsultarPostulaciones()
        {

            banderaLoader = false;
            paginas = new List<int>();
            Postulaciones = new List<Postulacion>();
            Response<List<Postulacion>> response = new Response<List<Postulacion>>();
            SelectFiltroPostulacionesLogic selectFiltroPostulacionesLogic = new SelectFiltroPostulacionesLogic(Cliente);
            response = await selectFiltroPostulacionesLogic.SelectAll(Sesion.TokenAcceso, FiltroPostulacion);
            if (response.Status.Exito == 1)
            {
                Postulaciones = response.Data;
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
            Postulaciones = new List<Postulacion>();
            paginaActual = page;
            FiltroPostulacion.Pagina = paginaActual;
            StateHasChanged();
            ConsultarPostulaciones();
        }

        //private void limpiarFiltro()
        //{
        //    nombreSecretaria = "";

        //    Secretarias = new List<Secretaria>();
        //    FiltroSecretaria = new FiltroSecretaria();
        //    FiltroSecretaria.Pagina = 1;
        //    FiltroSecretaria.MaximoElementos = 20;
        //    ConsultarSecretarias();
        //    StateHasChanged();
        //}
        
    }
}
