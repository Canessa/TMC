using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMC.DATA;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;

namespace TMC.UI.Controllers
{
    public class HomeController : Controller
    {
        public static String UserGlobal;
        public static TbTestimonios TempTestimonio;
        ITestimoniosBLL cTestimonios = new MTestimoniosBLL();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);








        public ActionResult Index()
        {

            log.Info("información");
            log.Error("errores");
            log.Warn("warm");
            log.Debug("debug");
            
           

            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }

        public ActionResult Servicios()
        {
            ViewBag.Message = "Pagina de Servicios.";

            return View();
        }

        public ActionResult Blog()
        {
            List<TbTestimonios> lista = cTestimonios.Mostrar();

            return View(lista);


        }


        //lista para tbTestimonios

        private void CargarListasTestimonios()
        {

            

            //cargado en el View
            List<TbTestimonios> testimonios = cTestimonios.Mostrar();
            if (testimonios == null)
            {
                testimonios[0].IDTestimonio = 0;
                testimonios[0].testimonio= "No hay testimonios disponibles";
            }
            ViewBag.ddlTestimonios = new SelectList(testimonios, "IDTestimonio", "testimonio");
        }

        [HttpGet]
        public ActionResult CrearBlog()
        {
           

            CargarListasTestimonios();
            return View();
          
        }

        [HttpPost]
        public ActionResult CrearBlog(TbTestimonios testimonios)
        {
            try
            {
                //var id = cTestimonios.Obte(UserGlobal);
                //var Usuario = cTestimonios.Buscar(id);
                //var rol = Usuario.IDTestimonio;
                //var rolobj = cTestimonios.Buscar(rol);
                //ViewBag.Rol = rolobj.IDUsuario;

                //testimonios.IDUsuario = id;
                //testimonios.IDTestimonio = rol;

                cTestimonios.Insertar(testimonios);
                ModelState.AddModelError(string.Empty, "Testimonio Agregado");

                CargarListasTestimonios();
               


               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }


        public ActionResult BlogLog()
        {
            
           

            List<TbTestimonios> lista = cTestimonios.Mostrar();

            return View(lista);


        }
    }
}