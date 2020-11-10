
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCatalogos
    {

        [Display(Name = "Identificador del Catálogo")]
        public int IDCatalogo { get; set; }

        [Display(Name = "Detalles del Catálogo")]
        [Required(ErrorMessage = "Detalles del catálogo requeridos")]
        public string detalle { get; set; }
    }
}
