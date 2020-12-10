using Firebase.Auth;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbUsuariosController : Controller
    {
        string imagenURL;

        IRolesBLL cRoles = new MRolesBLL();
        public TbUsuariosController()
        {
            cUsuarios = new MUsuariosBLL();
        }
        IUsuariosBLL cUsuarios;
        public static TbUsuarios TempUsuario;

        // GET: For client self edition
        [HttpGet]
        public ActionResult EditClient(int id)
        {
            var data = cUsuarios.Buscar(id);
            TempUsuario = data;
            return View(data);
        }
        [HttpPost]
       public async Task<ActionResult> EditClient(TbUsuarios usuario, HttpPostedFileBase foto)
        {
            FileStream stream;
            usuario.IDRol = TempUsuario.IDRol;
            usuario.IDUsuario = TempUsuario.IDUsuario;
            usuario.correo = TempUsuario.correo;
            usuario.contrasenna = TempUsuario.contrasenna;
            usuario.estado = TempUsuario.estado;
            if (foto == null)
            {
                usuario.foto = TempUsuario.foto;
                await Task.Run(() => cUsuarios.Actualizar(usuario));
            }
            else
            {
                string path = Path.Combine(Server.MapPath("~/Content/images/"), foto.FileName);
                foto.SaveAs(path);
                stream = new FileStream(Path.Combine(path), FileMode.Open);
                await Task.Run(() => actualizarDatos(stream, usuario));
            }
            return RedirectToAction("DetailClient/" + usuario.IDUsuario, "TbUsuarios");
        }

        // GET: For client self edition
        [HttpGet]
        public ActionResult DetailClient(int id)
        {
            var data = cUsuarios.Buscar(id);
            return View(data);
        }
        // GET: List of user for Admin
        [HttpGet]
        public ActionResult Admin_Users()
        {
            List<TbUsuarios> lista = cUsuarios.Mostrar();

            return View(lista);

        }
        //Metodo de carga de los dropdown
        private void CargarListas()
        {
            //cargado en el View
            List<TbRoles> roles = cRoles.Mostrar();
            if (roles == null)
            {
                roles[0].IDRol = 0;
                roles[0].nombre = "No hay roles disponibles";
            }
            ViewBag.ddlRoles = new SelectList(roles, "IDRol", "nombre");
        }

        private void CargarListasUser()
        {
            //cargado en el View
            List<TbUsuarios> usuarios = cUsuarios.Mostrar();
            if (usuarios == null)
            {
                usuarios[0].IDUsuario = 0;
                usuarios[0].nombre = "No hay catálogos disponibles";
            }
            ViewBag.ddlCatalogos = new SelectList(usuarios, "IDUsuario", "Nombre");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cUsuarios.Buscar(id); 
            
            TempUsuario = data;
           CargarListas();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(TbUsuarios usuario)
        {
                usuario.IDUsuario = TempUsuario.IDUsuario;
                usuario.correo = TempUsuario.correo;
                usuario.contrasenna = TempUsuario.contrasenna;
                usuario.foto = TempUsuario.foto;
                
                cUsuarios.Actualizar(usuario);
                CargarListas();
                return View(usuario);
               

        }

        //Bloque que se genera al desactivar un Usuario

        public ActionResult Delete()

        {
            return View();

        }
        //este inserta en la base de datos 
        [HttpPost]
        public ActionResult Delete(int id)

        {
            TbUsuarios usuario = cUsuarios.Buscar(id);
            cUsuarios.Desactivar(id);
            return RedirectToAction("Admin_Users");


        }

        public async void actualizarDatos(FileStream foto, TbUsuarios usuario)
        {
            string apikey = "AIzaSyCx5pPjzlIQa2Jef3wJcmsIpv35DLRGGJY";
            string bucket = "bd-tmc.appspot.com";
            var auth = new FirebaseAuthProvider(new FirebaseConfig(apikey));
            var a = await auth.SignInWithEmailAndPasswordAsync(usuario.correo, usuario.contrasenna);
            var cancelar = new CancellationTokenSource();

            var task = new FirebaseStorage(bucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true
            })
            .Child("fotosDePerfil")
            .Child("fotoPerfil-id" + usuario.IDUsuario)
            .PutAsync(foto, cancelar.Token);

            try
            {
                imagenURL = await task;
                usuario.IDUsuario = TempUsuario.IDUsuario;
                usuario.correo = TempUsuario.correo;
                usuario.contrasenna = TempUsuario.contrasenna;
                usuario.IDRol = TempUsuario.IDRol;
                usuario.foto = imagenURL;
                usuario.estado = TempUsuario.estado;
                Thread.Sleep(5000);
                cUsuarios.Actualizar(usuario);
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
