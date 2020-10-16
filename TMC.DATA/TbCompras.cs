using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMC.DATA
{
    public class TbCompras
    {
        [AutoIncrement]
        public int IDCompra { get; set; }
        public int IDUsuario { get; set; }
        public int IDServicio { get; set; }
        public decimal precioFinal { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
    }
}
