using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMC.DATA
{
    public class TbNotificaciones
    {
        public int IDNotificacion { get; set; }

        [Display(Name = "Selección de usuarios")]
        public int IDUsuario { get; set; }

        [Display(Name = "Selección de empleados")]
        public int IDEmpleado { get; set; }
    }
}
