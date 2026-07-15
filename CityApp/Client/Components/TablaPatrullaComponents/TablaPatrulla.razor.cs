using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaLugarTuristicoLogic;
using CityApp.Client.Logic.TablaPatrullaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaPatrullaComponents
{
    public partial class TablaPatrulla
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();
        private Sesion Sesion = new Sesion();

        private List<Patrulla> Patrullas = new List<Patrulla>();
        private FiltroPatrullas FiltroPatrullas = new FiltroPatrullas();
        private bool banderaLoader = false;

        private string placa = "";
        private string numero = "";
        private string placaError = "";
        private string numeroError = "";

        private string alerta = "";
        
        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroPatrullas.Pagina = 1;
                FiltroPatrullas.MaximoPatrullas = 20;
                StateHasChanged();
                ConsultarPatrullas();
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

        private void TxtPlaca(ChangeEventArgs args)
        {
            placa = args.Value.ToString();
            if (placa != "")
            {
                placaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(placa))
                {
                    placaError = "";
                    FiltroPatrullas.Placa = placa;
                }
                else
                {
                    placaError = "NoCaracteresEspeciales";
                    placa = "";
                    FiltroPatrullas.Placa = "NA";
                }
            }
            ConsultarPatrullas();
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
                    FiltroPatrullas.NumeroEconomico = numero;
                }
                else
                {
                    numeroError = "NoCaracteresEspeciales";
                    numero = "";
                    FiltroPatrullas.NumeroEconomico = "NA";
                }
            }
            ConsultarPatrullas();
            StateHasChanged();
        }

        private async void ConsultarPatrullas()
        {
            banderaLoader = false;
            Patrullas = new List<Patrulla>();
            StateHasChanged();
            paginas = new List<int>();
            Response<List<Patrulla>> response = new Response<List<Patrulla>>();
            SelectPatrullas selectPatrullas = new SelectPatrullas(Cliente);
            response = await selectPatrullas.SelectAll(Sesion.TokenAcceso, FiltroPatrullas);
            if (response.Status.Exito == 1)
            {
                Patrullas = response.Data;
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
            Patrullas = new List<Patrulla>();
            paginaActual = page;
            FiltroPatrullas.Pagina = paginaActual;
            StateHasChanged();
            ConsultarPatrullas();
        }

        private void limpiarFiltro()
        {
            placa = "";
            numero = "";
            Patrullas = new List<Patrulla>();
            FiltroPatrullas = new FiltroPatrullas();
            FiltroPatrullas.Pagina = 1;
            FiltroPatrullas.MaximoPatrullas = 20;
            ConsultarPatrullas();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroPatrullas.Orden == 1)
                {
                    FiltroPatrullas.Orden = 2;
                }
                else
                {
                    FiltroPatrullas.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroPatrullas.Orden == 3)
                {
                    FiltroPatrullas.Orden = 4;
                }
                else
                {
                    FiltroPatrullas.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroPatrullas.Orden == 5)
                {
                    FiltroPatrullas.Orden = 6;
                }
                else
                {
                    FiltroPatrullas.Orden = 5;
                }
            }
            ConsultarPatrullas();
            StateHasChanged();
        }

        private void IrNuevaPatrulla()
        {
            NavigationManager.NavigateTo("/SeguridadPublica/Patrullas/Nueva");
        }

        private void IrEditarPatrulla(int idPatrulla)
        {
            NavigationManager.NavigateTo("/SeguridadPublica/Patrullas/Editar/" + idPatrulla);
        }

        private async void EliminarPatrulla(int idPatrulla)
        {
            Response<object> response = new Response<object>();
            DeletePatrulla deletePatrulla = new DeletePatrulla(Cliente);
            response = await deletePatrulla.Delete(Sesion.TokenAcceso, idPatrulla);
            if (response.Status.Exito == 1)
            {
                ConsultarPatrullas();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }
    }
}
