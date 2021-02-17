using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{

    public class TbServiciosController : Controller
    {
        IServiciosBLL cServicios;
        //Creacion de los metodos para las tablas de las FK
        ICatalogosBLL cCatalogos;
        ICitasBLL cCitas;
        public TbServiciosController()
        {
            cServicios = new MServiciosBLL();
            //Construccion de los metodos para las tablas de las FK
            cCatalogos = new MCatalogosBLL();
            cCitas = new MCitasBLL();
        }
        static DateTime LastDate;

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
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = cServicios.Mostrar();
            if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult SearchNotLog()
        {
            var list = cServicios.Mostrar();
            //if (list == null) { return RedirectToAction("Create"); };
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CargarListas();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TbServicios servicios)
        {
            try
            {
                if (servicios.IDCatalogo == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar un catálogo primero");
                    CargarListas();
                    return View();
                }

                cServicios.Insertar(servicios);
                ModelState.AddModelError(string.Empty, "Servicio Agregado");
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
            var data = cServicios.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cServicios.Buscar(id);
            CargarListas();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbServicios servicios)
        {
            if (servicios.IDCatalogo == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar un catálogo primero");
                CargarListas();
                return View();
            }

            cServicios.Actualizar(servicios); 
            CargarListas();
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TbServicios servicio = cServicios.Buscar(id);
            cServicios.Desactivar(id);
            return RedirectToAction("Admin_Servicios");
        }


        public ActionResult Admin_Servicios()
        {
            List<TbServicios> lista = cServicios.Mostrar();

            return View(lista);

            

        }
        [HttpGet]
        public ActionResult Agendar_Servicio(int id)
        {
            TbCitas cita = new TbCitas();
            var servicio = cServicios.Buscar(id);
            cita.nombreServicio = servicio.nombre;
            cita.IDServicio = servicio.IDServicio.ToString();
            cita.detalle = servicio.detalle;
            cita.precio = servicio.precio;
            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            //ultima fecha 
            List<TbCitas> citas = cCitas.Mostrar();
            TbCitas LastRecord = new TbCitas();
            DateTime LastDateC;
            if (citas != null)
            {
                foreach (TbCitas item in citas)
                {
                    LastRecord = item;
                }
                LastDateC = Convert.ToDateTime(LastRecord.fechaCita);
                if(LastDateC < DateTime.Now)
                {
                    cita.fechaCita = DateTime.Now.AddDays(1);
                    return View(cita);
                }
                else
                {
                    cita.fechaCita = LastDateC.AddDays(1);
                    return View(cita);
                }
            }
                
            else
            {
                cita.fechaCita = DateTime.Now.AddDays(1);
                return View(cita);
            }
        }
    }
}
