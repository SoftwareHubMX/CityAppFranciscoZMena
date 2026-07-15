using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class BolsaTrabajo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBolsaTrabajo { get; set; } = 0;
        public DateTime FechaPublicacion { get; set; } = Fecha.GetFechaMx();
        public string Puesto { get; set; } = "NA";
        public string Empresa { get; set; } = "NA";
        public string Escolaridad { get; set; } = "NA";
        public string Especialidad { get; set; } = "NA";
        public string Edad { get; set; } = "NA";
        public string Sexo { get; set; } = "NA";
        public string Experiencia { get; set; } = "NA";
        public string Conocimiento { get; set; } = "NA";
        public string Habilidades { get; set; } = "NA";
        public string Funciones { get; set; } = "NA";
        public string Jornada { get; set; } = "NA";
        public string Sueldo { get; set; } = "NA";
        public string Prestaciones { get; set; } = "NA";
        public string OtrasPrestaciones { get; set; } = "NA";
        public string Requisitos { get; set; } = "NA";
        public string Entrevisata { get; set; } = "NA";
        public string Contacto { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Localidad { get; set; } = "NA";
        public string Telefono1 { get; set; } = "NA";
        public string Telefono2 { get; set; } = "NA";
        public string Correo { get; set; } = "NA";
        public string ActividadPrincipal { get; set; } = "NA";
        public string Rfc { get; set; } = "NA";
        public string Plaza { get; set; } = "NA";
        public bool EstatuaBolsa { get; set; } = true;
        public int IdGiro { get; set; } = 0;
        

        [ForeignKey("IdGiro")]
        public virtual Giro? Giro { get; set; }

        

    }
}
