using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbServicios
    {
        [AutoIncrement]
        public int IDServicio { get; set; }
        public string nombre { get; set; }
        public string detalle { get; set; }
        public decimal precio { get; set; }
        public int IDCatalogo { get; set; }
        public int estado { get; set; }
    }
}
