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

        [Display(Name = "Selección del usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Detalles de la cita")]
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres")]
        public string detalle { get; set; }

        [Display(Name = "Nombre del servicio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombreServicio { get; set; }
        [Display(Name = "ID del Servicio")]
        [StringLength(50, ErrorMessage = "Campo requerido")]
        public string IDServicio { get; set; }
        [Display(Name = "Precio del servicio")]
        public float precio { get; set; }
    }
}
