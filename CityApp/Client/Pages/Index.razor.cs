using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CityApp.Client.Pages
{
    public partial class Index :IAsyncDisposable
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;
        private IJSObjectReference modulo2;
        IJSObjectReference lib;

        private List<(string, string, string)> Colecciones = new List<(string, string, string)>();

        private string OpcionNav = "";
        private string arrow = "down";

        protected override async Task OnInitializedAsync()
        {
            NavigationManager.NavigateTo("/Acceso");
            //ConstruirColeccion();
        }

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                lib = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "https://cdnjs.cloudflare.com/ajax/libs/bodymovin/5.7.13/lottie.min.js");
                modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/Indenx/Index.js");
                await modulo.InvokeVoidAsync("AnimacionNosotros");
                modulo2 = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/Indenx/NavBar.js");
                await modulo2.InvokeVoidAsync("focus");
                StateHasChanged();
            }
        }

        private void ConstruirColeccion()
        {
            Colecciones = new List<(string, string, string)>()
            {
                new ("fas fa-calendar-alt", "Agenda de Eventos", "Información sobre las actividades y eventos relevantes. "),
                new ("fas fa-bullhorn", "Alerta Ciudadana", "Acceso al servicio de emergencias con solo tocar el widget. "),
                new ("fas fa-chalkboard-teacher", "Bolsa de Trabajo", "Publicación de ofertas laborales."),
                new ("fas fa-comment-dots", "Contacta a tu funcionario", "Comunicación vía mensaje de texto con los diversos funcionarios del ayuntamiento."),
                new ("fas fa-phone", "Contacto", "Iinformación general de contacto con el ayuntamiento."),
                new ("fas fa-unlock-alt", "Datos Abiertos", "Información oficial a disposición de la ciudadanía."),
                new ("fas fa-address-book", "Directorio", "Descripción de cargos de los funcionarios que laboran en la alcaldía."),
                new ("fas fa-chart-line", "Encuestas", "Conoce mejor las necesidades de tu población, por medio de encuestas."),
                new ("fas fa-info-circle", "Información de Interés", "Mesa de ayuda y soporte técnico sobre el funcionamiento de la app. Con el desarrollador."),
                new ("fas fa-bus-alt", "Movilidad y Transporte", "Acceso a información de las rutas y horarios de trasporte público. "),
                new ("fas fa-briefcase", "Negocios", "Conoce los productos y servicios que se ofrecen en los negocios locales."),
                new ("fas fa-newspaper", "Noticias", "La finalidad de esta sección es mantener informada a la ciudadanía en cuanto novedades y acontecimientos relevantes en el municipio y sus comunidades."),
                new ("fas fa-map-marked-alt", "Obras Públicas", "Conoce los avances en infraestructura o edificación, promovidos por la administración en beneficio d la ciudadanía. "),
                new ("fas fa-folder-open", "Oficialía de Partes", "Recepción de oficios/ solicitudes y si seguimiento."),
                new ("fas fa-money-check-alt", "Pago de Impuestos", "Ahorra tiempo y dinero, evitando las largas filas, pagando servicios como predial, agua entre otros, desde la app."),
                new ("fas fa-qrcode", "Realidad Aumentada", "Acceso a información adicional, utilizando la cámara del dispositivo móvil. "),
                new ("fas fa-eye", "Rendición de Cuentas", "La trasparencia del municipio, a disponibilidad de los ciudadanos. "),
                new ("fas fa-user-edit", "Reporte Ciudadano", "Reporte de incidencias en tiempo real, generando comunicación y confianza entre el ciudadano y las autoridades."),
                new ("fas fa-user-shield", "Seguridad Pública", "Comunicación directa a servicios de seguridad pública."),
                new ("fas fa-truck", "Servicios Municipales", "El mapeo de rutas puede ser de gran utilidad tanto para el ayuntamiento como para el ciudadano. Por ejemplo, la ruta del servicio de recolección de desechos. "),
                new ("fas fa-traffic-light", "Tráfico", "Información en tiempo real de tránsito vehicular."),
                new ("fas fa-file-signature", "Trámites y Servicios", "solicitud o entrega de información ante las autoridades competentes, ya sea para cumplir una obligación o a fin de emitir una resolución"),
                new ("fas fa-archway", "Turismo y Cultura", "Acceso a información turística, monumentos, tours o noticias relevantes en torno al municipio y su cultura."),
            };
            StateHasChanged();
        }

        private void OpenClosOpcions()
        {
            OpcionNav = (OpcionNav == "") ? "_open" : "";
            arrow = (arrow == "down") ? "up" : "down";
            StateHasChanged();
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if(modulo != null)
            {
                await modulo.DisposeAsync();
                await lib.DisposeAsync();
            }
        }
    }
}
