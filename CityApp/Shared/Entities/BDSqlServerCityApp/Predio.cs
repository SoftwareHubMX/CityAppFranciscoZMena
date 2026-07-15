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
    public class Predio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPredio { get; set; } = 0;
        public string Clave { get; set; } = "NA";
        public string ClaveCatastral { get; set; } = "NA";
        public int Resago { get; set; } = 0;
        public string Direccion { get; set; } = "NA";
        public string Poblacion { get; set; } = "NA";
        public string Ciudad { get; set; } = "NA";
        public string Estado { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public string Propietario { get; set; } = "NA";
        public DateTime FechaUltimoPago { get; set; } = Fecha.GetFechaMx();
        public double Total { get; set; } = 0;
    }
}
