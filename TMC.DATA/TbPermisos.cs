using ServiceStack.DataAnnotations;
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
        public string nombre { get; set; }
        [Display(Name = "Detalles del Permiso")]
        public string detalle { get; set; }
    }
}
