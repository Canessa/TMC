using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbComprasController : Controller
    {
        IComprasBLL cCompras;
        //Creacion de los metodos para las tablas de las FK
        IUsuariosBLL cUsuarios;
        IServiciosBLL cServicios;
        public TbComprasController(int id)
        {
            cCompras = new MComprasBLL();
            //Construccion de los metodos para las tablas de las FK
            cUsuarios = new MUsuariosBLL();
            cServicios = new MServiciosBLL();
        }
        public TbComprasController()
        {
            cCompras = new MComprasBLL();
            //Construccion de los metodos para las tablas de las FK
            cUsuarios = new MUsuariosBLL();
            cServicios = new MServiciosBLL();
        }

        //Metodo de carga de los dropdown
        private void CargarListas()
        {
            //cargado en el View
            List<TbUsuarios> usuarios = cUsuarios.Mostrar();
            if (usuarios == null)
            {
                usuarios[0].IDUsuario = 0;
                usuarios[0].correo = "No hay catálogos disponibles";
            }
            ViewBag.ddlUsuarios = new SelectList(usuarios, "IDUsuario", "correo");

            List<TbServicios> servicios = cServicios.Mostrar();
            if (servicios == null)
            {
                servicios[0].IDServicio = 0;
                servicios[0].nombre = "No hay fotos disponibles";
            }
            ViewBag.ddlServicios = new SelectList(servicios, "IDServicio", "nombre");
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
            CargarListas();
            return View();
        }




        [HttpPost]
        public ActionResult Create(TbCompras compras)
        {
            try
            {
                if (compras.IDUsuario == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar un usuario primero");
                    CargarListas();
                    return View();
                }

                if (compras.IDServicio == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar un servicio primero");
                    CargarListas();
                    return View();
                }

                cCompras.Insertar(compras);
                ModelState.AddModelError(string.Empty, "Cita Agregada");
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
            var data = cCompras.Buscar(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cCompras.Buscar(id);
            CargarListas();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TbCompras compras)
        {
            if (compras.IDUsuario == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar un usuario primero");
                CargarListas();
                return View();
            }

            if (compras.IDServicio == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar un servicio primero");
                CargarListas();
                return View();
            }

            cCompras.Actualizar(compras);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cCompras.Eliminar(id);
            return View();
        }

        [HttpGet]
        public ActionResult ComprasUsuario(int id)
        {
            var list = cCompras.ObtenerComprasId(id);
            if (list == null || list.Count < 1) { return RedirectToAction("Empty"); };
            return View(list);
        }
        public ActionResult Empty()
        {
            return View();
        }

        public ActionResult cancelarServicio(int id) {
            var idUsuario = TbUsuarios.getUsuarioActual().IDUsuario;
            cCompras.cancelarServicio(idUsuario, id);
            return RedirectToAction("ComprasUsuario/" + idUsuario, "TbCompras");
        }
    }
}
