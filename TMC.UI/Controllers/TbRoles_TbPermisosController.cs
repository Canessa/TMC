using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbRoles_TbPermisosController : Controller
    {
        IRoles_PermisosBLL cRoles_Permisos;
        //Creacion de los metodos para las tablas de las FK
        IRolesBLL cRoles;
        IPermisosBLL cPermisos;
        public TbRoles_TbPermisosController()
        {
            cRoles_Permisos = new MRoles_PermisosBLL();
            //Construccion de los metodos para las tablas de las FK
            cRoles = new MRolesBLL();
            cPermisos = new MPermisosBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cRoles_Permisos.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //cargado en el View
            var roles = cRoles.Mostrar();
            ViewBag.ddlRoles = new SelectList(roles, "IDRol","nombre");

            var permisos = cPermisos.Mostrar();
            ViewBag.ddlPermisos = new SelectList(permisos, "IDPermiso", "nombre");

            return View();
        }




        [HttpPost]
        public ActionResult Create(TbRoles_TbPermisos roles)
        {
            try
            {
                //Obtencion de datos de los DropDown
                roles.IDRol = Convert.ToInt32(Request.Form["ddlRoles"]);
                roles.IDPermiso = Convert.ToInt32(Request.Form["ddlPermisos"]);

                cRoles_Permisos.Insertar(roles);
                ModelState.AddModelError(string.Empty, "Agregado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var data = cRoles_Permisos.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cRoles_Permisos.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbRoles_TbPermisos roles)
        {
            cRoles_Permisos.Actualizar(roles);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cRoles_Permisos.Desactivar(id);
            return RedirectToAction("Search");
        }
    }
}
