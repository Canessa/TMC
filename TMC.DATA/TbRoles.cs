using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbRoles
    {
        public int IDRol { get; set; }

        [Required(ErrorMessage = "Nombre del rol requerido")]
        [Display(Name = "Nombre del Rol")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Detalles sobre el Rol")]
        [Required(ErrorMessage = "Detalles del rol requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string detalle { get; set; }
    }
}
