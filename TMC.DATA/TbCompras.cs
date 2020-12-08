using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCompras
    {
        
        public int IDCompra { get; set; }

        [Display(Name = "Selección del servicio")]
        public int IDServicio { get; set; }

        [Display(Name = "Selección de usuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Nombre servicio")]
        public string NombreServicio { get; set; }

        [Display(Name = "Precio")]
        public float precio { get; set; }

        [Display(Name = "Estado de la compra")]
        public string estado { get; set; }

        [Display(Name = "¿Está activo?")]
        public bool activo { get; set; }
    }
}
