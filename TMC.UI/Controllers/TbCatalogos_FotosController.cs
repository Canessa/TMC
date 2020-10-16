
using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbCatalogos_FotosController : Controller
    {
        ICatalogos_FotosBLL cCatalogo_Fotos;
        public TbCatalogos_FotosController()
        {
            cCatalogo_Fotos = new MCatalogos_FotosBLL();
        }
        [HttpGet]
        public ActionResult Search()
        {
            var list = cCatalogo_Fotos.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(TbCatalogos_TbFotos catalogos_TbFotos)
        {
            try
            {
                cCatalogo_Fotos.Insertar(catalogos_TbFotos);
                ModelState.AddModelError(string.Empty, "Catalogo de Fotos Agregado");
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
            var data = cCatalogo_Fotos.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cCatalogo_Fotos.Buscar(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbCatalogos_TbFotos catalogos_TbFotos)
        {
            cCatalogo_Fotos.Actualizar(catalogos_TbFotos);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cCatalogo_Fotos.Eliminar(id);
            return RedirectToAction("Search");
        }
    }
}