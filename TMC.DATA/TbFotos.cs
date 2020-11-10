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
        [Required(ErrorMessage = "Foto requerida")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string foto { get; set; }
    }
}
