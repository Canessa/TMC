using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCitas
    {
        
        public int IDCita { get; set; }

        [Display(Name = "Fecha")]
        public DateTime fechaCita { get; set; }

        [Display(Name = "Usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Detalles")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string detalle { get; set; }

        [Display(Name = "Servicio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombreServicio { get; set; }
        [Display(Name = "Servicio")]
        [StringLength(50, ErrorMessage = "Campo requerido")]
        public string IDServicio { get; set; }
        [Display(Name = "Precio")]
        public float precio { get; set; }
    }
}
