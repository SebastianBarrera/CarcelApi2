using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    [Table ("Presos")]
    public class Preso
    {
        public int ID { get; set; }
        [MaxLength(20)]
        public string Rut { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(100)]
        public string Domicilio { get; set; }
        public bool Sexo { get; set; }
    }
}