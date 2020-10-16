using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TMC.UI.Models;

namespace TMC.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private static string ApiKey ="IzaSyCx5pPjzlIQa2Jef3wJcmsIpv35DLRGGJY";
        private static string Bucket = "bd-tmc.firebaseio.com";

        // GET: Usuario

        public ActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Usuario, true);
                ModelState.AddModelError(string.Empty, "Por favor confirme su correo electronico antes de Iniciar Sessión");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (this.Request.IsAuthenticated)
                {
                    //return this.RedirectToLocal(returnUrl);
                }   
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
            return this.View();
        }


    }
}