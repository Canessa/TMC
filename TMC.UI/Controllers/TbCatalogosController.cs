using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbCatalogosController : Controller
    {
        ICatalogosBLL cCatalogo;
        public TbCatalogosController()
        {
            cCatalogo = new MCatalogosBLL();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cCatalogo.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(TbCatalogos catalogos)
        {
            try
            {
                cCatalogo.Insertar(catalogos);
                ModelState.AddModelError(string.Empty, "Catalogo Agregado");
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
            var data = cCatalogo.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cCatalogo.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbCatalogos catalogos)
        {
            cCatalogo.Actualizar(catalogos);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /*  0 = Eliminado
		        1 = TbCatalogos_TbFotos lo esta usando
		        2 = TbServicios lo esta usando*/
            cCatalogo.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}
