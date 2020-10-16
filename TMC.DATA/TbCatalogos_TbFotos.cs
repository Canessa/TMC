using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCatalogos_TbFotos
    {
        [Display(Name = "ID del Catalogo de Foto")]
        public int IDCatalogoFoto { get; set; }
        [Display(Name = "ID del Catalogo")]
        public int IDCatalogo { get; set; }
        [Display(Name = "Identificador de la foto")]
        public int IDFoto { get; set; }
    }
}
