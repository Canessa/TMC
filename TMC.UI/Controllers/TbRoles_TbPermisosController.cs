using System;
using System.Collections.Generic;
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

            List<TbPermisos> permisos = cPermisos.Mostrar();
            if (permisos == null)
            {
                permisos[0].IDPermiso = 0;
                permisos[0].nombre = "No hay permisos disponibles";
            }
            ViewBag.ddlPermisos = new SelectList(permisos, "IDPermiso", "nombre");
        }
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
            CargarListas();
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbRoles_TbPermisos roles)
        {
            try
            {
                //Obtencion de datos de los DropDown                
                if (roles.IDRol == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar un rol primero");
                    CargarListas();
                    return View();
                }
                                
                if (roles.IDPermiso == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar un permiso primero");
                    CargarListas();
                    return View();
                }


                cRoles_Permisos.Insertar(roles);
                ModelState.AddModelError(string.Empty, "Agregado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            CargarListas();
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
            CargarListas();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbRoles_TbPermisos roles)
        {
            //Obtencion de datos de los DropDown            
            if (roles.IDRol == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar un rol primero");
                CargarListas();
                return View();
            }

            if (roles.IDPermiso == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar un permiso primero");
                CargarListas();
                return View();
            }

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
