using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMC.UI.Models
{
    public class SignUpModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = " Confirmar Contraseña")]
        public string Conf_Password { get; set; }

        public int IDUsuario { get; set; }

        //[Display(Name = "Cédula")]
        //[Required(ErrorMessage = "Cédula requerida")]
        //[StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        //public string cedula { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string apellidos { get; set; }

        //[Display(Name = "Teléfono")]
        //[Required(ErrorMessage = "Teléfono requerido")]
        //[Phone]
        //public int telefono { get; set; }


        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{2})$", ErrorMessage = "No es un número de teléfono valido (8 digitos)")]
        public string telefono { get; set; }



        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Correo electrónico requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string correo { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña requerida")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres")]
        public string contrasenna { get; set; }

        [Display(Name = "Rol")]
        public int IDRol { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Display(Name = "Foto de perfil")]
        [FileExtensions]
        public string foto { get; set; }
    }
}