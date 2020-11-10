using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TMC.DATA
{
    public class TbUsuarios
    {
        public int IDUsuario { get; set; }

        [Display(Name = "Cédula de identificación")]
        [Required(ErrorMessage = "Cédula requerida")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string cedula { get; set; }

        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Apellidos del usuario")]
        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string apellidos { get; set; }

        [Display(Name = "Teléfono de contacto")]
        [Required(ErrorMessage = "Teléfono requerido")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string telefono { get; set; }

        [Display(Name = "Correo de usuario")]
        [Required(ErrorMessage = "Correo electrónico requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        [EmailAddressAttribute(ErrorMessage = "Correo no válido")]
        public string correo { get; set; }

        [Display(Name = "Contraseña del usuario")]
        [Required(ErrorMessage = "Contraseña requerida")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres")]
        public string contrasenna { get; set; }

        [Display(Name = "Selección de rol")]
        public int IDRol { get; set; }

        [Display(Name = "Estado del usuario")]
        public bool estado { get; set; }

        [Display(Name = "Foto de perfil")]
        public string foto { get; set; }
    }
}
