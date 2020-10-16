using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbProgresosController : Controller
    {
        IProgresosBLL cProgresos;
        public TbProgresosController()
        {
            cProgresos = new MProgresosBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cProgresos.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbProgresos progresos)
        {
            try
            {
                cProgresos.Insertar(progresos);
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
            var data = cProgresos.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cProgresos.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbProgresos progresos)
        {
            cProgresos.Actualizar(progresos);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /*devuelve un int 0 = se eliminó con éxito
             * 1 = si ya esta asginado a una cita y no se puede eliminar*/
            cProgresos.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}
