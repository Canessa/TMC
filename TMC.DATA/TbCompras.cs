using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCompras
    {
        
        public int IDCompra { get; set; }

        [Display(Name = "Selección de usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Selección del servicio")]
        public int IDServicio { get; set; }

        [Display(Name = "Nombre servicio")]
        public int NombreServicio { get; set; }

        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        [Display(Name = "Estado de la compra")]
        public  int estado { get; set; }
    }
}
