using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMC.BLL.Interfaces;
using TMC.BLL.Metodos;
using TMC.DATA;

namespace TMC.UI.Controllers
{
    public class TbUsuariosController : Controller
    {
        public TbUsuariosController()
        {
            cUsuarios = new MUsuariosBLL();
        }
        IUsuariosBLL cUsuarios;
        public static TbUsuarios TempUsuario;

        // GET: For client self edition
        [HttpGet]
        public ActionResult EditClient(int id)
        {
            var data = cUsuarios.Buscar(id);
            TempUsuario = data;
            return View(data);
        }
        [HttpPost]
       public ActionResult EditClient(TbUsuarios usuario)
        {
            usuario.IDUsuario = TempUsuario.IDUsuario;
            usuario.correo = TempUsuario.correo;
            usuario.contrasenna = TempUsuario.contrasenna;
            usuario.IDRol = TempUsuario.IDRol;
            usuario.estado = TempUsuario.estado;
            cUsuarios.Actualizar(usuario);
            return RedirectToAction("Profile","Usuario");
        }

        // GET: For client self edition
        [HttpGet]
        public ActionResult DetailClient(int id)
        {
            var data = cUsuarios.Buscar(id);
            return View(data);
        }
    }
}