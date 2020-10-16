using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbCitasController : Controller
    {
        ICitasBLL cCitas;
        public TbCitasController()
        {
            cCitas = new MCitasBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cCitas.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbCitas citas)
        {
            try
            {
                cCitas.Insertar(citas);
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
            var data = cCitas.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cCitas.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbCitas citas)
        {
            cCitas.Actualizar(citas);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /*devuelve un int 0 = Cancelada
             * 1 = No se puede cancelar por el progreso avanzado*/
            cCitas.Cancelar(id);
            return RedirectToAction("Search");
        }
    }
}