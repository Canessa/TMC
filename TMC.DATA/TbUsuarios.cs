using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbUsuarios
    {
        [AutoIncrement]
        public int IDUsuario { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string contrasenna { get; set; }
        public int IDRol { get; set; }
        public int estado { get; set; }
    }
}
