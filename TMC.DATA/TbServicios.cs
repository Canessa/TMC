using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbServicios
    {
        public int IDServicio { get; set; }

        [Required(ErrorMessage = "Nombre del servicio requerido")]
        [Display(Name = "Servicio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Detalles del servicio requeridos")]
        [Display(Name = "Detalles sobre el servicio")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string detalle { get; set; }

        [Required(ErrorMessage = "Precio del servicio requerido")]
        [Display(Name = "Precio del servicio")]
        public decimal precio { get; set; }

        [Display(Name = "Selección del catálogo")]
        public int IDCatalogo { get; set; }

        [Display(Name = "Estado del servicio")]
        public bool estado { get; set; }
    }
}
