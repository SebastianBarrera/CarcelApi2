using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    [Table("CondenaDelitos")]
    public class CondenaDelito
    {
        public int ID { get; set; }
        public int? CondenaId { get; set; }
        public int? DelitoId { get; set; }
        public int Condena { get; set; }
        public Condena Condenas { get; set; }
        public Delito Delito;
    }
}