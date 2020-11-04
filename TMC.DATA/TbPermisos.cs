using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbPermisos
    {
        [Display(Name = "Identificador del Permiso")]
        public int IDPermiso { get; set; }

        [Display(Name = "Nombre de Permiso")]
        [Required(ErrorMessage = "Nombre del permiso requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Detalles del Permiso")]
        [Required(ErrorMessage = "Detalle del permiso requerido")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string detalle { get; set; }
    }
}
