using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMC.DATA
{
    public class TbCompras
    {
        
        public int IDCompra { get; set; }

        [Display(Name = "IdServicio")]
        public int IDServicio { get; set; }

        [Display(Name = "IdUsuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Servicio")]
        public string NombreServicio { get; set; }

        [Display(Name = "Precio")]
        public float precio { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "¿Está activo?")]
        public bool activo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }
}
