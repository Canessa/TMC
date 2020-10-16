using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCatalogos
    {
        [Display(Name = "Identificador del Catalogo")]
        public int IDCatalogo { get; set; }
        [Display(Name = "Identificador del Catalogo")]
        public string detalle { get; set; }
    }
}
