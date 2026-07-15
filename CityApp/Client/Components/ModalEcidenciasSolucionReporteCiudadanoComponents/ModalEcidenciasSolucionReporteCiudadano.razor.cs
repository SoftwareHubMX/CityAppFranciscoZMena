using CityApp.Client.Logic.TablaReporteCiudadanoLogic;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalEcidenciasSolucionReporteCiudadanoComponents
{
    public partial class ModalEcidenciasSolucionReporteCiudadano
    {
        [Parameter] public List<string> Archivos { get; set; }
        [Parameter] public Sesion Sesion { get; set; }
        [Parameter] public int IdReporteCiudadano { get; set; }
        [Parameter] public EventCallback<int> OpenCloseModal { get; set; }
        [Inject] private HttpClient Cliente { get; set; }

        private bool banderaCargaInfo = false;
        private string idBtnCropper = "";

        protected override async Task OnInitializedAsync()
        {
            idBtnCropper = "'input" + IdReporteCiudadano + "'";
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (!banderaCargaInfo)
                {
                    if(Archivos != null)
                    {
                        DescargarArchivosEvidencia();
                        banderaCargaInfo = true;
                        StateHasChanged();
                    }
                }
            }
        }

        private async void DescargarArchivosEvidencia()
        {
            if (Archivos != null && Archivos.Count > 0)
            {
                for (int i = 0; i < Archivos.Count; i++)
                {
                    if(Archivos[i].Length < 51)
                    {
                        Response<byte[]> response = new Response<byte[]>();
                        DowloadEvidenciasSolucionResporteCiudadano dowloadEvidenciasSolucionResporteCiudadano = new DowloadEvidenciasSolucionResporteCiudadano(Cliente);
                        response = await dowloadEvidenciasSolucionResporteCiudadano.Dowload(Archivos[i], Sesion.TokenAcceso, IdReporteCiudadano);
                        if (response.Status.Exito == 1)
                        {
                            Archivos[i] = Convert.ToBase64String(response.Data);
                        }
                    }
                }
            }
            StateHasChanged();
        }
    }
}
