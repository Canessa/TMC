using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbRoles_TbPermisos
    {
        [AutoIncrement]
        public int IDRolPermiso { get; set; }
        public int IDRol { get; set; }
        public int IDPermiso { get; set; }
        public int estado { get; set; }
    }
}
