using Firebase.Auth;
using Jose;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;
using TMC.UI.Models;

namespace TMC.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private static string ApiKey = "AIzaSyCx5pPjzlIQa2Jef3wJcmsIpv35DLRGGJY";
        private static string Bucket = "bd-tmc.firebaseio.com";
        IUsuariosBLL cUsuarios = new MUsuariosBLL();
        public static String password;
        public static String UserGlobal;

        // GET: Usuario

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Usuario, true);
                password = model.Password;
                UserGlobal = model.Email;

                return this.RedirectToIndex("Create", "Usuario");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error. Intente de nuevo");
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

                  return this.RedirectToIndex(null, returnUrl);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                    var ab = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                    string token = ab.FirebaseToken;
                    var user = ab.User;
                    password = model.Password;
                    UserGlobal = model.Email;
                    if (token != "")
                    {
                        //admin cualquier vista crud
                        //user = profile
                        int rol = cUsuarios.ObtenerId(model.Email);
                        if (rol == 1)
                        {
                            this.SignInUser(user.Email, token, false);
                            return this.RedirectToIndex("Admin_Users", "Usuario");
                        } else if (rol == 2)
                        {
                            this.SignInUser(user.Email, token, false);
                            return this.RedirectToIndex("Profile", "Usuario");
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError(model.Password, "Invalid username or password.");
                    }
                }
            }
            catch (FirebaseAuthException fae)
            {
              ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectas");
            }
            return this.View(model);
        }

        private void SignInUser(string email, string token, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        private void ClaimIdentities(string username, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();
            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        private ActionResult RedirectToIndex(string extension, string url)
        {
            try
            {
                if (Url.IsLocalUrl(url + extension))
                {
                    return this.Redirect(url + extension);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this.RedirectToAction(extension, url);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Usuario");
        }

        public new ActionResult Profile()
        {
            return View();
        }

        public ActionResult Admin_Users()
        {

            return View();

        }
        // TbUsuario creation Upon User Firebase Ath Meth
        public UsuarioController()
        {
            cUsuario = new MUsuariosBLL();
        }
        IUsuariosBLL cUsuario;
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(TbUsuarios usuarios)
        {
            try
            {
                usuarios.correo = UserGlobal;
                usuarios.contrasenna = password;
                usuarios.IDRol = 2;
                usuarios.estado = true;
                usuarios.foto = null;
                cUsuario.Insertar(usuarios);
                ModelState.AddModelError(string.Empty, "Usuario Registrado");
                return this.RedirectToIndex("Login", "Usuario");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
    }
}