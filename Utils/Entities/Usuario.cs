using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [Display(Name = "nombre"), Required(ErrorMessage = "Campo requerido!")]
        public string nombre { get; set; }

        [Display(Name = "correo"), Required(ErrorMessage = "Campo requerido!")]
        public string correo { get; set; }

        [Display(Name = "user_name"), Required(ErrorMessage = "Campo requerido!")]
        public string user_name { get; set; }

        [Display(Name = "contrasena"), Required(ErrorMessage = "Campo requerido!")]
        public string contrasena { get; set; }

        public string telefono { get; set; }

        public bool activo { get; set; }

        public int marca_eliminado { get; set; }

        public Usuario()
        {
        }
    }
}
