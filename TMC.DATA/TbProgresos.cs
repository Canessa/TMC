using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbProgresos
    {
        public int IDProgreso { get; set; }

        [Display(Name = "ID del Usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Porcentaje de progreso")]
        public int porcentaje { get; set; }
    }
}
