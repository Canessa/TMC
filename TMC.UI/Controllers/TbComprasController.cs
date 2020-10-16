using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbComprasController : Controller
    {
        IComprasBLL cCompras;
        public TbComprasController()
        {
            cCompras = new MComprasBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cCompras.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbCompras compras)
        {
            try
            {
                cCompras.Insertar(compras);
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
            var data = cCompras.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cCompras.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbCompras compras)
        {
            cCompras.Actualizar(compras);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cCompras.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}
