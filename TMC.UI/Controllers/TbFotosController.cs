using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbFotosController : Controller
    {
        IFotosBLL cFotos;
        public TbFotosController()
        {
            cFotos = new MFotosBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cFotos.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbFotos fotos)
        {
            try
            {
                cFotos.Insertar(fotos);
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
            var data = cFotos.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cFotos.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbFotos fotos)
        {
            cFotos.Actualizar(fotos);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /*  0 = Eliminada
		        1 = TbCatalogos_TbFotos lo esta usando*/
            cFotos.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}
