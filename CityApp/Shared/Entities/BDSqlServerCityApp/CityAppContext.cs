using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public partial class CityAppContext : DbContext
    {
        public CityAppContext() { }
        public CityAppContext(DbContextOptions<CityAppContext> options) : base(options) { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<DireccionUsuario> DireccionesUsuario { get; set; }
        public DbSet<ContadorAcceso> ContadoresAccesos { get; set; }
        public DbSet<EstatusCuenta> EstatusCuentas { get; set; }
        public DbSet<TipoTokenLogin> TiposTokenLogin { get; set; }
        public DbSet<TokenLogin> TokensLogin { get; set; }
        public DbSet<TokenActualizarPassword> TokensActualizarPassword { get; set; }
        public DbSet<TokenContadorAccesos> TokensContadorAcceso { get; set; }
        public DbSet<TokenVerificacionCorreo> TokensVerificacionCorreo { get; set; }

        public DbSet<TipoReporteCiudadano> TiposReporteCiudadano { get; set; }
        public DbSet<EstatusReporteCiudadano> EstatusReporteCiudadano { get; set; }
        public DbSet<ReporteCiudadano> ReportesCiudadanos { get; set; }
        public DbSet<VercionReporteCiudadano> VercionesReporteCiudadano { get; set; }
        public DbSet<DireccionReporteCiudadano> DireccionesReporteCiudadano { get; set; }
        public DbSet<EvidenciaReporteCiudadano> EvidenciasReporteCiudadano { get; set; }
        public DbSet<EvidenciaSolucionReporteCiudadano> EvidenciasSolucionReporteCiudadano { get; set; }

        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<ArchivoNoticia> ArchivosNoticia { get; set; }

        public DbSet<TipoPago> TiposPago { get; set; }
        public DbSet<EstatusPago> EstatusPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Predio> Predios { get; set; }
        public DbSet<PagoPredio> PagosPredio { get; set; }
        public DbSet<DescuentoPredio> DescuentosPredios { get; set; }
        public DbSet<HistoricoPredio> HistoricosPredios { get; set; }
        public DbSet<ArchivoHistoricoPredio> ArchivoHistoricoPredio { get; set; }

        public DbSet<TipoLugarTuristico> TiposLugarTuristico { get; set; }
        public DbSet<LugarTuristico> LugaresTuristicos { get; set; }
        public DbSet<DireccionLugarTuristico> DireccionesLugaresTuristicos { get; set; }
        public DbSet<ArchivoLugarTuristico> ArchivosLugaresTuristicos { get; set; }
        public DbSet<CaracteristicaLugarTuristico> CaracteristicasLugaresTuristicos { get; set; }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<ArchivoAgenda> ArchivosAgenda { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<DireccionAlerta> DireccionesAlertas { get; set; }
        public DbSet<EstatusAlerta> EstatusAlertas { get; set; }

        public DbSet<Patrulla> Patrullas { get; set; }
        public DbSet<Normatividad> Normatividades { get; set; }
        public DbSet<ContactoSeguridadPublica> ContactosSeguridadPublica { get; set; }
        public DbSet<TipoAtencionContacto> TiposAtencionesContacto { get; set; }

        public DbSet<TipoRedSocial> TiposRedesSociales { get; set; }
        public DbSet<RedSocialMunicipio> RedesSocialesMunicipio { get; set; }
        public DbSet<ContactoMunicipio> ContactosMunicipio { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ArchivoSlider> ArchivosSlider { get; set; }
        public DbSet<TipoSlider> TiposSliders { get; set; }

        public DbSet<Secretaria> Secretarias { get; set; }
        public DbSet<Dependencia> Dependencias { get; set;}
        public DbSet<Tramite> Tramites { get; set; }
        public DbSet<TipoTramite> TiposTramites { get; set; }

        public DbSet<Directorio> Directorios { get; set; }
        public DbSet<ArchivoDirectorio> ArchivosDirectorio { get; set; }
        public DbSet<TipoDirectorio> TiposDirectorio { get; set; }

        //Rutas de Recoleccion
        public DbSet<RutaRecoleccion> RutasRecoleccion { get; set; }
        public DbSet<Colonia> Colonias { get; set; }
        public DbSet<ColoniaRutaRecoleccion> ColoniasRutaRecoleccion { get; set; }
        public DbSet<DiaRuta> DiasRuta { get; set; }
        public DbSet<AlertaRuta> AlertasRutas { get; set; }
        public DbSet<TipoAlertaRuta> TiposAlertaRuta { get; set; }
        public DbSet<StatusAlertaRuta> StatusAlertasRuta { get; set; }

        //Bolsa de Trabajo.
        public DbSet<BolsaTrabajo> BolsasTrabajos { get; set; }
        public DbSet<Giro> Giros { get; set; }
        public DbSet<Postulacion> Postulaciones { get; set; }
        public DbSet<Escolaridad> Escolaridades { get; set; }
        public DbSet<Discapacidad> Discapacidades { get; set; }
        public DbSet<Condicion> Condiciones { get; set; }
        public DbSet<StatusBolsa> StatusBolsas { get; set; }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<CordeenadaRuta> CordeenadasRuta { get; set; }  

        public DbSet<TipoCita> TiposCita { get; set; }

        //Poda y transplante de arboles

        public DbSet<TipoSolicitud> TiposSolicitud { get; set; }
        public DbSet<TipoJustificacionSolicitud> TiposJustificacionSolicitud { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<SolicitudPoda> SolicitudesPoda { get; set; }
        public DbSet<SolicitudTipoJustificacion> SolicitudesTipoJustificaciones { get; set; }
        public DbSet<ArchivoSolicitidPoda> ArchivosSolicitidPoda { get; set; }

        //AchivoAnuncio
        public DbSet<ArchivoAnuncio> ArchivosAnuncio { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
