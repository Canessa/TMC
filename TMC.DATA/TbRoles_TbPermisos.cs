
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbRoles_TbPermisos
    {       
        public int IDRolPermiso { get; set; }

        [Display(Name = "Selección del rol")]
        public int IDRol { get; set; }

        [Display(Name = "Selección de permiso")]
        public int IDPermiso { get; set; }

        [Display(Name = "Estado del permiso en el rol")]
        public bool estado { get; set; }
    }
}
