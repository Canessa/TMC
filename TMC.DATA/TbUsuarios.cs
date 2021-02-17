using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TMC.DATA
{
    public class TbUsuarios
    {
        public static int IDRolUsuarioActual { get; set; }
        public static TbUsuarios usuarioActual = new TbUsuarios();
        public int IDUsuario { get; set; }

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
        public List<TbServicios> serviciosContratados { get; set; }

        public static void setUsuarioActual(TbUsuarios usuario)
        {
            usuarioActual.IDRol = usuario.IDRol;
            usuarioActual.IDUsuario = usuario.IDUsuario;
            usuarioActual.nombre = usuario.nombre;
            usuarioActual.apellidos = usuario.apellidos;
            usuarioActual.correo = usuario.correo;
            usuarioActual.telefono = usuario.telefono;
            usuarioActual.foto = usuario.foto;
            IDRolUsuarioActual = usuario.IDRol;
        }
        public static TbUsuarios getUsuarioActual()
        {
            return usuarioActual;
        }

        public static void removeUsuarioActual()
        {
            usuarioActual.nombre = "";
            usuarioActual.apellidos = "";
            usuarioActual.correo = "";
            usuarioActual.telefono = "";
            usuarioActual.foto = "";
        }
    }
}
