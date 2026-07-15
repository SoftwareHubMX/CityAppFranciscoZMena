using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardNuevaAgendaLogic;
using CityApp.Client.Logic.TablaAgendasLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.TablaAgendasComponents
{
    public partial class TablaAgendas
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";

        //private static MVLoginRegistro mvLoginRegistro = new MVLoginRegistro();

        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private List<Agenda> Agendas = new List<Agenda>();
        private FiltroAgenda FiltroAgendas = new FiltroAgenda();

        private string titulo = "";
        private string busqueda = "";
        private TimeSpan horario = TimeSpan.Zero;
        private string lugar = "";
        private DateTime fechaFija = DateTime.Now;
        private DateTime fechaInicio = DateTime.Now;
        private DateTime fechaFin = DateTime.Now;
        private int year = 0;
        private int month = 0;
        private string tituloError = "";
        private string busquedaError = "";
        private string horarioError = "";
        private string lugarError = "";
        private string fechaFijaError = "";
        private string fechaInicioError = "";
        private string fechaFinError = "";
        private string yearError = "";
        private string monthError = "";
        private string tokenFB = "";
        private string facebookAlerta = "";

        private string alerta = "";

        //Diseño
        private bool banderaLoader = false;
        private bool banderaFacebook = false;

        private string section1 = "selected";
        private string section2 = "";
        private string section3 = "";
        private string carrusel1 = "";
        private string carrusel2 = "no_view";
        private string carrusel3 = "no_view";
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                if (tokenFB != null && tokenFB != "")
                {
                    banderaFacebook = true;
                }
                FiltroAgendas.Pagina = 1;
                FiltroAgendas.MaximoElementos = 20;
                banderaLoader = true;
                StateHasChanged();
                ConsultarAgendas();
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


        private async Task DescargarImagenesAgendas()
        {
            if (Agendas != null)
            {
                for (int i = 0; i < Agendas.Count; i++)
                {
                    if (Agendas[i].ArchivosAgenda != null)
                    {
                        for (int j = 0; j < Agendas[i].ArchivosAgenda.Count; j++)
                        {
                            Response<byte[]> response = new Response<byte[]>();
                            DownloadArchivoAgenda downloadArchivoAgenda = new DownloadArchivoAgenda(Cliente);
                            response = await downloadArchivoAgenda.Dowload(Agendas[i].ArchivosAgenda[j].Ruta, Agendas[i].IdAgenda);
                            if (response.Status.Exito == 1)
                            {
                                Agendas[i].ArchivosAgenda[j].Ruta = Convert.ToBase64String(response.Data);
                            }
                        }
                    }
                }
            }
            banderaLoader = false;
            StateHasChanged();
        }

        private void TxtBusqueda(ChangeEventArgs args)
        {
            busqueda = args.Value.ToString();
            if (busqueda != "")
            {
                busquedaError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(busqueda))
                {
                    busquedaError = "";
                    FiltroAgendas.Busqueda = busqueda;
                }
                else
                {
                    busquedaError = "NoCaracteresEspeciales";
                    busqueda = "";
                }
            }
            ConsultarAgendas();
            StateHasChanged();
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
                    FiltroAgendas.Titulo = titulo;
                }
                else
                {
                    tituloError = "NoCaracteresEspeciales";
                    titulo = "";
                }
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void TxtHorario(ChangeEventArgs args)
        {
            horario = TimeSpan.Parse(args.Value.ToString());
            if (horario != TimeSpan.Zero)
            {
                horarioError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(horario.ToString()))
                {
                    horarioError = "";
                    FiltroAgendas.Horario = horario;
                }
                else
                {
                    horarioError = "NoCaracteresEspeciales";
                    horario = TimeSpan.Zero;
                }
            }
            ConsultarAgendas();
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
                    FiltroAgendas.Lugar = lugar;
                }
                else
                {
                    lugarError = "NoCaracteresEspeciales";
                    lugar = "";
                }
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void TxtFechaFija(ChangeEventArgs args)
        {
            fechaFija = DateTime.Parse(args.Value.ToString());
            if (fechaFija.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroAgendas.FiltroFechas = 1;
                actualizarFiltro();
                fechaFijaError = "";
                FiltroAgendas.FechaFija = fechaFija;
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void TxtFechaInicio(ChangeEventArgs args)
        {
            fechaInicio = DateTime.Parse(args.Value.ToString());
            if (fechaInicio.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroAgendas.FiltroFechas = 2;
                actualizarFiltro();
                fechaInicioError = "";
                FiltroAgendas.FechaInicio = fechaInicio;
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void TxtFechaFin(ChangeEventArgs args)
        {
            fechaFin = DateTime.Parse(args.Value.ToString());
            if (fechaFin.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                FiltroAgendas.FiltroFechas = 2;
                actualizarFiltro();
                fechaFinError = "";
                FiltroAgendas.FechaFin = fechaFin;
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void SelectYear(ChangeEventArgs args)
        {
            year = int.Parse(args.Value.ToString());
            if (year != 0)
            {
                FiltroAgendas.FiltroFechas = 3;
                actualizarFiltro();
                yearError = "";
                FiltroAgendas.Year = year;
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void SelectMonth(ChangeEventArgs args)
        {
            month = int.Parse(args.Value.ToString());
            if (month != 0)
            {
                FiltroAgendas.FiltroFechas = 4;
                actualizarFiltro();
                monthError = "";
                FiltroAgendas.Mes = month;
            }
            if (year != 0)
            {
                ConsultarAgendas();
            }
            StateHasChanged();
        }
        
        private async void ConsultarAgendas()
        {
            paginas = new List<int>();
            Agendas = new List<Agenda>();
            banderaLoader = true;
            StateHasChanged();
            Response<List<Agenda>> response = new Response<List<Agenda>>();
            SelectAgendas selectAgendas = new SelectAgendas(Cliente);
            response = await selectAgendas.SelectAll(FiltroAgendas);
            if (response.Status.Exito == 1)
            {
                Agendas = response.Data;
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
                //await FormateadorHora();
                //await DescargarImagenesAgendas();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = false;
            StateHasChanged();
        }

        //private async Task FormateadorHora()
        //{
        //    for(int i = 0; i < Agendas.Count; i++)
        //    {
        //        String[] horasMin = Agendas[i].Hora.Split(":");
        //        if(int.Parse(horasMin[0]) > 12)
        //        {
        //            if(int.Parse(horasMin[0]) == 24)
        //            {
        //                Agendas[i].Hora = "00:" + horasMin[1] + " a.m.";
        //            }
        //            else
        //            {
        //                Agendas[i].Hora = (int.Parse(horasMin[0]) - 12) + ":" + horasMin[1] + " p.m.";
        //            }
        //        }
        //        else
        //        {
        //            if(int.Parse(horasMin[0]) == 12)
        //            {
        //                Agendas[i].Hora = horasMin[0] + ":" + horasMin[1] + " p.m.";
        //            }
        //            else
        //            {
        //                Agendas[i].Hora = horasMin[0] + ":" + horasMin[1] + " a.m.";
        //            }
        //        }
        //    }
        //}

        private async void CambiarPaginaActual(int page)
        {
            Agendas = new List<Agenda>();
            paginaActual = page;
            FiltroAgendas.Pagina = paginaActual;
            StateHasChanged();
            ConsultarAgendas();
        }

        private void actualizarFiltro()
        {
            if (FiltroAgendas.FiltroFechas >= 3)
            {
                FiltroAgendas.FechaFin = Fecha.GetFechaMx();
                FiltroAgendas.FechaInicio = Fecha.GetFechaMx();
                FiltroAgendas.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
            }
            else if (FiltroAgendas.FiltroFechas == 2)
            {
                FiltroAgendas.FechaFin = Fecha.GetFechaMx();
                fechaFija = Fecha.GetFechaMx();
                FiltroAgendas.Year = 0;
                FiltroAgendas.Mes = 0;
                year = 0;
                month = 0;
            }
            else
            {
                FiltroAgendas.FechaFin = Fecha.GetFechaMx();
                FiltroAgendas.FechaInicio = Fecha.GetFechaMx();
                FiltroAgendas.FechaFin = Fecha.GetFechaMx();
                fechaInicio = Fecha.GetFechaMx();
                fechaFin = Fecha.GetFechaMx();
                FiltroAgendas.Year = 0;
                FiltroAgendas.Mes = 0;
                year = 0;
                month = 0;
            }
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            busqueda = "";
            titulo = "";
            lugar = "";
            horario = TimeSpan.Zero;
            Agendas = new List<Agenda>();
            FiltroAgendas = new FiltroAgenda();
            FiltroAgendas.Pagina = 1;
            FiltroAgendas.MaximoElementos = 20;
            fechaFija = Fecha.GetFechaMx();
            fechaInicio = Fecha.GetFechaMx();
            fechaFin = Fecha.GetFechaMx();
            year = 0;
            month = 0;
            ConsultarAgendas();
            StateHasChanged();
        }

        private async void CambioOrden(int sectionOrden)
        {
            if (sectionOrden == 1)
            {
                if (FiltroAgendas.Orden == 1)
                {
                    FiltroAgendas.Orden = 2;
                }
                else
                {
                    FiltroAgendas.Orden = 1;
                }
            }
            else if (sectionOrden == 2)
            {
                if (FiltroAgendas.Orden == 3)
                {
                    FiltroAgendas.Orden = 4;
                }
                else
                {
                    FiltroAgendas.Orden = 3;
                }
            }
            else if (sectionOrden == 3)
            {
                if (FiltroAgendas.Orden == 5)
                {
                    FiltroAgendas.Orden = 6;
                }
                else
                {
                    FiltroAgendas.Orden = 5;
                }
            }
            else if (sectionOrden == 4)
            {
                if (FiltroAgendas.Orden == 7)
                {
                    FiltroAgendas.Orden = 8;
                }
                else
                {
                    FiltroAgendas.Orden = 7;
                }
            }
            else if (sectionOrden == 5)
            {
                if (FiltroAgendas.Orden == 9)
                {
                    FiltroAgendas.Orden = 10;
                }
                else
                {
                    FiltroAgendas.Orden = 9;
                }
            }
            else if (sectionOrden == 6)
            {
                if (FiltroAgendas.Orden == 11)
                {
                    FiltroAgendas.Orden = 12;
                }
                else
                {
                    FiltroAgendas.Orden = 11;
                }
            }
            ConsultarAgendas();
            StateHasChanged();
        }

        private void IrNuevaAgenda()
        {
            NavigationManager.NavigateTo("/Eventos/Nuevo");
        }

        private void CambioSection(int posicion)
        {
            if (posicion == 0)
            {
                section1 = "selected";
                section2 = "";
                section3 = "";
                carrusel1 = "";
                carrusel2 = "no_view";
                carrusel3 = "no_view";
            }
            else if (posicion == 1)
            {
                section1 = "";
                section2 = "selected";
                section3 = "";
                carrusel1 = "no_view";
                carrusel2 = "";
                carrusel3 = "no_view";
            }
            else if (posicion == 2)
            {
                section1 = "";
                section2 = "";
                section3 = "selected";
                carrusel1 = "no_view";
                carrusel2 = "no_view";
                carrusel3 = "";
            }
            StateHasChanged();
        }

        private async void EliminarAgenda(int idAgenda)
        {
            Response<object> response = new Response<object>();
            DeleteAgenda deleteAgenda = new DeleteAgenda(Cliente);
            response = await deleteAgenda.Delete(Sesion.TokenAcceso, idAgenda);
            if (response.Status.Exito == 1)
            {
                ConsultarAgendas();
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void irAgenda(int idAgenda)
        {
            NavigationManager.NavigateTo("/Publico/Eventos/Evento/" + idAgenda);
        }

        private void irEditarAgenda(int idAgenda)
        {
            NavigationManager.NavigateTo("/Eventos/Editar/" + idAgenda);
        }
    }
}
