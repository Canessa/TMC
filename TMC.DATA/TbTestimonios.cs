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
        [Display(Name = "Id de testimonio")]
        public int IDTestimonio { get; set; }

        [Display(Name = "Id de Usuario")]
        public string IDUsuario { get; set; }
        //verificar cambio para insertar nombre

        [Required(ErrorMessage = "Testimonio requerido")]
        [Display(Name = "Testimonio del usuario")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string testimonio { get; set; }


        //solo para mostrar vista en Insertar testimonio
        [Required(ErrorMessage = "Nombre requerido")]
        [Display(Name = "Nombre del usuario")]
        public string nombre { get; set; }
    }
}
