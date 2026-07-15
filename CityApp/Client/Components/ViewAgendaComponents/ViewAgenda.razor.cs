using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ViewAgendaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.ViewAgendaComponents
{
    public partial class ViewAgenda
    {
        [Parameter] public int idAgenda { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Agenda Agenda = new Agenda();
        private List<string> Archivos = new List<string>();
        private MudCarousel<string> _carousel;
        private int selectedIndex = 2;

        private string alerta = "";

        private string archivoVista = "";

        private bool modal = false;

        protected override async Task OnInitializedAsync()
        {
            if (idAgenda != 0)
            {
                ConsultarAgenda();
            }
        }

        private async void ConsultarAgenda()
        {
            Response<Agenda> response = new Response<Agenda>();
            SelectAgenda selectAgenda = new SelectAgenda(Cliente);
            response = await selectAgenda.Select(idAgenda);
            if (response.Status.Exito == 1)
            {
                Agenda = response.Data;
                if (Agenda.ArchivosAgenda != null && Agenda.ArchivosAgenda.Count > 0)
                {
                    foreach (var archivo in Agenda.ArchivosAgenda)
                    {
                        DescargarImagenesAgendas(archivo.Ruta);
                    }
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarImagenesAgendas(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoAgenda downloadArchivoAgenda = new DownloadArchivoAgenda(Cliente);
            response = await downloadArchivoAgenda.Dowload(ruta, idAgenda);
            if (response.Status.Exito == 1)
            {
                Archivos.Add(Convert.ToBase64String(response.Data));
            }
            StateHasChanged();
        }

        private void openModal(string img)
        {
            archivoVista = img;
            modal = true;
            StateHasChanged();
        }

        private void CloseModal()
        {
            archivoVista = "";
            modal = false;
            StateHasChanged();
        }
    }
}
