using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
//using CityApp.Client.Logic.CardNewSecretariaLogic;
using CityApp.Client.Logic.CardNewTramiteLogic;
using CityApp.Client.Logic.TablaTramiteLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaTramiteComponents
{
    public partial class  TablaTramite
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private List<Tramite> Tramites = new List<Tramite>();
        private List<Secretaria> Secretarias = new List<Secretaria>();
        private List<Dependencia> Dependencias = new List<Dependencia>();
        private FiltroTramite FiltroTramite = new FiltroTramite();
        private int IdTramite = 0;

        private int idSecretarias = 0;
        private int idDependencias = 0;
        private string errorIdSecretaria = "";
        private string errorIdDependencia = "";

        private string concepto = "";
        private string descripcion = "";
       
        private string errorConcepto = "";
        private string errorDescripcion = "";
        

        private bool banderaLoader = false;
        private bool banderamodal = false;

        private string alerta = "";

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;


        
        protected override async Task OnInitializedAsync()
        {
            ConsultarSecretarias();
            ConsultarDependencias();
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                //FiltroTramite.IdTipoTramite = 0;
                //FiltroTramite.IdSecretaria = 0;
                //FiltroTramite.IdDependencia = 0;
                //FiltroTramite.Concepto = "";
                //FiltroTramite.Descripcion = "";
                FiltroTramite.MaximoElementos = 10;
                FiltroTramite.Pagina = 1;
                ConsultarTramites();
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


        private async void ConsultarTramites()
        {
            banderaLoader = false;
            paginas = new List<int>();
            Tramites = new List<Tramite>();
            Response<List<Tramite>> response = new Response<List<Tramite>>();
            SelectTramitesFiltro selectTramitesFiltro = new SelectTramitesFiltro(Cliente);
            response = await selectTramitesFiltro.SelectAll(Sesion.TokenAcceso, FiltroTramite);
            if (response.Status.Exito == 1)
            {
                Tramites = response.Data;
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

        private async void ConsultarSecretarias()
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

        private async void ConsultarDependencias()
        {
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

        private void IrNuevoTramite()
        {
            NavigationManager.NavigateTo("/TramitesServicios/Tramites/Nueva");
        }

        private async void CambiarPaginaActual(int page)
        {
            Tramites = new List<Tramite>();
            paginaActual = page;
            FiltroTramite.Pagina = paginaActual;
            StateHasChanged();
            ConsultarTramites();
        }

        private void limpiarFiltro()
        {
            concepto = "";
            descripcion = "";
            idSecretarias = 0;
            idDependencias = 0;
            Tramites = new List<Tramite>();
            FiltroTramite = new FiltroTramite();
            FiltroTramite.Pagina = 1;
            FiltroTramite.MaximoElementos = 20;
            ConsultarTramites();
            StateHasChanged();
        }

        private void openModalDetalles(int idTramite)
        {
            IdTramite = idTramite;
            openCloseModalDetalles();

        }

        private void openCloseModalDetalles()
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
                    FiltroTramite.Concepto = concepto;
                }
                else
                {
                    errorConcepto = "NoCaracteresEspeciales";
                    concepto = "";
                    FiltroTramite.Concepto = "NA";
                }
            }
            ConsultarTramites();
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
                    FiltroTramite.Descripcion = descripcion;
                }
                else
                {
                    errorDescripcion = "NoCaracteresEspeciales";
                    descripcion = "";
                    FiltroTramite.Descripcion = "NA";
                }
            }
            ConsultarTramites();
            StateHasChanged();
        }

        

        private void TxtIdSecretaria(ChangeEventArgs args)
        {
            idSecretarias = int.Parse(args.Value.ToString());
            if (idSecretarias != 0)
            {
                errorIdSecretaria = "";
                FiltroTramite.IdSecretaria = idSecretarias;
                ConsultarDependencias();
                
            }
            else
            {
                errorIdSecretaria = "SeleccioneOpcion";
                Dependencias = new List<Dependencia>();
                idDependencias = 0;
                FiltroTramite.IdDependencia = 0;
            }
            ConsultarTramites();
            StateHasChanged();
        }

        private void TxtIdDependencia(ChangeEventArgs args)
        {
            idDependencias = int.Parse(args.Value.ToString());
            if (idDependencias != 0)
            {
                errorIdDependencia = "";
                FiltroTramite.IdDependencia = idDependencias;
            }
            else
            {
                errorIdDependencia = "SeleccioneOpcion";
                FiltroTramite.IdDependencia = 0;
            }
            ConsultarTramites();
            StateHasChanged();
        }
        private void IrEditarTramite(int idTramite)
        {
            NavigationManager.NavigateTo("/TramitesServicios/Tramites/Editar/" + idTramite);
        }


        private async void EliminarTramite(int idTramite)
        {
            Response<object> response = new Response<object>();
            DeleteTramite deleteTramite = new DeleteTramite(Cliente);
            response = await deleteTramite.Delete(Sesion.TokenAcceso, idTramite);
            if (response.Status.Exito == 1)
            {
                ConsultarTramites();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
