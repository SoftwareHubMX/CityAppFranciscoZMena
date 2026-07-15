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
    public class Postulacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdPostulacion { get; set; } = 0;
        public string Folio{ get; set; } = "NA";
        public string ApellidoPaterno { get; set; } = "NA";
        public string ApellidoMaterno { get; set; } = "NA";
        public string NombrePostulante { get; set; } = "NA";
        public int Edad { get; set; } = 0;
        public string EstadoCivil { get; set; } = "NA";
        public string Domicilio { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Municipio { get; set; } = "NA";
        public string Sexo { get; set; } = "NA";
        public DateTime FechaNacimiento { get; set; } = Fecha.GetFechaMx();
        public string Telefono1 { get; set; } = "NA";
        public string Telefono2 { get; set; } = "NA";
        public string Correo { get; set; } = "NA";
        public string PuestoRequerido { get; set; } = "NA";
        public string ExperienciaPuesto { get; set; } = "NA";
        public string ExperienciaLaboral1 { get; set; } = "NA";
        public string ExperienciaLaboral2 { get; set; } = "NA";
        public string ExperienciaLaboral3 { get; set; } = "NA";
        public string Salario { get; set; } = "NA";
        public string Idioma { get; set; } = "NA";
        public string PorcentajeIdioma { get; set; } = "NA";
        public int IdEscolaridad { get; set; } = 0;
        public int IdDiscapacidad { get; set; } = 0;
        public int IdCondicion { get; set; } = 0;
        public int IdBolsaTrabajo { get; set; } = 0;

        [ForeignKey("IdEscolaridad")]
        public virtual Escolaridad? Escolaridad { get; set; }

        [ForeignKey("IdDiscapacidad")]
        public virtual Discapacidad? Discapacidad { get; set; }

        [ForeignKey("IdCondicion")]
        public virtual Condicion? Condicion { get; set; }

        [ForeignKey("IdBolsaTrabajo")]
        public virtual BolsaTrabajo? BolsaTrabajo { get; set; }

    }
}
