using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;
using FireSharp;
using FireSharp.Config;

namespace TMC.UI.Controllers
{
    public class TbPermisosController : Controller
    {
        public TbPermisosController()
        {
            cpermisos = new MPermisosBLL();
        }
        IPermisosBLL cpermisos;        

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(TbPermisos permisos)
        {
            try 
            {
                cpermisos.Insertar(permisos);
                ModelState.AddModelError(string.Empty, "Permiso Agregado");
            } 
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {            
            var list = cpermisos.Mostrar();
            if(list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var data = cpermisos.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cpermisos.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbPermisos permiso)
        {
          
            cpermisos.Actualizar(permiso);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /*  0 = Eliminado
		        1 = TbRoles_TbPermisos lo esta usando*/
            cpermisos.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}