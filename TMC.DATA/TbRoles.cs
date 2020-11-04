using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbRoles
    {
        public int IDRol { get; set; }

        [Display(Name = "Nombre del Rol")]
        public string nombre { get; set; }

        [Display(Name = "Detalles sobre el error")]
        public string detalle { get; set; }
    }
}
