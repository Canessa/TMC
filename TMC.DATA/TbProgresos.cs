using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbProgresos
    {
        [AutoIncrement]
        public int IDProgreso { get; set; }
        public string progreso { get; set; }
    }
}
