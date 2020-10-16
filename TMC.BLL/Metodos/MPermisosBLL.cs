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
    public  class MPermisosBLL : MBase, IPermisosBLL
    {
        public void Actualizar(TbPermisos permiso)
        {
            vPermisos.Actualizar(permiso);
        }

        public TbPermisos Buscar(int idPermiso)
        {
            return vPermisos.Buscar(idPermiso);
        }

        public int Eliminar(int idPermiso)
        {
            //Validacion de relacion con TbRoles_TbPermisos
            IRoles_PermisosBLL cRolesPermisos = new MRoles_PermisosBLL();
            List<TbRoles_TbPermisos> listaRolesPermisos = cRolesPermisos.Mostrar();
            if(listaRolesPermisos != null)
            {
                foreach (TbRoles_TbPermisos i in listaRolesPermisos)
                {
                    if (i.IDPermiso == idPermiso)
                    {
                        return 1;
                    }
                }
            }            
            vPermisos.Eliminar(idPermiso);
            return 0;
        }

        public void Insertar(TbPermisos permiso)
        {
            vPermisos.Insertar(permiso);
        }

        public List<TbPermisos> Mostrar()
        {
            return vPermisos.Mostrar();
        }
    }
}
