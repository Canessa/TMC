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
        [Display(Name = "Detalles")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string detalle { get; set; }

        [Required(ErrorMessage = "Precio")]
        [Display(Name = "Precio")]
        public float precio { get; set; }

        [Display(Name = "Catálogo")]
        public int IDCatalogo { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        public string foto { get; set; }

        [Display(Name = "Nombre del catálogo")]
        public string NombreCatalogo { get; set; }


        //ignorar, es solo para construir el view de agendarCita
        public string fecha { get; set; }
    }
}
