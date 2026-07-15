using CityApp.Shared.Entities.BDSqlServerCityApp;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace CityApp.Client.Components.MapaAlertaComponents
{
    public partial class MapaAlerta : IAsyncDisposable
    {
        [Parameter] public List<Alerta> alertas { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;

        private bool banderaalertas = false;

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                if (alertas != null)
                {
                    try
                    {
                        modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/MapaAlertaJs/MapaAlerta.js");
                        StateHasChanged();
                    }
                    catch (Exception e)
                    {
                        NavigationManager.NavigateTo(NavigationManager.Uri.ToString(), true);
                    }
                }
            }
            else
            {
                if (alertas != null && alertas.Count > 0)
                {
                    if (!banderaalertas)
                    {
                        GenerarDataPushPins();
                        banderaalertas = true;
                        StateHasChanged();
                    }
                }
                else
                {
                    banderaalertas = false;
                }
            }
        }

        private async void GenerarDataPushPins()
        {
            string data = "";
            for (int i = 0; i < alertas.Count; i++)
            {
                data += "https://www.cityapp.mx/PushPoints/Shared/" + alertas[i].IdEstatusAlerta + "_Alerta.png, ";
                
                data += alertas[i].DireccionAlerta.Latitud.ToString("0,0.0000", CultureInfo.InvariantCulture) + ", " + alertas[i].DireccionAlerta.Longitud.ToString("0,0.0000", CultureInfo.InvariantCulture) + ", ";
                data += alertas[i].Cuenta.NombreUsuario + ", ";
                data += alertas[i].DireccionAlerta.Localidad + " " + alertas[i].DireccionAlerta.Colonia + " " + alertas[i].DireccionAlerta.Calle + " " + alertas[i].DireccionAlerta.Numero + " CP:" + alertas[i].DireccionAlerta.CodigoPostal + ", ";
                if (i == (alertas.Count - 1))
                {
                    data += alertas[i].FechaAlerta.ToString("dd/MM/yyyy");
                }
                else
                {

                    data += alertas[i].FechaAlerta.ToString("dd/MM/yyyy") + " : ";
                }
            }
            await modulo.InvokeVoidAsync("CargaMap", data);
        }

        public async ValueTask DisposeAsync()
        {
            if (modulo != null)
            {
                await modulo.DisposeAsync();
            }
        }
    }
}
