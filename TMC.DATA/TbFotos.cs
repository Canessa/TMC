using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbFotos
    {
        public int IDFoto { get; set; }

        [Display(Name = "Añadido de Foto")]
        public string foto { get; set; }
    }
}
