using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelAPI.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int ID { get; set; }
        [Index(IsUnique = true), MaxLength(20)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}