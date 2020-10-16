using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMC.UI.Models
{
    public class LoginViewModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Constraseña")]
        public string Password { get; set; }
    }
}