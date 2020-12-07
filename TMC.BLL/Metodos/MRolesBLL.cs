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
    public class MRolesBLL : MBase, IRolesBLL
    {
        public void Actualizar(TbRoles rol)
        {
            vRoles.Actualizar(rol);
        }

        public TbRoles Buscar(int idRol)
        {
            return vRoles.Buscar(idRol);
        }

        public int Eliminar(int idRol)
        {
            //Validacion de relacion con TbUsuarios
            IUsuariosBLL cUsuarios = new MUsuariosBLL();
            List<TbUsuarios> listaUsuarios = cUsuarios.Mostrar();
            if (listaUsuarios != null)
            {
                foreach (TbUsuarios i in listaUsuarios)
                {
                    if (i.IDRol == idRol)
                    {
                        return 2;
                    }
                }
            }
            vRoles.Eliminar(idRol);
            return 0;
        }

        public void Insertar(TbRoles rol)
        {
            vRoles.Insertar(rol);
        }

        public List<TbRoles> Mostrar()
        {
            return vRoles.Mostrar();
        }
    }
}
