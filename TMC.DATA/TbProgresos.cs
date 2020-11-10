
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbProgresos
    {
        public int IDProgreso { get; set; }

        [Display(Name = "Progreso")]
        [Required(ErrorMessage = "Descripción del progreso requerido")]
        public string progreso { get; set; }
    }
}
