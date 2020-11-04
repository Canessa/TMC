using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMC.DATA
{
    public class TbOcupaciones
    {
        public int IDOcupacion { get; set; }

        [Display(Name = "Nombre de la ocupación")]
        public string nombre { get; set; }
    }
}
