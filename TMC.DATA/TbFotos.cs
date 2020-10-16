using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbFotos
    {
        [AutoIncrement]
        public int IDFoto { get; set; }
        public string foto { get; set; }
    }
}
