using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbRoles
    {
        [AutoIncrement]
        public int IDRol { get; set; }
        public string nombre { get; set; }
        public string detalle { get; set; }
    }
}
