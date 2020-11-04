using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMC.DATA
{
    public class TbTestimonios
    {
        public int IDTestimonio { get; set; }

        [Display(Name = "Selección del usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Testimonio del usuario")]
        public string testimonio { get; set; }
    }
}
