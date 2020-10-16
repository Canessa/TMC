using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbServiciosController : Controller
    {
        IServiciosBLL cServicios;
        public TbServiciosController()
        {
            cServicios = new MServiciosBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cServicios.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbServicios servicios)
        {
            try
            {
                cServicios.Insertar(servicios);
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
            var data = cServicios.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cServicios.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbServicios servicios)
        {
            cServicios.Actualizar(servicios);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cServicios.Desactivar(id);
            return RedirectToAction("Search");
        }
    }
}
