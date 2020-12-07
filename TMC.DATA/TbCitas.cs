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

        [Display(Name = "Identificador del progreso")]
        public int IDProgreso { get; set; }

        [Display(Name = "Lugar donde se realizara el evento")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string lugar { get; set; }

        [Display(Name = "Nombre del servicio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombreServicio { get; set; }


       
        public string IDServicio { get; set; }
    }
}
