using System;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;
using System.Collections.Generic;

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
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                cCatalogo.Eliminar(id);
                ModelState.AddModelError(string.Empty, "Catalogo Borrado");
                @ViewBag.Message = "Se ha borrado el Catalogo con éxito";
                return RedirectToAction("Admin_Catalogos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error. Intente de nuevo");
            }
            return RedirectToAction("Admin_Catalogos");


            /*  0 = Eliminado
		        1 = TbCatalogos_TbFotos lo esta usando
		        2 = TbServicios lo esta usando*/
            //cCatalogo.Eliminar(id);
            //return View();
        }

        [HttpGet]
        public ActionResult Admin_Catalogos()
        {
            List<TbCatalogos> lista = cCatalogo.Mostrar();
            if (lista == null) { return RedirectToAction("Create"); };
            return View(lista);
        }
    }
}
