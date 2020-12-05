using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;
using TMC.DAL;
using TMC.BLL.Interfaces;
using TMC.DAL.Metodos;

namespace TMC.BLL.Metodos
{
    public class MUsuariosBLL : MBase, IUsuariosBLL
    {
        public void Actualizar(TbUsuarios usuario)
        {
           // usuario.contrasenna = Encriptar(usuario.contrasenna);
            vUsuarios.Actualizar(usuario);
        }

        public int ObtenerId(string email)
        {
            return vUsuarios.ObtenerId(email);
        }

        public int ObtenerIdRol(string email)
        {
            return vUsuarios.ObtenerIdRol(email);
        }

        public TbUsuarios Buscar(int idUsuario)
        {
            TbUsuarios busqueda = vUsuarios.Buscar(idUsuario);
           // busqueda.contrasenna = Decriptar(busqueda.contrasenna);
            return busqueda;
        }

        public int Desactivar(int idUsuario)
        {
            //Validacion de desactivación con TbCitas
            ICitasBLL cCitas = new MCitasBLL();
            List<TbCitas> listaCitas = cCitas.Mostrar();
            if (listaCitas != null)
            {
                foreach (TbCitas i in listaCitas)
                {
                    if (i.IDUsuario == idUsuario)
                    {
                        return 1;
                    }
                }
            }

            //Validacion de desactivacion con Compras
            IComprasBLL cCompras = new MComprasBLL();
            List<TbCompras> listaCompras = cCompras.Mostrar();
            if (listaCompras != null)
            {
                foreach (TbCompras i in listaCompras)
                {
                    if (i.IDUsuario == idUsuario && i.estado == true)
                    {
                        return 2;
                    }
                }
            }            
            vUsuarios.Desactivar(idUsuario);
            return 0;
        }

        public void Insertar(TbUsuarios usuario)
        {
            //usuario.contrasenna = Encriptar(usuario.contrasenna);
            vUsuarios.Insertar(usuario);
        }

        public void InsertarHistorial(TbHistorial registro)
        {
            vUsuarios.InsertarHistorial(registro);
        }

        public List<TbUsuarios> Mostrar()
        {
            return vUsuarios.Mostrar();
        }

        public TbUsuarios FindEmail (String email)
        {
            TbUsuarios busqueda = vUsuarios.FindEmail(email);
            return busqueda;
        }
        public List<TbServicios> getServiciosContratados(int usuarioID)
        {
            return vUsuarios.getServiciosContratados(usuarioID);
        }
    }
}
