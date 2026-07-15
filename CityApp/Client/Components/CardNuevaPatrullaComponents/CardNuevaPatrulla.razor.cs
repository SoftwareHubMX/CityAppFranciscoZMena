using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevaPatrullaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardNuevaPatrullaComponents
{
    public partial class CardNuevaPatrulla
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();
        private Patrulla Patrulla = new Patrulla();

        private string alerta = "";

        private string placa = "";
        private string numero = "";
        private string errorPlaca = "";
        private string errorNumero = "";

        private bool banderaBoton = false;

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

        private void TxtPlaca(ChangeEventArgs args)
        {
            placa = args.Value.ToString();
            if (placa != "")
            {
                errorPlaca = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(placa))
                {
                    errorPlaca = "";
                    Patrulla.Placa = placa;
                }
                else
                {
                    errorPlaca = "NoCaracteresEspeciales";
                    placa = "";
                    Patrulla.Placa = "NA";
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
                    Patrulla.NumeroEconomico = numero;
                }
                else
                {
                    errorNumero = "NoCaracteresEspeciales";
                    numero = "";
                    Patrulla.NumeroEconomico = "NA";
                }
            }
            StateHasChanged();
        }

        private async void Crear()
        {
            if (!banderaBoton)
            {
                banderaBoton = true;
                StateHasChanged();
                if (Patrulla.Placa != "NA" && Patrulla.Placa != "")
                {
                    if(Patrulla.NumeroEconomico != "NA" && Patrulla.NumeroEconomico != "")
                    {
                        Response<object> response = new Response<object>();
                        InsertPatrullaLogic insertPatrullaLogic = new InsertPatrullaLogic(Cliente);
                        response = await insertPatrullaLogic.Insert(Sesion.TokenAcceso, Patrulla);
                        if(response.Status.Exito == 1)
                        {
                            NavigationManager.NavigateTo("/SeguridadPublica/Patrullas");
                        }
                        else
                        {
                            alerta = response.Status.Mensaje;
                        }
                        banderaBoton = false;
                        StateHasChanged();
                    }
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
