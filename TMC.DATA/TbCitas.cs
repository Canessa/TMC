using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCitas
    {
        
        public int IDCita { get; set; }

        [Display(Name = "Fecha de la cita")]
        public DateTime fechaCita { get; set; }

        [Display(Name = "Selección del usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Detalles de la cita")]
        public string detalle { get; set; }

        [Display(Name = "Identificador del progreso")]
        public int IDProgreso { get; set; }

        [Display(Name = "Lugar donde se realizara el evento")]
        public string lugar { get; set; }
    }
}
