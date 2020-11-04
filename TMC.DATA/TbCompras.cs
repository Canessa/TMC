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

        [Display(Name = "Precio total ")]
        public decimal precioFinal { get; set; }

        [Display(Name = "Fecha de la compra")]
        public DateTime fecha { get; set; }

        [Display(Name = "Estado de la compra")]
        public bool estado { get; set; }
    }
}
