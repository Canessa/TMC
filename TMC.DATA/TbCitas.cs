using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbCitas
    {
        [AutoIncrement]
        public int IDCita { get; set; }
        public DateTime fechaCita { get; set; }
        public int IDUsuario { get; set; }
        public string detalle { get; set; }
        public int IDProgreso { get; set; }
        public string lugar { get; set; }
    }
}
