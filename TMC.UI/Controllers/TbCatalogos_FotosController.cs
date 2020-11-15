using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbCatalogos_FotosController : Controller
    {
        ICatalogos_FotosBLL cCatalogo_Fotos;
        //Creacion de los metodos para las tablas de las FK
        ICatalogosBLL cCatalogos;
        IFotosBLL cFotos;
        public TbCatalogos_FotosController()
        {
            cCatalogo_Fotos = new MCatalogos_FotosBLL();
            //Construccion de los metodos para las tablas de las FK
            cCatalogos = new MCatalogosBLL();
            cFotos = new MFotosBLL();
        }

        //Metodo de carga de los dropdown
        private void CargarListas()
        {
            //cargado en el View
            List<TbCatalogos> catalogos = cCatalogos.Mostrar();
            if (catalogos == null)
            {
                catalogos[0].IDCatalogo = 0;
                catalogos[0].detalle = "No hay catálogos disponibles";
            }
            ViewBag.ddlCatalogos = new SelectList(catalogos, "IDCatalogo", "detalle");

            List<TbFotos> fotos = cFotos.Mostrar();
            if (fotos == null)
            {
                fotos[0].IDFoto = 0;
                fotos[0].foto = "No hay fotos disponibles";
            }
            ViewBag.ddlFotos = new SelectList(fotos, "IDFoto", "foto");
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
            CargarListas();
            return View();
        }


        [HttpPost]
        public ActionResult Create(TbCatalogos_TbFotos catalogos_TbFotos)
        {
            try
            {
                if (catalogos_TbFotos.IDCatalogo == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar un catálogo primero");
                    CargarListas();
                    return View();
                }

                if (catalogos_TbFotos.IDFoto == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar una foto primero");
                    CargarListas();
                    return View();
                }

                cCatalogo_Fotos.Insertar(catalogos_TbFotos);
                ModelState.AddModelError(string.Empty, "Catalogo de Fotos Agregado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            CargarListas();
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
            CargarListas();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbCatalogos_TbFotos catalogos_TbFotos)
        {
            if (catalogos_TbFotos.IDCatalogo == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar un catálogo primero");
                CargarListas();
                return View();
            }

            if (catalogos_TbFotos.IDFoto == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar una foto primero");
                CargarListas();
                return View();
            }

            cCatalogo_Fotos.Actualizar(catalogos_TbFotos);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cCatalogo_Fotos.Eliminar(id);
            return RedirectToAction("Search");
        }

        public ActionResult Admin_Catalogos_Fotos()
        {
            List<TbCatalogos_TbFotos> lista = cCatalogo_Fotos.Mostrar();

            return View(lista);


            

        }
    }
}