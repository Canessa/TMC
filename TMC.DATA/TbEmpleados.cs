using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMC.DATA
{
    public class TbEmpleados
    {
        public int IDEmpleado { get; set; }

        [Display(Name = "Nombre de empleado")]
        [Required(ErrorMessage = "Nombre del empleado requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Foto del empleado")]
        [Required(ErrorMessage = "Foto del empleado requerida")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string foto { get; set; }

        [Display(Name = "Selección de ocupación")]
        public int IDOcupacion { get; set; }
    }
}
