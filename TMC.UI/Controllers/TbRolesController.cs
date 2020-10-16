using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbRolesController : Controller
    {
        IRolesBLL cRoles;
        public TbRolesController()
        {
            cRoles = new MRolesBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cRoles.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbRoles roles)
        {
            try
            {
                cRoles.Insertar(roles);
                ModelState.AddModelError(string.Empty, "Cita Agregada");
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
            var data = cRoles.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cRoles.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbRoles roles)
        {
            cRoles.Actualizar(roles);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /*  0 = Eliminado
		        1 = TbRoles_TbPermisos lo esta usando
		        2 = TbUsuarios lo esta usando*/
            cRoles.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}
