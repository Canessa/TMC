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
            vUsuarios.Actualizar(usuario);
        }

        public TbUsuarios Buscar(int idUsuario)
        {
            return vUsuarios.Buscar(idUsuario);
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
                    if (i.IDUsuario == idUsuario && i.estado == 1)
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
              vUsuarios.Insertar(usuario);
        }

        public List<TbUsuarios> Mostrar()
        {
            return vUsuarios.Mostrar();
        }
    }
}
