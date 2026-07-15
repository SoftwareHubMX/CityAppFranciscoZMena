using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.ViewNoticiaLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CityApp.Client.Components.ViewNoticiaComponents
{
    public partial class ViewNoticia
    {
        [Parameter] public int idNoticia { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Noticia Noticia = new Noticia();
        private List<string> Archivos = new List<string>();
        private MudCarousel<string> _carousel;
        private int selectedIndex = 2;

        private string alerta = "";

        private string archivoVista = "";

        private bool modal = false;

        protected override async Task OnInitializedAsync()
        {
            if(idNoticia != 0)
            {
                ConsultarNoticia();
            }
        }

        private async void ConsultarNoticia()
        {
            Response<Noticia> response = new Response<Noticia>();
            SelectNoticia selectNoticia = new SelectNoticia(Cliente);
            response = await selectNoticia.Select(idNoticia);
            if (response.Status.Exito == 1)
            {
                Noticia = response.Data;
                if (Noticia.ArchivosNoticia != null && Noticia.ArchivosNoticia.Count > 0)
                {
                    foreach (var archivo in Noticia.ArchivosNoticia)
                    {
                        DescargarImagenesNoticias(archivo.Ruta);
                    }
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void DescargarImagenesNoticias(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();
            DownloadArchivoNoticia downloadArchivoNoticia = new DownloadArchivoNoticia(Cliente);
            response = await downloadArchivoNoticia.Dowload(ruta, idNoticia);
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
