using Firebase.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
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
        IRolesBLL cRoles = new MRolesBLL();
        IServiciosBLL cServicios = new MServiciosBLL();

        public static String password;
        public static String UserGlobal;
        public static string UserActu;

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
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] caracteres = chars.ToCharArray();
                Random rnd = new Random();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 8; i++)
                {
                    int randomIndex = rnd.Next(chars.Length);
                    sb.Append(caracteres.GetValue(randomIndex));
                }
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, sb.ToString(), model.Usuario, true);
                password = model.Password;
                UserGlobal = model.Email;
                TbUsuarios usuario = new TbUsuarios();
                usuario.nombre = model.nombre;
                usuario.apellidos = model.apellidos;
                usuario.correo = model.Email;
                usuario.telefono = model.telefono;
                usuario.IDRol = 2;
                usuario.contrasenna = sb.ToString();
                usuario.foto = "https://firebasestorage.googleapis.com/v0/b/bd-tmc.appspot.com/o/fotosDePerfil%2FClipartKey_809592.png?alt=media&token=9ba3f041-e374-4a18-b465-b870ef5effa2";
                TbHistorial registro = new TbHistorial();
                registro.detalle = "se registro un nuevo usuario: " + UserGlobal;
                registro.fecha = DateTime.Now.ToString();
                cUsuarios.Insertar(usuario);
                cUsuarios.InsertarHistorial(registro);
                await auth.SendPasswordResetEmailAsync(model.Email);
                ViewBag.Message = "Bienvenido " + model.nombre + "! ";
                ViewBag.Message = ViewBag.Message + "Para establecer su contraseña ingrese a su correo electrónico. " +
                    "Por el momento, su contraseña es: " + sb.ToString();
                //Seding Password to email
                string nombre = usuario.nombre;
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add(usuario.correo);
                mmsg.Subject = "Establecer tu contraseña de Sistema TMC";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.AlternateViews.Add(NewPasswordEmail(nombre, sb.ToString()));
                mmsg.From = new System.Net.Mail.MailAddress("tumaestrodeceremoniastmc@gmail.com");

                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.EnableSsl = true;
                //cliente.UseDefaultCredentials = false;
                cliente.Credentials = new System.Net.NetworkCredential("tumaestrodeceremoniastmc@gmail.com", "Tumaestro2020");
                cliente.Host = "smtp.gmail.com";
                cliente.Port = 25;
                cliente.Send(mmsg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error. Intente de nuevo");
            }
            return View();
        }
        //fin de get usuario


        //login
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
        //fin de login


        //post de login
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
                        TbHistorial registro = new TbHistorial();
                        registro.detalle = "el usuario " + UserGlobal + " inició sesión";
                        registro.fecha = DateTime.Now.ToString();
                        int rol = cUsuarios.ObtenerIdRol(model.Email);
                        if (rol == 1)
                        {
                            this.SignInUser(user.Email, token, false);
                            cUsuarios.InsertarHistorial(registro);
                            TbUsuarios.setUsuarioActual(cUsuarios.Buscar(cUsuarios.ObtenerId(UserGlobal)));
                            TbUsuarios usuario = TbUsuarios.usuarioActual;
                            usuario.contrasenna = model.Password;
                            usuario.estado = true;
                            cUsuarios.Actualizar(usuario);
                            return this.RedirectToIndex("Admin_Users", "TbUsuarios");
                        }
                        else if (rol == 2)
                        {
                            this.SignInUser(user.Email, token, false);
                            cUsuarios.InsertarHistorial(registro);
                            TbUsuarios.setUsuarioActual(cUsuarios.Buscar(cUsuarios.ObtenerId(UserGlobal)));
                            TbUsuarios usuario = TbUsuarios.usuarioActual;
                            usuario.contrasenna = model.Password;
                            usuario.estado = true;
                            cUsuarios.Actualizar(usuario);
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
        //fin de post login

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

        [HttpGet]
        public new ActionResult Profile()
        {
            if (TempData.ContainsKey("shortMessage"))
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            var id = cUsuarios.ObtenerId(UserGlobal);
            var Usuario = cUsuarios.Buscar(id);
            var rol = Usuario.IDRol;
            var rolobj = cRoles.Buscar(rol);
            ViewBag.Rol = rolobj.nombre;
            var listaComprados = cServicios.obtenerServiciosComprados(id);
            var pagos = 0;
            if (listaComprados != null)
            {
                foreach (TbCompras compra in listaComprados)
                {
                    if (compra.estado == "pagado")
                    {
                        pagos++;
                    }
                }
                var resultado = (int)Math.Round((double)(100 * pagos) / listaComprados.Count);
                ViewBag.porcentaje = resultado + "%";
            }
            else
            {
                ViewBag.porcentaje = "0%";
            }
            return View(Usuario);
        }


        //[Authorize(Roles="Administrador")]
        public ActionResult Admin_Users()
        {
            List<TbUsuarios> lista = cUsuarios.Mostrar();

            return View(lista);

        }
        // TbUsuario creation Upon User Firebase Ath Meth
        public UsuarioController()
        {
            cUsuario = new MUsuariosBLL();
        }
        IUsuariosBLL cUsuario;
        //public ActionResult Create()
        //{
        //    return View();
        //}
      

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Create(TbUsuarios usuarios)
        //{
        //    try
        //    {
        //        usuarios.correo = UserGlobal;
        //        usuarios.contrasenna = password;
        //        usuarios.IDRol = 2;
        //        usuarios.estado = true;
        //        usuarios.foto = "https://images.app.goo.gl/eJqSchtF1RubTY4d8";
        //        cUsuario.Insertar(usuarios);
        //        ModelState.AddModelError(string.Empty, "Usuario Registrado");
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //    }
        //    return View();
        //}


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Mostar()
        {
            List<TbUsuarios> lista = cUsuarios.Mostrar();

            return View(lista);
        }




        //crear usuario parte de administrador 
        public ActionResult Create_Admin()
        {
            CargarListas();
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create_Admin(TbUsuarios usuarios)
        {
            try
            {
             
                usuarios.estado = true;
                usuarios.foto = null;
                
                cUsuario.Insertar(usuarios);
                ModelState.AddModelError(string.Empty, "Usuario Registrado");
                CargarListas();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            CargarListas();
            return View();
        }




        //public ActionResult Edit()
        //{

        //    return View();
        //}

        public ActionResult Reset_Password()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Reset_Password(string email)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            auth.SendPasswordResetEmailAsync(email);
            try
            {
                @ViewBag.Message = "La solicitud para restablecer su contraseña ha sido enviada al correo " + email + "! ";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error. Intente de nuevo");
            }
       
            return View();
        }

       
        public ActionResult Reset_Password_CurrentUser()
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            auth.SendPasswordResetEmailAsync(UserGlobal);
            TempData["shortMessage"] = "La solicitud para restablecer su contraseña ha sido enviada al correo " + UserGlobal + "! ";
            return RedirectToAction("Profile", "Usuario");
        }





        private AlternateView Mail_Body(String nombre, String clave)
        {


            //img src = "~/Imgs/logo.png"
            string path = Server.MapPath(@"~/Imgs/logo.png");
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            Img.ContentId = "MyImage";
            string str = @"  
            <table>  
                 <tr>  
                    <td>  
                      <img src=cid:MyImage  id='img' alt='' width='50px' height='50px'/>   
                    </td>  
                </tr>
                <tr>  
                 
                    <td> " + "<br/>" +
                "Hola " + nombre +"<br/>"
                + "<br/>" +
                "Recientemente solicitaste un cambio de contraseña de la cuenta TMC. Por ello abajo podrás encontrar la nueva contraseña asignada: " +
                "<br/>" + "<br/>" +
               "<b>" + clave + "</b>" + "<br/>" +"<br/>"+
                "Saludos," +
                "<br/>" +
                "Equipo TMC"+ @"

                    </td>  
                </tr>  
               </table>  
            ";
            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }
        private AlternateView NewPasswordEmail(String nombre, String clave)
        {


            //img src = "~/Imgs/logo.png"
            string path = Server.MapPath(@"~/Imgs/logo.png");
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            Img.ContentId = "MyImage";
            string str = @"  
            <table>  
                 <tr>  
                    <td>  
                      <img src=cid:MyImage  id='img' alt='' width='50px' height='50px'/>   
                    </td>  
                </tr>
                <tr>  
                 
                    <td> " + "<br/>" +
                "Hola " + nombre + "<br/>"
                + "<br/>" +
                "Recientemente creaste un usuario en el sistema TMC. Por ello abajo podrás encontrar la contraseña temporal asignada: " +
                "<br/>" + "<br/>" +
               "<b>" + clave + "</b>" + "<br/>" + "<br/>"
                +"<br/>" +
                "Para cambiar la contraseña, ingrese a nuestro sistema y realiza la solicitud" +
                "<br/>" + "<br/>" +
                "Saludos," +
                "<br/>" +
                "Equipo TMC" + @"

                    </td>  
                </tr>  
               </table>  
            ";
            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }

        private void CargarListas()
        {
            //cargado en el View
            List<TbUsuarios> usuarios = cUsuarios.Mostrar();
            if (usuarios == null)
            {
                usuarios[0].IDUsuario = 0;
                usuarios[0].nombre = "Error";
            }
            ViewBag.ddlCatalogos = new SelectList(usuarios, "IDUsuario", "Nombre");

            //cargado en el View
            List<TbRoles> roles = cRoles.Mostrar();
            if (roles == null)
            {
                roles[0].IDRol = 0;
                roles[0].nombre = "No hay roles disponibles";
            }
            ViewBag.ddlRoles = new SelectList(roles, "IDRol", "nombre");
        }
    }

}
