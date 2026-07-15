using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNewDependenciaLogic;
using CityApp.Client.Logic.CardNewSecretariaLogic;
using CityApp.Client.Logic.TablaSecretariaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace CityApp.Client.Components.CardNuevaDependenciaComponents
{
    public partial class CardNuevaDependencia
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Dependencia Dependencia = new Dependencia();
        private List<Secretaria> Secretarias = new List<Secretaria>();


        private string alerta = "";

        private int idSecretarias = 0;
        private string nombreDependencia = "";
        private string errorNombreDependencia = "";
        private string errorIdSecretaria = "";

        private bool banderaBoton = false;

        protected override async Task OnInitializedAsync()
        {
            ConsultarSecretarias();
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

        private void TxtNombreDependencia(ChangeEventArgs args)
        {
            nombreDependencia = args.Value.ToString();
            if (nombreDependencia != "")
            {
                errorNombreDependencia = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(nombreDependencia))
                {
                    errorNombreDependencia = "";
                    Dependencia.NombreDependencia = nombreDependencia;
                }
                else
                {
                    errorNombreDependencia = "NoCaracteresEspeciales";
                    nombreDependencia = "";
                    Dependencia.NombreDependencia = "NA";
                }
            }
            StateHasChanged();
        }

        private void TxtIdSecretaria(ChangeEventArgs args)
        {
            idSecretarias = int.Parse(args.Value.ToString());
            if (idSecretarias != 0)
            {
                errorIdSecretaria = "";
                Dependencia.IdSecretaria = idSecretarias;
            }
            else
            {
                errorIdSecretaria = "SeleccioneOpcion";
                Dependencia.IdSecretaria = 0;
            }

            StateHasChanged();
        }
        private async void AgregarDependencia()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();
                if (Dependencia.IdSecretaria != 0)
                {
                    Response<object> response = new Response<object>();
                    InsertDependenciaLogic insertDependenciaLogic = new InsertDependenciaLogic(Cliente);
                    response = await insertDependenciaLogic.Insert(Sesion.TokenAcceso, Dependencia);
                    if (response.Status.Exito == 1)
                    {
                        NavigationManager.NavigateTo("/TramitesServicios/Dependencias");
                    }
                    else
                    {
                        alerta = response.Status.Mensaje;
                    }
                    StateHasChanged();
                }
                else
                {
                    errorIdSecretaria = "SeleccioneOpcion";
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
