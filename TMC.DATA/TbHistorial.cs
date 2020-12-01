using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMC.DATA
{
    public class TbHistorial
    {
        public int Id { get; set; }
        public string detalle { get; set; }
        public string fecha { get; set; }
    }
}
