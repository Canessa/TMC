using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMC.DATA
{
    public class TbUsuario_TbServicio
    {
        public int IDCompra { get; set; }

        public int IDServicio { get; set; }

        public int IDUsuario { get; set; }
        public string NombreServicio { get; set; }
        public bool estado { get; set; }
        public decimal precio { get; set; }
    }
}
