using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbUsuariosController : Controller
    {
        
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
       public ActionResult EditClient(TbUsuarios usuario)
        {
            usuario.IDUsuario = TempUsuario.IDUsuario;
            usuario.correo = TempUsuario.correo;
            usuario.contrasenna = TempUsuario.contrasenna;
            usuario.IDRol = TempUsuario.IDRol;
            usuario.estado = TempUsuario.estado;
            cUsuarios.Actualizar(usuario);

            return RedirectToAction("Profile","Usuario");
        }

        // GET: For client self edition
        [HttpGet]
        public ActionResult DetailClient(int id)
        {
            var data = cUsuarios.Buscar(id);
            return View(data);
        }
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


        public ActionResult Edit()
        {

            List<TbUsuarios> lista = cUsuarios.Mostrar();

            return View(lista);

           
        }

        public ActionResult Search()
        {

            List<TbUsuarios> lista = cUsuarios.Mostrar();

            return View(lista);


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
            CargarListasUser();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(TbUsuarios usuarios)
        {
            //Obtencion de datos de los DropDown            
            //if (usuarios.IDRol == 0)
            //{
            //    ModelState.AddModelError(string.Empty, "Debe ingresar un rol primero");
            //    CargarListas();
            //    return View();
            //}


            cUsuarios.Actualizar(usuarios);


            return View();
        }
       


    }
}