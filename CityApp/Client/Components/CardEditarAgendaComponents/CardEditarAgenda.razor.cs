using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarAgenda;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarAgendaComponents
{
    public partial class CardEditarAgenda
    {
        [Parameter] public int idAgenda { get; set; } = 0;
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private Agenda Agenda = new Agenda();
        private List<string> Archivos = new List<string>();

        private string titulo = "";
        private string hora = "";
        private string lugar = "";
        private string descripcion = "";
        private DateTime fecha = DateTime.Now;
        private string tituloError = "";
        private string horaError = "";
        private string lugarError = "";
        private string fechaError = "";
        private string descripcionError = "";
        private string section1 = "";
        private string section2 = "no_view";

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                ConsultarAgenda();
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

        private async void ConsultarAgenda()
        {
            Response<Agenda> response = new Response<Agenda>();
            SelectAgenda selectAgenda = new SelectAgenda(Cliente);
            response = await selectAgenda.Select(idAgenda);
            if (response.Status.Exito == 1)
            {
                Agenda = response.Data;
                titulo = Agenda.Titulo;
                hora = Agenda.Hora;
                lugar = Agenda.Lugar;
                descripcion = Agenda.Texto;
                fecha = Agenda.FechaPublicacion;
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

        private async void ActualizarAgenda()
        {
            Response<object> response = new Response<object>();
            UpdataAgenda updataAgenda = new UpdataAgenda(Cliente);
            response = await updataAgenda.Updata(Sesion.TokenAcceso, Agenda);
            if (response.Status.Exito == 1)
            {
                Guardar();
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

        private async void EliminarArchivo(int idArchivo)
        {
            Response<object> response = new Response<object>();
            DeleteArchivoAgenda deleteArchivoAgenda = new DeleteArchivoAgenda(Cliente);
            response = await deleteArchivoAgenda.Delete(Sesion.TokenAcceso, idArchivo);
        }

        private void TxtTitulo(ChangeEventArgs args)
        {
            titulo = args.Value.ToString();
            if (titulo != "")
            {
                tituloError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(titulo))
                {
                    tituloError = "";
                    Agenda.Titulo = titulo;
                }
                else
                {
                    tituloError = "NoCaracteresEspeciales";
                    titulo = "";
                }
            }
            StateHasChanged();
        }

        private void TxtHora(ChangeEventArgs args)
        {
            hora = args.Value.ToString();
            if (hora != "")
            {
                horaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(hora))
                {
                    horaError = "";
                    Agenda.Hora = hora;
                }
                else
                {
                    horaError = "NoCaracteresEspeciales";
                    hora = "";
                }
            }
            StateHasChanged();
        }

        private void TxtLugar(ChangeEventArgs args)
        {
            lugar = args.Value.ToString();
            if (lugar != "")
            {
                lugarError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(lugar))
                {
                    lugarError = "";
                    Agenda.Lugar = lugar;
                }
                else
                {
                    lugarError = "NoCaracteresEspeciales";
                    lugar = "";
                }
            }
            StateHasChanged();
        }

        private void TxtFecha(ChangeEventArgs args)
        {
            fecha = DateTime.Parse(args.Value.ToString());
            if (fecha.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                fechaError = "";
                Agenda.FechaPublicacion = fecha;
            }
            StateHasChanged();
        }

        private void TxtDescripcion(ChangeEventArgs args)
        {
            descripcion = args.Value.ToString();
            if (descripcion != "")
            {
                descripcionError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(descripcion))
                {
                    descripcionError = "";
                    Agenda.Texto = descripcion;
                }
                else
                {
                    descripcionError = "NoCaracteresEspeciales";
                    descripcion = "";
                }
            }
            StateHasChanged();
        }

        private async Task saveImage(MultipartFormDataContent content)
        {
            Response<string> responseArchivoImagen = new Response<string>();
            InsertArchivoAgenda insertArchivoAgenda = new InsertArchivoAgenda(Cliente);
            responseArchivoImagen = await insertArchivoAgenda.Insert(content, idAgenda, Sesion.TokenAcceso);
            if (responseArchivoImagen.Status.Exito == 1)
            {
                DescargarImagenesAgendas(responseArchivoImagen.Data);
            }
        }

        private void Guardar()
        {
            NavigationManager.NavigateTo("/Eventos");
        }

        private void limpiar()
        {
            Agenda = new Agenda();
            titulo = "";
            hora = "";
            lugar = "";
            descripcion = "";
            fecha = Fecha.GetFechaMx();
            StateHasChanged();
        }
    }
}
